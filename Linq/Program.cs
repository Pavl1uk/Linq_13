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
    public string Phone { get; set; }
    public List<int> Grades { get; set; }
    public string FacultyNumber { get; set; }

    public Student(string firstName, string lastName, int groupNumber, int age, string email, string phone, List<int> grades, string facultyNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        GroupNumber = groupNumber;
        Age = age;
        Email = email;
        Phone = phone;
        Grades = grades;
        FacultyNumber = facultyNumber;
    }
}

public class StudentSpecialty
{
    public string SpecialtyName { get; set; }
    public string FacultyNumber { get; set; }

    public StudentSpecialty(string specialtyName, string facultyNumber)
    {
        SpecialtyName = specialtyName;
        FacultyNumber = facultyNumber;
    }
}

public class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student("Andrew", "Gibson", 2, 21, "agibson@gmail.com", "0895223344", new List<int> { 3, 4, 5, 6 }, "203314"),
            new Student("Sara", "Mills", 1, 24, "smills@gmail.com", "02435521", new List<int> { 6, 6, 6, 5 }, "215314"),
            new Student("Craig", "Ellis", 1, 19, "cellis@cs.edu.gov", "+3592667710", new List<int> { 4, 2, 3, 4 }, "203814"),
            new Student("Steven", "Cole", 2, 35, "themachine@abv.bg", "3242133312", new List<int> { 5, 6, 5, 5 }, "203114"),
            new Student("Andrew", "Carter", 2, 15, "ac147@gmail.com", "+001234532", new List<int> { 5, 3, 4, 2 }, "203914")
        };

        List<StudentSpecialty> specialties = new List<StudentSpecialty>
        {
            new StudentSpecialty("Web Developer", "203314"),
            new StudentSpecialty("Web Developer", "203114"),
            new StudentSpecialty("PHP Developer", "203814"),
            new StudentSpecialty("PHP Developer", "203914"),
            new StudentSpecialty("QA Engineer", "203314"),
            new StudentSpecialty("Web Developer", "203914")
        };

        // Завдання 1: Students by Group
        var studentsByGroup = students
            .Where(s => s.GroupNumber == 2)
            .OrderBy(s => s.FirstName)
            .Select(s => $"{s.FirstName} {s.LastName}");
        Console.WriteLine("Завдання 1: Students by Group");
        Console.WriteLine(string.Join("\n", studentsByGroup));

        // Завдання 2: Students by First and Last Name
        var studentsByFirstLastName = students
            .Where(s => string.Compare(s.FirstName, s.LastName) < 0)
            .Select(s => $"{s.FirstName} {s.LastName}");
        Console.WriteLine("\nЗавдання 2: Students by First and Last Name");
        Console.WriteLine(string.Join("\n", studentsByFirstLastName));

        // Завдання 3: Students by Age
        var studentsByAge = students
            .Where(s => s.Age >= 18 && s.Age <= 24)
            .Select(s => $"{s.FirstName} {s.LastName} {s.Age}");
        Console.WriteLine("\nЗавдання 3: Students by Age");
        Console.WriteLine(string.Join("\n", studentsByAge));

        // Завдання 4: Sort Students
        var sortedStudents = students
            .OrderBy(s => s.LastName)
            .ThenByDescending(s => s.FirstName)
            .Select(s => $"{s.FirstName} {s.LastName}");
        Console.WriteLine("\nЗавдання 4: Sort Students");
        Console.WriteLine(string.Join("\n", sortedStudents));

        // Завдання 5: Filter Students by Email Domain
        var studentsByEmailDomain = students
            .Where(s => s.Email.EndsWith("@gmail.com"))
            .Select(s => $"{s.FirstName} {s.LastName}");
        Console.WriteLine("\nЗавдання 5: Filter Students by Email Domain");
        Console.WriteLine(string.Join("\n", studentsByEmailDomain));

        // Завдання 6: Filter Students by Phone
        var studentsByPhone = students
            .Where(s => s.Phone.StartsWith("02") || s.Phone.StartsWith("+3592"))
            .Select(s => $"{s.FirstName} {s.LastName}");
        Console.WriteLine("\nЗавдання 6: Filter Students by Phone");
        Console.WriteLine(string.Join("\n", studentsByPhone));

        // Завдання 7: Excellent Students
        var excellentStudents = students
            .Where(s => s.Grades.Contains(6))
            .Select(s => $"{s.FirstName} {s.LastName}");
        Console.WriteLine("\nЗавдання 7: Excellent Students");
        Console.WriteLine(string.Join("\n", excellentStudents));

        // Завдання 8: Weak Students
        var weakStudents = students
            .Where(s => s.Grades.Count(g => g <= 3) >= 2)
            .Select(s => $"{s.FirstName} {s.LastName}");
        Console.WriteLine("\nЗавдання 8: Weak Students");
        Console.WriteLine(string.Join("\n", weakStudents));

        // Завдання 9: Students Enrolled in 2014 or 2015
        var studentsEnrolled2014_2015 = students
            .Where(s => s.FacultyNumber.Substring(4, 2) == "14" || s.FacultyNumber.Substring(4, 2) == "15")
            .Select(s => $"{s.FacultyNumber}: {string.Join(", ", s.Grades)}");
        Console.WriteLine("\nЗавдання 9: Students Enrolled in 2014 or 2015");
        Console.WriteLine(string.Join("\n", studentsEnrolled2014_2015));

        // Завдання 10: Group by Group
        var groupedByGroup = students
            .GroupBy(s => s.GroupNumber)
            .OrderBy(g => g.Key)
            .Select(g => $"{g.Key} - {string.Join(", ", g.Select(s => s.FirstName + " " + s.LastName))}");
        Console.WriteLine("\nЗавдання 10: Group by Group");
        Console.WriteLine(string.Join("\n", groupedByGroup));

        // Завдання 11: Students Joined to Specialties
        var studentsWithSpecialties = specialties
            .Join(students, sp => sp.FacultyNumber, st => st.FacultyNumber, 
                  (sp, st) => new { st.FirstName, st.LastName, st.FacultyNumber, sp.SpecialtyName })
            .OrderBy(s => s.LastName)
            .ThenBy(s => s.FirstName)
            .Select(s => $"{s.FirstName} {s.LastName} {s.FacultyNumber} {s.SpecialtyName}");
        Console.WriteLine("\nЗавдання 11: Students Joined to Specialties");
        Console.WriteLine(string.Join("\n", studentsWithSpecialties));

        // Завдання 12: Office Stuff
        int n = 7;
        List<string> orders = new List<string>
        {
            "|SoftServe - 600 - paper|",
            "|Vivacom - 600 - pen|",
            "|XS - 20 - chair|",
            "|Vivacom - 200 - chair|",
            "|SoftServe - 40 - chair|",
            "|XS - 40 - chair|",
            "|SoftServe - 1 - printer|"
        };

        var companyOrders = orders
            .Select(order => order.Trim('|').Split(" - "))
            .GroupBy(o => o[0])
            .OrderBy(g => g.Key)
            .Select(g => $"{g.Key}: {string.Join(", ", g.GroupBy(p => p[2]).Select(p => $"{p.Key}-{p.Sum(s => int.Parse(s[1]))}"))}");
        Console.WriteLine("\nЗавдання 12: Office Stuff");
        Console.WriteLine(string.Join("\n", companyOrders));
    }
}
