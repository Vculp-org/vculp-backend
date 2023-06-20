namespace Vculp.Api.Common
{
    public class PagingMetadata
    {
        private int _totalItems;
        private int _totalPages;
        private int _pageSize;
        private int _currentPage;

        public PagingMetadata()
        {
            _totalItems = 0;
            _totalPages = 1;
            _pageSize = 1;
            _currentPage = 1;
        }

        public int TotalItems
        {
            get
            {
                return _totalItems;
            }
            set
            {
                _totalItems = (value > 0) ? value : 0;
            }
        }

        public int TotalPages
        {
            get
            {
                return _totalPages;
            }
            set
            {
                _totalPages = (value > 1) ? value : 1;
            }
        }

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > 1) ? value : 1;
            }
        }

        public int CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = (value > 1) ? value : 1;
            }
        }
    }
}
