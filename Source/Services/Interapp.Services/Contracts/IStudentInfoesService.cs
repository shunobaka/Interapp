namespace Interapp.Services.Contracts
{
    using Data.Models;

    public interface IStudentInfosService
    {
        StudentInfo GetById(int id);

        void Update(string studentId, StudentInfo info);

        void AddUniversityOfInterest(University university);

        void EnrollStudent(string studentId, int universityId, int majorId);

        void Create(string studentId, int universityId, int majorId);
    }
}
