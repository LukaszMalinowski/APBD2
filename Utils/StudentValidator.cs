using System;
using System.Collections.Generic;
using System.Linq;
using cwiczenia2_zen_s19743.Model;

namespace cwiczenia2_zen_s19743.Utils
{
    public static class StudentValidator
    {
        public static bool StudentExist(string indexNumber, List<Student> studentList)
        {
            return studentList.Any(student => student.IndexNumber.Equals(indexNumber));
        }

        public static bool StudentHasNullFields(Student student)
        {
            return student.GetType().GetProperties().Any(info => info.GetValue(student) == null);
        }
    }
}