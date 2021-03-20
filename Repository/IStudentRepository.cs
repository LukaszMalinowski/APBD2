using System.Collections.Generic;
using cwiczenia2_zen_s19743.Model;

namespace cwiczenia2_zen_s19743.Repository
{
    public interface IStudentRepository
    {
        List<Student> getAllStudents();
    }
}