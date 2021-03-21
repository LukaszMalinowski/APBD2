using System.Collections.Generic;
using cwiczenia2_zen_s19743.Model;

namespace cwiczenia2_zen_s19743.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();

        Student GetStudentByIndexNumber(string indexNumber);

        Student UpdateStudentByIndexNumber(string indexNumber, Student student);

        Student AddStudent(Student student);

        void DeleteStudentByIndexNumber(string indexNumber);
    }
}