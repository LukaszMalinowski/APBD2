using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using cwiczenia2_zen_s19743.Model;
using cwiczenia2_zen_s19743.Utils;

namespace cwiczenia2_zen_s19743.Repository
{
    public class StudentFileRepository : IStudentRepository
    {
        private const string DbFileName = "./Data/students.csv";
        
        public List<Student> GetAllStudents()
        {
            return GetStudentListFromFile();
        }

        public Student GetStudentByIndexNumber(string indexNumber)
        {
            List<Student> students = GetStudentListFromFile();
            
            Student first = students.FirstOrDefault(student => student.IndexNumber.Equals(indexNumber));
            
            return first;
        }

        public Student UpdateStudentByIndexNumber(string indexNumber, Student student)
        {
            List<Student> students = GetStudentListFromFile();

            if (!students.Any(student => student.IndexNumber.Equals(indexNumber)))
            {
                throw new Exception("Student not found!");
            }

            student.IndexNumber = indexNumber;
            
            UpdateStudentInFile(student);

            return student;
        }

        public Student AddStudent(Student student)
        {
            bool studentExist = StudentValidator.CheckIfStudentExist(student.IndexNumber, GetStudentListFromFile());
            bool studentHasNulls = StudentValidator.CheckIfStudentHasNullFields(student);

            if (studentExist)
            {
                throw new Exception("Student already exists!");
            }

            if (studentHasNulls)
            {
                throw new Exception("Student has null fields!");
            }

            AddStudentToFile(student);

            return student;
        }

        private List<Student> GetStudentListFromFile()
        {
            FileInfo fi = new FileInfo(DbFileName);
            var students = new List<Student>();
            StreamReader reader = new StreamReader(fi.OpenRead());
            
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var student = StudentParser.ParseStudent(line);
                students.Add(student);
            }
            reader.Close();
            reader.Dispose();

            return students;
        }

        private void UpdateStudentInFile(Student student)
        {
            string[] allLines = File.ReadAllLines(DbFileName);
            for (int i = 0; i < allLines.Length; i++)
            {
                if (allLines[i].Contains(student.IndexNumber))
                {
                    allLines[i] = student.ToString();
                }
            }
            File.WriteAllLines(DbFileName, allLines);
        }
        
        private void AddStudentToFile(Student student)
        {
            File.AppendAllText(DbFileName, Environment.NewLine + student);
        }
    }
}