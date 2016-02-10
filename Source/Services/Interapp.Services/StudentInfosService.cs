﻿namespace Interapp.Services
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Contracts;
    using Data.Models;
    using Data.Repositories;
    using Data;

    public class StudentInfosService : IStudentInfosService
    {
        private IRepository<StudentInfo> studentInfos;
        private IRepository<User> users;
        private IRepository<University> universities;

        public StudentInfosService(IRepository<StudentInfo> studentInfos, IRepository<User> users, IRepository<University> universities)
        {
            this.studentInfos = studentInfos;
            this.users = users;
            this.universities = universities;
        }

        public void AddUniversityOfInterest(string studentId, int universityId)
        {
            // TEMPORARY WORK-AROUND
            // TODO: Fix 
            var db = new InterappDbContext();
            var student = db.StudentInfos
                .Where(s => s.StudentId == studentId)
                .FirstOrDefault();

            var university = db.Universities
                .Where(u => u.Id == universityId)
                .FirstOrDefault();
            
            student.UniversitiesOfInterest.Add(university);
            db.SaveChanges();
        }

        public void Create(string studentId)
        {
            var student = this.users
                .All()
                .Where(u => u.Id == studentId)
                .FirstOrDefault();

            student.StudentInfo = new StudentInfo();
            this.users.SaveChanges();
        }

        public void EnrollStudent(string studentId, int universityId, int majorId)
        {
            var student = this.studentInfos
                .All()
                .Where(s => s.StudentId == studentId)
                .FirstOrDefault();

            student.UniversityId = universityId;
            student.MajorId = majorId;
            this.studentInfos.SaveChanges();
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
                .Include("Documents")
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

        public IQueryable<University> GetUserUniversitiesWithDocuments(string studentId)
        {
            var student = this.studentInfos
                .All()
                .Include("Documents")
                .Include("Universities")
                .Where(s => s.StudentId == studentId)
                .FirstOrDefault();

            if (student == null)
            {
                return null;
            }

            return student.UniversitiesOfInterest.AsQueryable();
        }

        public void Update(string studentId, StudentInfo info)
        {
            var student = this.studentInfos
                .All()
                .Where(s => s.StudentId == studentId)
                .FirstOrDefault();

            this.studentInfos.Update(info);
            this.studentInfos.SaveChanges();
            //// TODO: Fix maybe?
        }

        public IQueryable<University> GetUniversitiesOfInterest(string studentId)
        {
            var student = this.studentInfos
                .All()
                .Where(s => s.StudentId == studentId)
                .Include(s => s.UniversitiesOfInterest)
                .FirstOrDefault();

            return student.UniversitiesOfInterest.AsQueryable();
        }
    }
}
