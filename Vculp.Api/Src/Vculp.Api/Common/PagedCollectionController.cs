using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Common.Dtos;

namespace Vculp.Api.Common
{
    public abstract class PagedCollectionController : VculpController
    {
        protected virtual LinkedCollectionResourceWrapperDto<T> CreateHateoasLinksForCollection<T>
        (
            LinkedCollectionResourceWrapperDto<T> collection,
            PagedResourceParameters resourceParameters,
            bool hasNextPage,
            bool hasPreviousPage
        ) where T : LinkedResourceDto
        {
            return CreateHateoasLinksForCollection(collection, resourceParameters, hasNextPage, hasPreviousPage, string.Empty);
        }

        protected virtual LinkedCollectionResourceWrapperDto<T> CreateHateoasLinksForCollection<T>
        (
            LinkedCollectionResourceWrapperDto<T> collection,
            PagedResourceParameters resourceParameters,
            bool hasNextPage,
            bool hasPreviousPage,
            string prefix
        ) where T : LinkedResourceDto
        {
            collection.Links.Add(
                new LinkDto(CreatePagedResourceUriForCurrentRoute(resourceParameters, ResourceUriType.Current, prefix),
                LinkRels.Self,
                "GET"
                ));

            if (hasNextPage)
            {
                collection.Links.Add(
                    new LinkDto(CreatePagedResourceUriForCurrentRoute(resourceParameters, ResourceUriType.NextPage, prefix),
                    LinkRels.NextPage,
                    "GET"
                    ));
            }

            if (hasPreviousPage)
            {
                collection.Links.Add(
                    new LinkDto(CreatePagedResourceUriForCurrentRoute(resourceParameters, ResourceUriType.PreviousPage, prefix),
                    LinkRels.PreviousPage,
                    "GET"
                    ));
            }

            return collection;
        }

        protected void GeneratePagingHeaders(IPagedObject pagedObject)
        {
            if (pagedObject == null)
            {
                throw new ArgumentNullException(nameof(pagedObject));
            }

            Response.Headers.Add("X-Paging-TotalItems", pagedObject.TotalItems.ToString());
            Response.Headers.Add("X-Paging-TotalPages", pagedObject.TotalPages.ToString());
            Response.Headers.Add("X-Paging-PageSize", pagedObject.PageSize.ToString());
            Response.Headers.Add("X-Paging-CurrentPage", pagedObject.CurrentPage.ToString());
        }

        protected void GeneratePagingHeaders(PagingMetadata metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException(nameof(metadata));
            }

            Response.Headers.Add("X-Paging-TotalItems", metadata.TotalItems.ToString());
            Response.Headers.Add("X-Paging-TotalPages", metadata.TotalPages.ToString());
            Response.Headers.Add("X-Paging-PageSize", metadata.PageSize.ToString());
            Response.Headers.Add("X-Paging-CurrentPage", metadata.CurrentPage.ToString());
        }

        private string CreatePagedResourceUriForCurrentRoute
        (
            PagedResourceParameters resourceParameters,
            ResourceUriType uriType,
            string prefix = ""
        )
        {
            prefix = string.IsNullOrWhiteSpace(prefix) ? prefix : $"{prefix}.";

            var queryStringValues = QueryHelpers.ParseQuery(this.Request.QueryString.Value);

            switch (uriType)
            {
                case ResourceUriType.PreviousPage:
                    queryStringValues[$"{prefix}pageNumber"] = (resourceParameters.PageNumber - 1).ToString();
                    queryStringValues[$"{prefix}pageSize"] = resourceParameters.PageSize.ToString();
                    return AddQueryStringValuesToRequestUrl(queryStringValues);
                case ResourceUriType.NextPage:
                    queryStringValues[$"{prefix}pageNumber"] = (resourceParameters.PageNumber + 1).ToString();
                    queryStringValues[$"{prefix}pageSize"] = resourceParameters.PageSize.ToString();
                    return AddQueryStringValuesToRequestUrl(queryStringValues);
                case ResourceUriType.Current:
                default:
                    return Request.GetDisplayUrl();
            }
        }

        private string AddQueryStringValuesToRequestUrl(IDictionary<string, StringValues> queryStringValues)
        {
            //This will generate an absolute Url for the current action method.
            var requestUrl = Url.Link(null, null);

            foreach (var query in queryStringValues)
            {
                foreach (var value in query.Value)
                {
                    requestUrl = QueryHelpers.AddQueryString(requestUrl, query.Key, value);
                }
            }

            return requestUrl;
        }
    }
}
