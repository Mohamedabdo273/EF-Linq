using StudentSystem.DATA;
using StudentSystem.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //var students = new List<Student> {
            //    new Student { Name = "Mohamed Abdo", RegisteredOn = DateTime.Now, Birthday = new DateTime(2002, 2, 14) },
            //     new Student { Name = "Sara Ali", RegisteredOn = DateTime.Now }
            //    };
            //    db.Students.AddRange(students);
            //    db.SaveChanges();

            //List<Course> courses = new List<Course> {

            //new Course { Name = "C# Basics", StartDate = DateTime.Now.AddMonths(-2), EndDate = DateTime.Now.AddMonths(1), Price = 199.99M },
            //new Course { Name = "Advanced Databases", StartDate = DateTime.Now.AddMonths(-4), EndDate = DateTime.Now.AddMonths(2), Price = 299.99M }
            //};
            //var context2 = new ValidationContext(courses);
            //var errors2 = new List<ValidationResult>();

            //    db.Courses.AddRange(courses);
            //db.SaveChanges();

            //List<Resource> resources = new List<Resource>
            //{
            // new Resource { Name = "C# Intro", Url = "https://example.com/csharp-intro", ResourceType = ResourceType.Video, CourseId = 1 },
            //new Resource { Name = "DB Guide", Url = "https://example.com/db-guide", ResourceType = ResourceType.Document, CourseId = 2 }
            //};

            //    db.Resources.AddRange(resources);
            //    db.SaveChanges();

            //List<Homework> homeworks = new List<Homework>
            //{
            // new Homework { Content = "https://example.com/hw1", ContentType = ContentType.Pdf, SubmissionTime = DateTime.Now, StudentId = 1, CourseId = 1 }
            //};
            //var context4 = new ValidationContext(homeworks);
            //var errors4 = new List<ValidationResult>();

            //    db.Homeworks.AddRange(homeworks);
            //    db.SaveChanges();

            ////////////////////////////////
            try
            {
                while (true)
                {

                    Console.WriteLine("\nWhat would you like to do?");
                    Console.WriteLine("1. Add a new student");
                    Console.WriteLine("2. Add a new course");
                    Console.WriteLine("3. View all students");
                    Console.WriteLine("4. View all courses");
                    Console.WriteLine("5. Exit");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter student name: ");
                            string studentName = Console.ReadLine();
                            Console.Write("Enter registered on date (yyyy-mm-dd): ");
                            DateTime registeredOn = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter birthday (yyyy-mm-dd) or press Enter to skip: ");
                            string birthdayInput = Console.ReadLine();
                            Bonus.AddStudent(db, studentName, registeredOn, birthdayInput);
                            Console.WriteLine("Student added successfully!");
                            break;

                        case "2":
                            Console.Write("Enter course name: ");
                            string courseName = Console.ReadLine();
                            Console.Write("Enter course start date (yyyy-mm-dd): ");
                            DateTime startDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter course end date (yyyy-mm-dd): ");
                            DateTime endDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter course price: ");
                            decimal price = decimal.Parse(Console.ReadLine());
                            Bonus.AddCourse(db,courseName, startDate, endDate, price);
                            Console.WriteLine("Course added successfully!");
                            break;

                        case "3":
                            Bonus.ViewStudents(db);
                            break;

                        case "4":
                            Bonus.ViewCourses(db);
                            break;

                        case "5":
                            Console.WriteLine("Exiting...");
                            return;

                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }

                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid format. Please try again.");


            }


        }
    }
    
}
