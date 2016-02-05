namespace Interapp.Services.Contracts
{
    using System.Linq;
    using Data.Models;
    using Common;

    public interface IMajorsService
    {
        IQueryable<Major> All();

        IQueryable<Major> GetFiltered(FilterModel filter);

        Major GetById(int id);

        void Update(int id, Major major);

        void Delete(int id);
    }
}
