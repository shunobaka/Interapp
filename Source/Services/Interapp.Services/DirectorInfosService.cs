namespace Interapp.Services
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Contracts;
    using Data.Common;
    using Data.Models;

    public class DirectorInfosService : IDirectorInfosService
    {
        private IDbRepository<DirectorInfo> directorInfos;
        private IDbRepository<User> users;

        public DirectorInfosService(IDbRepository<DirectorInfo> directorInfos, IDbRepository<User> users)
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

            student.DirectorInfo = new DirectorInfo()
            {
                CreatedOn = DateTime.UtcNow
            };
            this.users.Save();
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
    }
}
