namespace Interapp.Services
{
    using System.Linq;
    using Contracts;
    using Data.Models;
    using Data.Repositories;

    public class UsersService : IUsersService
    {
        private IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> All()
        {
            return this.users.All();
        }

        public void Delete(string id)
        {
            var user = this.users.GetById(id);

            this.users.Delete(user);
            this.users.SaveChanges();
        }

        public User GetById(string id)
        {
            var user = this.users.GetById(id);

            return user;
        }

        public void Update(User user)
        {
            var originalUser = this.users.GetById(user.Id);

            if (originalUser != null)
            {
                originalUser.DateOfBirth = user.DateOfBirth;
                originalUser.FirstName = user.FirstName;
                originalUser.LastName = user.LastName;

                this.users.SaveChanges();
            }
        }
    }
}
