﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using cwiczenia2_zen_s19743.Model;
using cwiczenia2_zen_s19743.Utils;

namespace cwiczenia2_zen_s19743.Repository
{
    public class StudentFileRepository : IStudentRepository
    {
        public List<Student> getAllStudents()
        {
            return getStudentListFromFile();
        }

        public Student getStudentByIndexNumber(string indexNumber)
        {
            List<Student> students = getStudentListFromFile();
            
            Student first = students.FirstOrDefault(student => student.IndexNumber.Equals(indexNumber));
            
            return first;
        }

        private List<Student> getStudentListFromFile()
        {
            FileInfo fi = new FileInfo("./Data/students.csv");
            var students = new List<Student>();
            StreamReader reader = new StreamReader(fi.OpenRead());
            
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var student = StudentParser.parseStudent(line);
                students.Add(student);
            }
            reader.Close();
            reader.Dispose();

            return students;
        }
    }
}