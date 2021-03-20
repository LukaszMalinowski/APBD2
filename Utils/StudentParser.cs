using System;
using System.Globalization;
using cwiczenia2_zen_s19743.Model;

namespace cwiczenia2_zen_s19743.Utils
{
    public class StudentParser
    {
        public static Student parseStudent(string line)
        {
            var split = line.Split(",");
            if (split.Length != 9)
                throw new Exception("Error while parsing Student from db");

            return new Student(split[0],
                split[1],
                split[2],
                parseDate(split[3]),
                split[4],
                split[5],
                split[6],
                split[7]);
        }

        private static DateTime parseDate(string date)
        {
            var split = date.Split(@"/");

            if(split.Length != 3)
                throw new Exception("Error while parsing date");

            int year = Int32.Parse(split[2]);            
            int day = Int32.Parse(split[1]);            
            int month = Int32.Parse(split[0]);            
            
            return new DateTime(year, month, day);
        }
    }
}