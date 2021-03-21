using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using cwiczenia2_zen_s19743.Model;
using cwiczenia2_zen_s19743.Utils;
using Microsoft.AspNetCore.Http;

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
            student.IndexNumber ??= indexNumber;
            
            if (!StudentValidator.StudentExist(indexNumber, GetStudentListFromFile()))
            {
                throw new Exception("Student not found!");
            }
            
            if (StudentValidator.StudentHasNullFields(student))
            {
                throw new BadHttpRequestException("Student has null fields!");
            }

            student.IndexNumber = indexNumber;
            
            UpdateStudentInFile(student);

            return student;
        }

        public Student AddStudent(Student student)
        {
            if (StudentValidator.StudentExist(student.IndexNumber, GetStudentListFromFile()))
            {
                throw new Exception("Student already exists!");
            }

            if (StudentValidator.StudentHasNullFields(student))
            {
                throw new BadHttpRequestException("Student has null fields!");
            }

            AddStudentToFile(student);

            return student;
        }

        public void DeleteStudentByIndexNumber(string indexNumber)
        {
            if (!StudentValidator.StudentExist(indexNumber, GetStudentListFromFile()))
            {
                throw new Exception("Student doesn't exist!");
            }
            
            DeleteStudentFromFile(indexNumber);
        }

        private List<Student> GetStudentListFromFile()
        {
            return File.ReadAllLines(DbFileName)
                .Select(StudentParser.ParseStudent)
                .ToList();
        }

        private void UpdateStudentInFile(Student updatedStudent)
        {
            var lines = File.ReadAllLines(DbFileName)
                .Select(StudentParser.ParseStudent)
                .Select(student => student.IndexNumber.Equals(updatedStudent.IndexNumber) ? updatedStudent : student)
                .Select(student => student.ToString())
                .ToArray();
            
            File.WriteAllLines(DbFileName, lines);
        }
        
        private void AddStudentToFile(Student student)
        {
            File.AppendAllText(DbFileName, Environment.NewLine + student);
        }

        private void DeleteStudentFromFile(string indexNumber)
        {
            var lines = File.ReadAllLines(DbFileName)
                .Select(StudentParser.ParseStudent)
                .Where(student => !student.IndexNumber.Equals(indexNumber))
                .Select(student => student.ToString())
                .ToArray();
            
            File.WriteAllText(DbFileName, string.Join(Environment.NewLine, lines));
        }
    }
}