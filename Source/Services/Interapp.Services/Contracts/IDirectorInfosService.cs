namespace Interapp.Services.Contracts
{
    using System.Linq;
    using Data.Models;

    public interface IDirectorInfosService
    {
        DirectorInfo GetById(string id);

        void Update(string directorId, DirectorInfo info);

        void Create(string directorId);

        DirectorInfo GetFullInfoById(string id);
    }
}
