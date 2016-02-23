namespace Interapp.Services.Contracts
{
    using System.Linq;
    using Data.Models;

    public interface IDirectorInfosService
    {
        IQueryable<DirectorInfo> All();

        DirectorInfo GetById(string id);

        void Create(string directorId);

        DirectorInfo GetFullInfoById(string id);
    }
}
