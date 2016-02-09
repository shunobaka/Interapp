namespace Interapp.Services
{
    using System.Linq;
    using Contracts;
    using Data.Models;
    using Data.Repositories;

    public class EssaysService : IEssaysService
    {
        private IRepository<Essay> essays;

        public EssaysService(IRepository<Essay> essays)
        {
            this.essays = essays;
        }

        public void Create(string studentId, string title, string content)
        {
            var essay = new Essay()
            {
                AuthorId = studentId,
                Title = title,
                Content = content
            };

            this.essays.Add(essay);
            this.essays.SaveChanges();
        }

        public void Delete(string studentId)
        {
            this.essays.Delete(studentId);
            this.essays.SaveChanges();
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
            this.essays.Update(essay);
            this.essays.SaveChanges();
        }
    }
}
