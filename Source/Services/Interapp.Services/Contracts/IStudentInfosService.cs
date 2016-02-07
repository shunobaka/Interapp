namespace Interapp.Services.Contracts
{
    using System.Linq;
    using Data.Models;

    public interface IStudentInfosService
    {
        IQueryable<StudentInfo> GetByMajor(int majorId);

        StudentInfo GetById(string id);

        void Update(string studentId, StudentInfo info);

        void AddUniversityOfInterest(string studentId, University university);

        void EnrollStudent(string studentId, int universityId, int majorId);

        void Create(string studentId);

        StudentInfo GetFullInfoById(string id);
    }
}
