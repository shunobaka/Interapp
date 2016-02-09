namespace Interapp.Services.Contracts
{
    using Data.Models;
    using System.Linq;

    public interface IDirectorInfosService
    {
        DirectorInfo GetById(string id);

        void Update(string directorId, DirectorInfo info);

        void Create(string directorId);

        DirectorInfo GetFullInfoById(string id);
    }
}
