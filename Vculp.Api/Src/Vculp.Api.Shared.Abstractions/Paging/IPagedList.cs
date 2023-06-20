using System.Collections;

namespace Vculp.Api.Shared.Abstractions.Paging;

public interface IPagedList<T> : IEnumerable<T>, IEnumerable
{
    int CurrentPage { get; }

    int TotalPages { get; }

    int TotalItems { get; }

    int PageSize { get; }

    bool HasPrevious { get; }

    bool HasNext { get; }
}