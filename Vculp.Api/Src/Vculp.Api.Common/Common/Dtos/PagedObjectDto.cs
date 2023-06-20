using System;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Common.Common.Dtos
{
    public class PagedObjectDto : IPagedObject
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalItems { get; set; }

        public int PageSize { get; set; }

        public bool HasPrevious { get; set; }

        public bool HasNext { get; set; }

        public static PagedObjectDto MapFromPagedList<T>(IPagedList<T> pagedList)
        {
            if (pagedList == null)
            {
                throw new ArgumentNullException(nameof(pagedList));
            }

            return new PagedObjectDto
            {
                CurrentPage = pagedList.CurrentPage,
                TotalPages = pagedList.TotalPages,
                TotalItems = pagedList.TotalItems,
                PageSize = pagedList.PageSize,
                HasNext = pagedList.HasNext,
                HasPrevious = pagedList.HasPrevious
            };
        }
    }
}
