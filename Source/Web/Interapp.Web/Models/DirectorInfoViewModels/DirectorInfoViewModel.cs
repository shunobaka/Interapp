namespace Interapp.Web.Models.DirectorInfoViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;
    using UserViewModels;

    public class DirectorInfoViewModel : IMapFrom<DirectorInfo>
    {
        public UserViewModel Director { get; set; }
    }
}