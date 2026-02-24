using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "students.txt";

            List<Student> students = new List<Student>
            {
                new Student(101, "John", "BSIT", 89),
                new Student(102, "Maria", "BSCS", 92),
                new Student(103, "Paul", "BSIT", 75),
                new Student(104, "Ana", "BSCS", 85),
                new Student(105, "Mark", "BSIT", 90)
            };

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var s in students)
                {
                    writer.WriteLine($"{s.studentID},{s.name},{s.course},{s.grade}");
                }
            }

            Console.WriteLine("students.txt file created and data written.\n");

            var studentList = File.ReadAllLines(filePath)
                .Select(line =>
                {
                    var data = line.Split(',');
                    return new Student(
                        int.Parse(data[0]),
                        data[1],
                        data[2],
                        int.Parse(data[3])
                    );
                }).ToList();

            Console.WriteLine("Students with Grade > 85");
            var highGrades = studentList.Where(s => s.grade > 85);
            foreach (var s in highGrades)
                Console.WriteLine($"{s.name} - {s.grade}");

            Console.WriteLine("\nSorted by Grade (Descending)");
            var sorted = studentList.OrderByDescending(s => s.grade);
            foreach (var s in sorted)
                Console.WriteLine($"{s.name} - {s.grade}");

            Console.WriteLine("\nStudent Names");
            var names = studentList.Select(s => s.name);
            foreach (var n in names)
                Console.WriteLine(n);

            Console.WriteLine($"\nAverage Grade: {studentList.Average(s => s.grade):F2}");
        }
    }
}
