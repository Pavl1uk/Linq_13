using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int GroupNumber { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<int> Grades { get; set; }
    public string FacultyNumber { get; set; }

    public Student(string firstName, string lastName, int groupNumber, int age, string email, string phoneNumber, List<int> grades, string facultyNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        GroupNumber = groupNumber;
        Age = age;
        Email = email;
        PhoneNumber = phoneNumber;
        Grades = grades;
        FacultyNumber = facultyNumber;
    }
}

public class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student("Sara", "Mills", 1, 24, "smills@gmail.com", "02435521", new List<int>{6, 6, 6, 5}, "554214"),
            new Student("Andrew", "Gibson", 2, 21, "agibson@abv.bg", "0895223344", new List<int>{3, 4, 5, 6}, "653215"),
            new Student("Craig", "Ellis", 1, 19, "cellis@cs.edu.gov", "+3592667710", new List<int>{4, 2, 3, 4}, "156212"),
            new Student("Steven", "Cole", 2, 35, "themachine@abv.bg", "3242133312", new List<int>{5, 6, 5, 5}, "324413"),
            new Student("Andrew", "Carter", 2, 15, "ac147@gmail.com", "+001234532", new List<int>{5, 3, 4, 2}, "134014")
        };

        // Завдання 1: Students by Group
        Console.WriteLine("Завдання 1: Students by Group");
        var studentsByGroup = students
            .Where(s => s.GroupNumber == 2)
            .OrderBy(s => s.LastName);
        foreach (var student in studentsByGroup)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }

        // Завдання 2: Students by First and Last Name
        Console.WriteLine("\nЗавдання 2: Students by First and Last Name");
        var studentsByNameOrder = students
            .Where(s => string.Compare(s.FirstName, s.LastName) < 0);
        foreach (var student in studentsByNameOrder)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }

        // Завдання 3: Students by Age
        Console.WriteLine("\nЗавдання 3: Students by Age");
        var studentsByAge = students
            .Where(s => s.Age >= 18 && s.Age <= 24);
        foreach (var student in studentsByAge)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName} {student.Age}");
        }

        // Завдання 4: Sort Students
        Console.WriteLine("\nЗавдання 4: Sort Students");
        var sortedStudents = students
            .OrderBy(s => s.LastName)
            .ThenByDescending(s => s.FirstName);
        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }

        // Завдання 5: Filter Students by Email Domain
        Console.WriteLine("\nЗавдання 5: Filter Students by Email Domain");
        var gmailStudents = students
            .Where(s => s.Email.EndsWith("@gmail.com"));
        foreach (var student in gmailStudents)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }

        // Завдання 6: Filter Students by Phone
        Console.WriteLine("\nЗавдання 6: Filter Students by Phone");
        var sofiaPhoneStudents = students
            .Where(s => s.PhoneNumber.StartsWith("02") || s.PhoneNumber.StartsWith("+3592"));
        foreach (var student in sofiaPhoneStudents)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }

        // Завдання 7: Excellent Students
        Console.WriteLine("\nЗавдання 7: Excellent Students");
        var excellentStudents = students
            .Where(s => s.Grades.Contains(6));
        foreach (var student in excellentStudents)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }

        // Завдання 8: Weak Students
        Console.WriteLine("\nЗавдання 8: Weak Students");
        var weakStudents = students
            .Where(s => s.Grades.Count(g => g <= 3) >= 2);
        foreach (var student in weakStudents)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }

        // Завдання 9: Students Enrolled in 2014 or 2015
        Console.WriteLine("\nЗавдання 9: Students Enrolled in 2014 or 2015");
        var enrolledStudents = students
            .Where(s => s.FacultyNumber.Substring(4, 2) == "14" || s.FacultyNumber.Substring(4, 2) == "15")
            .Select(s => new { s.FirstName, s.LastName, s.Grades });
        foreach (var student in enrolledStudents)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}: {string.Join(" ", student.Grades)}");
        }
    }
}
