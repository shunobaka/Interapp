namespace Interapp.Services
{
    using Contracts;
    using System;
    using Data.Models;
    using Data.Repositories;
    using System.Linq;
    using System.Data.Entity;
    public class DirectorInfosService : IDirectorInfosService
    {
        private IRepository<DirectorInfo> directorInfos;
        private IRepository<User> users;

        public DirectorInfosService(IRepository<DirectorInfo> directorInfos, IRepository<User> users)
        {
            this.directorInfos = directorInfos;
            this.users = users;
        }

        public void Create(string directorId)
        {
            var student = this.users
                .All()
                .Where(u => u.Id == directorId)
                .FirstOrDefault();

            student.DirectorInfo = new DirectorInfo();
            this.users.SaveChanges();
        }

        public DirectorInfo GetById(string id)
        {
            return this.directorInfos
                .All()
                .Where(d => d.DirectorId == id)
                .FirstOrDefault();
        }

        public DirectorInfo GetFullInfoById(string id)
        {
            return this.directorInfos
                .All()
                .Where(d => d.DirectorId == id)
                .Include(d => d.Universities)
                .Include(d => d.Director)
                .FirstOrDefault();
        }

        public void Update(string directorId, DirectorInfo info)
        {
            throw new NotImplementedException();
        }
    }
}
