using Microsoft.EntityFrameworkCore;
using StudentSystem.DATA;
using System;
using System.Linq;

namespace StudentSystem.Model
{
  
    public static class Bonus
    {

        public static void AddStudent(ApplicationDbContext db, string studentName, DateTime registeredOn, string birthdayInput=null)
        {          
            DateTime? birthday = null;

            if (birthdayInput !=null)
            {
                birthday = DateTime.Parse(birthdayInput);
            }

            var student = new Student
            {
                Name = studentName,
                RegisteredOn = registeredOn,
                Birthday = birthday
            };

            db.Students.Add(student);
            db.SaveChanges();
            
        }

        public static void AddCourse(ApplicationDbContext db, string courseName, DateTime startDate, DateTime endDate, decimal price)
        {           
            var course = new Course
            {
                Name = courseName,
                StartDate = startDate,
                EndDate = endDate,
                Price = price
            };

            db.Courses.Add(course);
            db.SaveChanges();            
        }

        public static string ViewStudents(ApplicationDbContext db)
        {
            var students = db.Students.ToList();
            if (students !=null)
            {
                Console.WriteLine("Students:");
                foreach (var student in students)
                {
                    Console.WriteLine($"- {student.Name} (Registered On: {student.RegisteredOn}, Birthday: {student.Birthday?.ToShortDateString() ?? "N/A"})");
                }
                return "Students found";
            }
            else
            {
                return "No students found.";
            }
        }

        public static string ViewCourses(ApplicationDbContext db)
        {
            var courses = db.Courses.ToList();
            if (courses !=null)
            {
                Console.WriteLine("Courses:");
                foreach (var course in courses)
                {
                    Console.WriteLine($"- {course.Name} (Start: {course.StartDate}, End: {course.EndDate}, Price: {course.Price})");
                }
                return "";
            }
            else
            {
                return "No courses found.";
            }
        }

    }
}



