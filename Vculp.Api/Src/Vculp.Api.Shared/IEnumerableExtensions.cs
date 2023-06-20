using Vculp.Api.Shared.Abstractions.Paging;
using Vculp.Api.Shared.Paging;

namespace Vculp.Api.Shared;

public static class IEnumerableExtensions
{
    public static IEnumerable<T> PageResults<T> (this IEnumerable<T> items, int pageNumber, int pageSize)
    {
        if (pageNumber < 1) {
            throw new ArgumentOutOfRangeException ("pageNumber", "pageNumber must be greater than 0");
        }
        if (pageSize < 1) {
            throw new ArgumentOutOfRangeException ("pageSize", "pageSize must be greater than 0");
        }
        return items.Skip ((pageNumber - 1) * pageSize).Take (pageSize);
    }

    public static IPagedList<T> ToPagedList<T> (this IEnumerable<T> pagedItems, int unpagedItemCount, int pageNumber, int pageSize)
    {
        return PagedList<T>.Create (pagedItems, unpagedItemCount, pageNumber, pageSize);
    }
}
