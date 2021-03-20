using System;
using System.Text;
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
        public string Email { get; set; }
        public string FatherFirstName { get; set; }
        public string MotherFirstName { get; set; }

        public Student(string firstName, string lastName, string indexNumber, DateTime dateOfBirth, string major, string program, string email, string fatherFirstName, string motherFirstName)
        {
            FirstName = firstName;
            LastName = lastName;
            IndexNumber = indexNumber;
            DateOfBirth = dateOfBirth;
            Major = major;
            Program = program;
            Email = email;
            FatherFirstName = fatherFirstName;
            MotherFirstName = motherFirstName;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(FirstName);
            stringBuilder.Append(',');
            stringBuilder.Append(LastName);
            stringBuilder.Append(',');
            stringBuilder.Append(IndexNumber);
            stringBuilder.Append(',');
            stringBuilder.Append(DateOfBirth.Month + "/" + DateOfBirth.Day + "/" + DateOfBirth.Year);
            stringBuilder.Append(',');
            stringBuilder.Append(Major);
            stringBuilder.Append(',');
            stringBuilder.Append(Program);
            stringBuilder.Append(',');
            stringBuilder.Append(Email);
            stringBuilder.Append(',');
            stringBuilder.Append(FatherFirstName);
            stringBuilder.Append(',');
            stringBuilder.Append(MotherFirstName);
            return stringBuilder.ToString();
        }
    }
}