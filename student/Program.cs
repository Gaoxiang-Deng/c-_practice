using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement
{
    public class Program
    {
        static List<Student> students = new List<Student>();

        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nStudent Management System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Show All Students");
                Console.WriteLine("3. Show Average Grades");
                Console.WriteLine("4. Find Top Student");
                Console.WriteLine("5. Find Lowest Student");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    if (choice < 1 || choice > 6)
                    {
                        Console.WriteLine("Invalid input, please enter a number between 1 and 6.");
                        continue;
                    }

                    if (choice == 6) break;

                    if (choice == 1) AddStudent();
                    else if (choice == 2) DisplayStudents();
                    else if (choice == 3) DisplayAverageGrades();
                    else if (choice == 4) FindTopStudent();
                    else if (choice == 5) FindLowestStudent();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, please enter a valid number.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
        }

        static void AddStudent()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Age: ");
            try
            {
                int age = int.Parse(Console.ReadLine());
                if (age <= 0)
                {
                    Console.WriteLine("Invalid age. Age must be a positive number.");
                    return;
                }

                Console.Write("Grades (space-separated): ");
                try
                {
                    string[] inputGrades = Console.ReadLine().Split();
                    double[] grades = new double[inputGrades.Length];
                    for (int i = 0; i < inputGrades.Length; i++)
                    {
                        grades[i] = double.Parse(inputGrades[i]);
                    }

                    students.Add(new Student(name, age, grades));
                    Console.WriteLine("Student added!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid grades. Please enter numbers separated by spaces.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input for age. Please enter a valid number.");
            }
        }

        static void DisplayStudents()
        {
            if (!students.Any())
            {
                Console.WriteLine("No students available.");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}, Age: {student.Age}, Grades: {string.Join(", ", student.Grades)}");
            }
        }

        static void DisplayAverageGrades()
        {
            if (!students.Any())
            {
                Console.WriteLine("No students available.");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}'s Average: {student.GetAverageGrade():F2}");
            }
        }

        static void FindTopStudent()
        {
            if (!students.Any())
            {
                Console.WriteLine("No students available.");
                return;
            }

            var topStudent = students.OrderByDescending(s => s.GetAverageGrade()).First();
            Console.WriteLine($"Top Student: {topStudent.Name}, Avg Grade: {topStudent.GetAverageGrade():F2}");
        }

        static void FindLowestStudent()
        {
            if (!students.Any())
            {
                Console.WriteLine("No students available.");
                return;
            }

            var lowestStudent = students.OrderBy(s => s.GetAverageGrade()).First();
            Console.WriteLine($"Lowest Student: {lowestStudent.Name}, Avg Grade: {lowestStudent.GetAverageGrade():F2}");
        }
    }
}
