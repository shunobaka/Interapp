namespace Interapp.Services.Contracts
{
    using System.Linq;
    using Common;
    using Data.Models;

    public interface IStudentInfosService
    {
        IQueryable<StudentInfo> GetByMajor(int majorId);

        StudentInfo GetById(string id);

        void Update(string studentId, StudentInfo info);

        void AddUniversityOfInterest(string studentId, int universityId);

        void EnrollStudent(string studentId, int universityId, int majorId);

        void Create(string studentId);

        StudentInfo GetFullInfoById(string id);

        IQueryable<University> GetUserUniversitiesWithDocuments(string studentId);

        IQueryable<University> GetUniversitiesOfInterest(string studentId);

        ApplicationEligibility IsEligibleToApply(StudentInfo student, University university);

        ApplicationEligibility IsEligibleToApply(string studentId, int universityId);

        StudentInfo GetByIdWithDocumentsAndScores(string id);
    }
}
