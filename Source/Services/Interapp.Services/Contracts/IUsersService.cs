namespace Interapp.Services.Contracts
{
    using System.Linq;
    using Data.Models;

    public interface IUsersService
    {
        IQueryable<User> All();

        User GetById(string id);

        void Update(User user);

        void Delete(string id);
    }
}
