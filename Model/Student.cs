using System;
using Microsoft.VisualBasic;

namespace cwiczenia2_zen_s19743.Model
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IndexNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Major { get; set; }
        public string Program { get; set; }
        public string FatherFirstName { get; set; }
        public string MotherFirstName { get; set; }

        public Student(string firstName, string lastName, string indexNumber, DateTime dateOfBirth, string major, string program, string fatherFirstName, string motherFirstName)
        {
            FirstName = firstName;
            LastName = lastName;
            IndexNumber = indexNumber;
            DateOfBirth = dateOfBirth;
            Major = major;
            Program = program;
            FatherFirstName = fatherFirstName;
            MotherFirstName = motherFirstName;
        }
    }
}