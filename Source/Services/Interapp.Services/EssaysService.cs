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

        public IQueryable<Essay> All()
        {
            return this.essays.All();
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

        public void Update(Essay essay)
        {
            var orgEssay = this.essays
                .All()
                .Where(e => e.AuthorId == essay.AuthorId)
                .FirstOrDefault();

            if (orgEssay == null)
            {
                this.Create(essay.AuthorId, essay.Title, essay.Content);
                return;
            }

            orgEssay.Title = essay.Title;
            orgEssay.Content = essay.Content;
            this.essays.Save();
        }
    }
}
