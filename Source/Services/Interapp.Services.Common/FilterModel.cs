namespace Interapp.Services.Common
{
    public class FilterModel
    {
        public string OrderBy { get; set; }

        public string Order { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public string Filter { get; set; }
    }
}
