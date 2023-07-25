using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Autofac;
using CorrelationId;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Azure.ServiceBus;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.SwaggerUI;
using Vculp.Api.Bootstrapper.Applications;
using Vculp.Api.Bootstrapper.Common;
using Vculp.Api.Bootstrapper.Notifications;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Outbox;
using Vculp.Api.Swagger;

namespace Vculp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(o => o.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en")
                };

                options.SupportedUICultures = supportedCultures;
                options.FallBackToParentCultures = true;
                options.FallBackToParentUICultures = true;
                options.DefaultRequestCulture = new RequestCulture(culture: new CultureInfo("en"), uiCulture: new CultureInfo("en"));
            });

            services.BootstrapVculpDependecies(Configuration);

            services.AddHttpContextAccessor();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<IUrlHelper>(implementationFactory =>
            {
                var actionContext = implementationFactory.GetRequiredService<IActionContextAccessor>().ActionContext;
                var urlHelperFactory = implementationFactory.GetRequiredService<IUrlHelperFactory>();
                return urlHelperFactory.GetUrlHelper(actionContext);
            });
            
            services.AddEntityFrameworkConfiguration(Configuration.GetConnectionString("VculpConnection"));
            services.AddRepositories();
            services.AddCachingComponents();
            services.ConfigureMediator(pipeline => pipeline.ConfigureApiMediatorPipeline());
            services.AddDomainEventComponents(registerAsyncHandlers: false);
            services.AddDomainServicesComponents();
            //services.ConfigureOutbox(SetupOutboxTriggerProcessor);
            services.ConfigureUnitOfWork();
            services.ConfigurateMessageContext();
            services.ConfigureNotificationsModule(Configuration);
            services.ConfigureFluentValidation(SetupValidators);
            //services.ConfigureBroadcastHandling(Configuration);
            services.ConfigureLinkGeneration(Configuration);
            services.ConfigureUserAccessor(x => x.AddScoped<ICurrentUserAccessor, HttpContextCurrentUserAccessor>());
            services.ConfigureApplicationInsights(Configuration, ApplicationInsightsWorkloadType.Api);
            services.ConfigureApplicationsModule(Configuration);
            services.BootstrapGeocoder(Configuration);

            services.AddMvcCore()
                .AddNewtonsoftJson(
                    opts => opts.SerializerSettings.Converters.Add(new StringEnumConverter())
                    )
                .AddAuthorization()
                .AddApiExplorer()
                .AddMvcOptions(options =>
                {
                     var policy = new AuthorizationPolicyBuilder()
                         .RequireAuthenticatedUser()
                         .Build();

                    options.Filters.Add(new AuthorizeFilter(policy));

                    // We register custom media types below to work around the issue of some media types in the API
                    // having non-standard formats. When these non-standard formats are cleaned up, this code can be removed.

                    var mediaType = new MediaTypeHeaderValue(
                        new StringSegment("vnd/*+json"));

                    var jsonInputFormatter = (NewtonsoftJsonInputFormatter)options.InputFormatters.First(f => f.GetType() == typeof(NewtonsoftJsonInputFormatter));

                    jsonInputFormatter.SupportedMediaTypes.Add(mediaType);

                    var jsonOutputFormatter = options.OutputFormatters.OfType<NewtonsoftJsonOutputFormatter>().First();

                    jsonOutputFormatter.SupportedMediaTypes.Add(mediaType);
                })
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                });

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration["identity_server:swagger_ui_identity_server_url"];
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "Vculp.Api";
                });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Vculp APi",
                    Version = "v1",
                    Description = "Api for the Vculp system",
                    Contact = new OpenApiContact { Name = "Vculp", Email = "Vculp@Vculp.org", Url = new Uri("http://www.Vculp.org") }

                });

                options.OperationFilter<AuthorizeCheckOperationFilter>();
                options.DescribeAllParametersInCamelCase();

                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(Configuration["identity_server:swagger_ui_identity_server_url"] + "/connect/authorize"),
                            TokenUrl = new Uri(Configuration["identity_server:swagger_ui_identity_server_url"] + "/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                { "read", "read" },
                                { "write", "write" }
                            }
                        }
                    }
                });

                options.EnableAnnotations();

                options.IncludeXmlComments(() =>
                {
                    var basePath = ApplicationEnvironment.ApplicationBasePath;
                    var apiDocumentation = XDocument.Load(Path.Combine(ApplicationEnvironment.ApplicationBasePath, "Vculp.Api.xml"));
                    var dtoDocumentation = XDocument.Load(Path.Combine(ApplicationEnvironment.ApplicationBasePath, "Vculp.Api.Common.xml"));

                    apiDocumentation.Root.Add(dtoDocumentation.Element("doc").Descendants("assembley"));
                    apiDocumentation.Root.Add(dtoDocumentation.Element("doc").Descendants("members"));
                    apiDocumentation.Save(Path.Combine(basePath, "CombinedSwaggerDocumentation.xml"));

                    return new XPathDocument(Path.Combine(basePath, "CombinedSwaggerDocumentation.xml"));
                });

                options.CustomSchemaIds(a => a.FullName);
                options.ResolveConflictingActions(a => a.First());
                options.OperationFilter<TagByApiExplorerSettingsOperationFilter>();

            });

            services.AddSignalR();
            services.AddApiCorrelationIdConfiguration();

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                    ForwardedHeaders.XForwardedProto;
                // Only loopback proxies are allowed by default.
                // Clear that restriction because forwarders are enabled by explicit 
                // configuration.
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.ConfigureContainer(Configuration);
            builder.ConfigureCommandBus(Configuration, CommandBusDispatchMode.Outbox);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStringLocalizer<Startup> stringLocalizer)
        {
            app.UseCorrelationId();
            app.UseForwardedHeaders();

            var localizationOption = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizationOption.Value);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync(stringLocalizer["UnexpectedErrorMessage"]);
                    });
                });
            }

            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host}" } };
                });
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vculp API");
                c.OAuthClientId("swaggerui");
                c.OAuthAppName("Swagger UI");
                c.DefaultModelExpandDepth(-1);
                c.DocExpansion(DocExpansion.None);
            });

            app.UseRouting();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // Ensures that the Subject Claim is populated.

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void SetupOutboxTriggerProcessor(IServiceCollection services)
        {
            services.AddSingleton<IOutboxProcessingTriggerQueue>(factory =>
            {
                var queueClient = new QueueClient(
                    Configuration["serviceBus:connectionString"],
                    Configuration["serviceBus:outboxQueueName"]);

                return new AzureServiceBusOutboxProcessingTriggerQueue(queueClient);
            });

            services.Decorate<IOutboxProcessingTriggerQueue, LoggingOutboxProcessingTriggerQueue>();

            services.AddHostedService<OutboxTriggerQueuingService>();
        }

        private void SetupValidators(IServiceCollection services)
        {
            services.AddTransient<IValidatorFactory, ServiceProviderValidatorFactory>();
        }
    }
}
