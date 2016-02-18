namespace Interapp.Services.Contracts
{
    using Data.Models;
    using System.Linq;

    public interface IUsersService
    {
        IQueryable<User> All();

        User GetById(string id);

        void Update(User user);

        void Delete(string id);
    }
}
