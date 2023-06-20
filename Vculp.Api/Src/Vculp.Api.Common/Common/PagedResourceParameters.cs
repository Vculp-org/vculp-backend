namespace Vculp.Api.Common.Common
{
    public abstract class PagedResourceParameters
    {
        private readonly int _maxPageSize;
        private int? _pageSize;
        private int? _pageNumber = 1;

        public PagedResourceParameters(int? defaultPageSize, int maxPageSize)
        {
            _pageSize = defaultPageSize;
            _maxPageSize = maxPageSize;
        }

        public int? PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = (value > 0) ? value : _pageNumber;
            }
        }

        public int? PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > _maxPageSize) ? _maxPageSize : value;
            }
        }
    }
}
