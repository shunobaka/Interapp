namespace Interapp.Services.Contracts
{
    using System.Linq;
    using Data.Models;

    public interface IStudentInfosService
    {
        IQueryable<StudentInfo> GetByMajor(int majorId);

        StudentInfo GetById(int id);

        void Update(string studentId, StudentInfo info);

        void AddUniversityOfInterest(University university);

        void EnrollStudent(string studentId, int universityId, int majorId);

        void Create(string studentId, int universityId, int majorId);
    }
}
