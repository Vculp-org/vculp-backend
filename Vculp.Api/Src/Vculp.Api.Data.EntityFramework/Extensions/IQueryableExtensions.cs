using System;
using System.Linq;
using Vculp.Api.Common.Common;

namespace Vculp.Api.Data.EntityFramework.Extensions
{
    public static class IQueryableExtentions
    {
        public static IQueryable<T> PageResults<T>(this IQueryable<T> items, int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber), $"{nameof(pageNumber)} must be greater than 0");
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), $"{nameof(pageSize)} must be greater than 0");
            }

            return items
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        public static IQueryable<T> PageResults<T>(this IQueryable<T> items, PagedResourceParameters pageParameters)
        {
            if (pageParameters == null)
            {
                throw new ArgumentNullException(nameof(pageParameters));
            }

            int pageNumber = (int)pageParameters.PageNumber;
            int pageSize = (int)pageParameters.PageSize;

            return items.PageResults(pageNumber, pageSize);
        }
    }
}
