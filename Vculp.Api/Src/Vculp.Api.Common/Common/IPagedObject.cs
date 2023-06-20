namespace Vculp.Api.Common.Common
{
    public interface IPagedObject
    {
        int CurrentPage { get; }
        int TotalPages { get; }
        int TotalItems { get; }
        int PageSize { get; }
        bool HasPrevious { get; }
        bool HasNext { get; }
    }
}
