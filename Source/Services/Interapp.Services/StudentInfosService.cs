namespace Interapp.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Models;
    using Data.Repositories;
    using System.Data.Entity;

    public class StudentInfosService : IStudentInfosService
    {
        private IRepository<StudentInfo> studentInfos;
        private IRepository<User> users;

        public StudentInfosService(IRepository<StudentInfo> studentInfos, IRepository<User> users)
        {
            this.studentInfos = studentInfos;
            this.users = users;
        }

        public void AddUniversityOfInterest(string studentId, University university)
        {
            var student = studentInfos
                .All()
                .Where(s => s.StudentId == studentId)
                .FirstOrDefault();

            student.UniversitiesOfInterest.Add(university);
            this.studentInfos.SaveChanges();
        }

        public void Create(string studentId)
        {
            var student = users
                .All()
                .Where(u => u.Id == studentId)
                .FirstOrDefault();

            student.StudentInfo = new StudentInfo();
            users.SaveChanges();
        }

        public void EnrollStudent(string studentId, int universityId, int majorId)
        {
            var student = studentInfos
                .All()
                .Where(s => s.StudentId == studentId)
                .FirstOrDefault();

            student.UniversityId = universityId;
            student.MajorId = majorId;
            studentInfos.SaveChanges();
        }

        public StudentInfo GetById(string id)
        {
            var student = this.studentInfos.All().Where(s => s.StudentId == id).FirstOrDefault();
            return student;
        }

        public IQueryable<StudentInfo> GetByMajor(int majorId)
        {
            return this.studentInfos.All().Where(s => s.MajorId == majorId);
        }

        public StudentInfo GetFullInfoById(string id)
        {
            var student = this.studentInfos
                .All()
                .Where(s => s.StudentId == id)
                .Include(s => s.Documents)
                .Include(s => s.UniversitiesOfInterest)
                .Include(s => s.Student)
                .Include(s => s.Essay)
                .Include(s => s.Scores)
                .Include(s => s.Applications)
                .Include(s => s.Major)
                .Include(s => s.University)
                .Include(s => s.Responses)
                .FirstOrDefault();
            return student;
        }

        public void Update(string studentId, StudentInfo info)
        {
            var student = studentInfos
                .All()
                .Where(s => s.StudentId == studentId)
                .FirstOrDefault();

            this.studentInfos.Update(info);
            this.studentInfos.SaveChanges();
        }
    }
}
