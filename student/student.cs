using System;
using System.Linq;

public struct Student
{
    public string Name;        // Student's name
    public int Age;            // Student's age
    public double[] Grades;    // Student's grades (double for precision)

    public Student(string name, int age, double[] grades)
    {
        Name = name;
        Age = age;
        Grades = grades;
    }

    // Calculate the average grade
    public double GetAverageGrade()
    {
        return Grades.Length > 0 ? Grades.Average() : 0.0;
    }
}