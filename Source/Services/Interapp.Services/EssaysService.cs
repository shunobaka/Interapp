namespace Interapp.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Common;
    using Data.Models;

    public class EssaysService : IEssaysService
    {
        private IDbRepository<Essay> essays;

        public EssaysService(IDbRepository<Essay> essays)
        {
            this.essays = essays;
        }

        public void Create(string studentId, string title, string content)
        {
            var essay = new Essay()
            {
                AuthorId = studentId,
                Title = title,
                Content = content,
                CreatedOn = DateTime.UtcNow
            };

            this.essays.Add(essay);
            this.essays.Save();
        }

        public void Delete(string studentId)
        {
            var essay = this.essays.GetById(studentId);
            this.essays.Delete(essay);
            this.essays.Save();
        }

        public Essay GetByStudentId(string studentId)
        {
            var essay = this.essays
                .All()
                .Where(e => e.AuthorId == studentId)
                .FirstOrDefault();

            return essay;
        }

        public void Update(string studentId, string title, string content)
        {
            var essay = this.essays
                .All()
                .Where(e => e.AuthorId == studentId)
                .FirstOrDefault();

            if (essay == null)
            {
                this.Create(studentId, title, content);
                return;
            }

            essay.Title = title;
            essay.Content = content;
            this.essays.Save();
        }
    }
}
