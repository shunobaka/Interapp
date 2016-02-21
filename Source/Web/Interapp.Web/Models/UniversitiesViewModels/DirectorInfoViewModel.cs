namespace Interapp.Web.Models.UniversitiesViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class DirectorInfoViewModel : IMapFrom<DirectorInfo>
    {
        public UserViewModel Director { get; set; }
    }
}