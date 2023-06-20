using System;
using System.Threading;
using System.Threading.Tasks;
using CorrelationId.Abstractions;
using MediatR;
using Vculp.Api.Common.Common;
using Vculp.Api.Shared.Abstractions.Cqrs;


namespace Vculp.Api.Common
{
    public class CommandMessageContextPopulatingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand
    {
        private readonly ICorrelationContextAccessor _correlationContextAccessor;
        private readonly MessageContext _messageContext;

        public CommandMessageContextPopulatingBehaviour(
            ICorrelationContextAccessor correlationContextAccessor,
            MessageContext messageContext)
        {
            _correlationContextAccessor = correlationContextAccessor ?? throw new ArgumentNullException(nameof(correlationContextAccessor));
            _messageContext = messageContext ?? throw new ArgumentNullException(nameof(messageContext));
        }

        public async Task<TResponse> Handle(TRequest request,CancellationToken cancellationToken,RequestHandlerDelegate<TResponse> next)
        {
            var correlationId = _correlationContextAccessor.CorrelationContext.CorrelationId;
            _messageContext[MessageContextKeys.CorrelationId] = correlationId;

            return await next();
        }
    }
}
