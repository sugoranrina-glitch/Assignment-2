using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment2
{
    class Student
    {
        public int studentID;
        public string name;
        public string course;
        public int grade;

        // Constructor
        public Student(int studentID, string name, string course, int grade)
        {
            this.studentID = studentID;
            this.name = name;
            this.course = course;
            this.grade = grade;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "students.txt";


            // TASK 1: CREATE & WRITE FILE

            List<Student> students = new List<Student>()
            {
                new Student(101, "Juan Cruz", "BSIT", 88),
                new Student(102, "Maria Santos", "BSCS", 90),
                new Student(103, "Ana Reyes", "BSIT", 75)
            };

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Student s in students)
                {
                    writer.WriteLine($"{s.studentID},{s.name},{s.course},{s.grade}");
                }
            }

            Console.WriteLine("students.txt file created and data written successfully.\n");

            // TASK 2: READ FILE & LINQ

            List<Student> studentList = File.ReadAllLines(filePath)
                .Select(line =>
                {
                    string[] data = line.Split(',');
                    return new Student(
                        int.Parse(data[0]),
                        data[1],
                        data[2],
                        int.Parse(data[3])
                    );
                })
                .ToList();

            // Students with Grade > 85
            Console.WriteLine("Students with Grade > 85");
            var highGrades = studentList
                .Where(s => s.grade > 85)
                .Select(s => $"{s.name} - {s.grade}");

            foreach (var s in highGrades)
                Console.WriteLine(s);

            Console.WriteLine();

            // Sorted by Grade (Descending)
            Console.WriteLine("Sorted by Grade (Descending)");
            var sorted = studentList
                .OrderByDescending(s => s.grade)
                .Select(s => $"{s.name} - {s.grade}");

            foreach (var s in sorted)
                Console.WriteLine(s);

            Console.WriteLine();

            // Average Grade
            double average = studentList.Average(s => s.grade);
            Console.WriteLine($"Average Grade: {average:F2}");

            Console.ReadLine();
        }
    }
}
