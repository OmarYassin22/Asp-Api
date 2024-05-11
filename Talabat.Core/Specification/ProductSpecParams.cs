namespace Talabat.presentations.Helpers
{
    public class ProductSpecParams
    {
        public string? sort { get; set; }
        public int? brandId { get; set; }
        public int? CategoryId { get; set; }

        private const int maxSize= 10;
        private int pageSize=5;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > maxSize ? maxSize : value; }
        }
        public int PageIndex { get; set; } = 1;
        private string? search;

        public string? Search
        {
            get { return search; }
            set { search = value?.ToLower(); }
        }

    }
}
