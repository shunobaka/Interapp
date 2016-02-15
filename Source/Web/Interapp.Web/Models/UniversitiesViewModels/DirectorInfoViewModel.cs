namespace Interapp.Web.Models.UniversitiesViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class DirectorInfoViewModel : IMapFrom<DirectorInfo>
    {
        public UserViewModel Director { get; set; }
    }
}