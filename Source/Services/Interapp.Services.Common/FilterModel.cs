namespace Interapp.Services.Common
{
    public class FilterModel
    {
        public FilterModel()
        {
            this.Page = 1;
            this.PageSize = 10;
        }
        
        public string OrderBy { get; set; }

        public string Order { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public string Filter { get; set; }
    }
}
