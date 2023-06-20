namespace Vculp.Api.Shared.Paging;

public abstract class PagedQueryParameters
{
    private readonly int _maxPageSize;

    private int? _pageSize;

    private int? _pageNumber = 1;

    public int? PageNumber {
        get {
            return _pageNumber;
        }
        set {
            _pageNumber = ((value > 0) ? value : _pageNumber);
        }
    }

    public int? PageSize {
        get {
            return _pageSize;
        }
        set {
            _pageSize = ((value > _maxPageSize) ? new int? (_maxPageSize) : value);
        }
    }

    public PagedQueryParameters (int? defaultPageSize, int maxPageSize)
    {
        _pageSize = defaultPageSize;
        _maxPageSize = maxPageSize;
    }
}