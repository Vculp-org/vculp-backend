using System.Collections;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Shared.Paging;

public class PagedList<T> : List<T>, IPagedList<T>, IEnumerable<T>, IEnumerable
{
    public int CurrentPage { get; private set; }

    public int TotalPages { get; private set; }

    public int PageSize { get; private set; }

    public int TotalItems { get; private set; }

    public bool HasPrevious => CurrentPage > 1;

    public bool HasNext => CurrentPage < TotalPages;

    public PagedList (IEnumerable<T> items, int unpagedItemCount, int pageNumber, int pageSize)
    {
        if (unpagedItemCount < 0) {
            throw new ArgumentOutOfRangeException ("unpagedItemCount", "unpagedItemCount cannot be less than zero.");
        }
        if (pageNumber < 1) {
            throw new ArgumentOutOfRangeException ("pageNumber", "pageNumber cannot be less than one.");
        }
        if (pageSize < 1) {
            throw new ArgumentOutOfRangeException ("pageSize", "pageSize cannot be less than one.");
        }
        CurrentPage = pageNumber;
        PageSize = pageSize;
        TotalItems = unpagedItemCount;
        TotalPages = (int)Math.Ceiling ((double)unpagedItemCount / (double)pageSize);
        AddRange (items ?? Enumerable.Empty<T> ());
    }

    public static PagedList<T> Create (IEnumerable<T> pagedItems, int unpagedItemCount, int pageNumber, int pageSize)
    {
        if (pagedItems == null) {
            return null;
        }
        if (pageNumber < 1) {
            throw new ArgumentOutOfRangeException ("pageNumber", "pageNumber must be greater than 0");
        }
        if (pageSize < 1) {
            throw new ArgumentOutOfRangeException ("pageSize", "pageSize must be greater than 0");
        }
        return new PagedList<T> (pagedItems, unpagedItemCount, pageNumber, pageSize);
    }
}