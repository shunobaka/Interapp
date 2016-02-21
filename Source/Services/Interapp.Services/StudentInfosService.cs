namespace Interapp.Services
{
    using System.Data.Entity;
    using System.Linq;
    using Common;
    using Contracts;
    using Data.Common;
    using Data.Models;

    public class StudentInfosService : IStudentInfosService
    {
        private IDbRepository<StudentInfo> studentInfos;
        private IDbRepository<User> users;
        private IDbRepository<University> universities;

        public StudentInfosService(IDbRepository<StudentInfo> studentInfos, IDbRepository<User> users, IDbRepository<University> universities)
        {
            this.studentInfos = studentInfos;
            this.users = users;
            this.universities = universities;
        }

        public void AddUniversityOfInterest(string studentId, int universityId)
        {
            var student = this.studentInfos
                .All()
                .Where(s => s.StudentId == studentId)
                .FirstOrDefault();

            var university = this.universities
                .All()
                .Where(u => u.Id == universityId)
                .FirstOrDefault();

            this.universities.Detach(university);
            student.UniversitiesOfInterest.Add(university);
            this.studentInfos.Attach(university);
            this.studentInfos.SaveChanges();
        }

        public void Create(string studentId)
        {
            var student = this.users
                .All()
                .Where(u => u.Id == studentId)
                .FirstOrDefault();

            student.StudentInfo = new StudentInfo();
            this.users.Save();
        }

        public void EnrollStudent(string studentId, int universityId, int majorId)
        {
            var student = this.studentInfos
                .All()
                .Where(s => s.StudentId == studentId)
                .FirstOrDefault();

            student.UniversityId = universityId;
            student.MajorId = majorId;
            this.studentInfos.Save();
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

            if (student != null)
            {
                student.MajorId = info.MajorId;
                student.UniversityId = info.UniversityId;

                this.studentInfos.Save();
            }

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

        public ApplicationEligibility IsEligibleToApply(StudentInfo student, University university)
        {
            var eligibilityResult = new ApplicationEligibility();
            var totalSat = student.Scores.SatCRResult + student.Scores.SatMathResult + student.Scores.SatWritingResult;

            if (totalSat < university.RequiredSAT)
            {
                eligibilityResult.Message = "You don't meet the SAT score requirement.";
                return eligibilityResult;
            }

            if (student.Scores.CambridgeLevel < university.RequiredCambridgeLevel)
            {
                eligibilityResult.Message = "You don't have the necessary Cambridge Certificate level.";
                return eligibilityResult;
            }
            else if (student.Scores.CambridgeLevel == university.RequiredCambridgeLevel)
            {
                if (student.Scores.CambridgeResult < university.RequiredCambridgeScore)
                {
                    eligibilityResult.Message = "You don't have the necessary Cambridge Certificate result.";
                    return eligibilityResult;
                }
            }

            if (student.Scores.ToeflType == Interapp.Common.Enums.ToeflType.IBT)
            {
                if (student.Scores.ToeflResult < university.RequiredIBTToefl)
                {
                    eligibilityResult.Message = "You don't meet the TOEFL IBT score requirement.";
                    return eligibilityResult;
                }
            }
            else
            {
                if (student.Scores.ToeflResult < university.RequiredPBTToefl)
                {
                    eligibilityResult.Message = "You don't meet the TOEFL PBT score requirement.";
                    return eligibilityResult;
                }
            }

            foreach (var document in university.DocumentRequirements)
            {
                if (!student.Documents.Any(d => d.Name == document.Name))
                {
                    eligibilityResult.Message = "You don't have all the necessary documents.";
                    return eligibilityResult;
                }
            }

            eligibilityResult.Message = "You are eligible to apply for the university.";
            eligibilityResult.IsEligible = true;
            return eligibilityResult;
        }

        public StudentInfo GetByIdWithDocumentsAndScores(string id)
        {
            return this.studentInfos
                .All()
                .Where(s => s.StudentId == id)
                .Include(s => s.Documents)
                .Include(s => s.Scores)
                .FirstOrDefault();
        }

        public ApplicationEligibility IsEligibleToApply(string studentId, int universityId)
        {
            var student = this.studentInfos.GetById(studentId);
            var university = this.universities.GetById(universityId);

            return this.IsEligibleToApply(student, university);
        }
    }
}
