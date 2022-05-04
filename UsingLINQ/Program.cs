using System;
using System.Collections.Generic;
using System.Linq;

namespace UsingLINQ
{
    internal class Program
    {
        private static List<Student> students;
        static void Main(string[] args)
        {
            // Language Integrated Query

            students = new List<Student>
            {
                new Student {Id=1,Name="Buse",LastName="Koca",Age=27,AvarageScore=85.4},
                new Student {Id=2,Name="Tuba",LastName="Bıyık",Age=28,AvarageScore=90.3},
                new Student {Id=3,Name="Setu",LastName="Ram",Age=30,AvarageScore=53.5}
            };
        }

        private static void BasicLinq()
        {
            //var anonym = new { Name = "xxx", IsActive = false };
            ////anonym.Name = "yyy"; // readonly error!
            //var name = anonym.Name; 

            // TSQL
            var scoreBigThan70 = from st in students
                                 where st.AvarageScore >= 70
                                 orderby st.AvarageScore
                                 select st;
            // LINQ
            var alternativeBigThan70 = students.Where(s => s.AvarageScore>=70)
                                               .OrderByDescending(x => x.AvarageScore)
                                               .ToList();
            alternativeBigThan70.ForEach(s =>
                Console.WriteLine($"{s.Name} {s.LastName} {s.Age} {s.AvarageScore}"));
        }

        private static double GetAvarageScore()
        {
            return students.Average(x => x.AvarageScore);
        }

        private static double GetMaxAvarageScore()
        {
            return students.Max(x => x.AvarageScore);
        }
    }
}
