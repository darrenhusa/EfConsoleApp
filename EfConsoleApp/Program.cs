using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EfConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                //var melissa = new Student()
                //{
                //    Id = 100,
                //    Firstname = "Melissa",
                //    Lastname = "Paridisso"
                //};
                //var drew = new Student()
                //{
                //    Id = 200,
                //    Firstname = "Andrew",
                //    Lastname = "O"
                //};

                //context.Students.AddRange(melissa, drew);
                ////context.SaveChanges();

                //var cis225 = new Course()
                //{
                //    Id = 1000,
                //    Dept = "CIS",
                //    CourseNumber = 225,
                //    Section = "X",
                //    Description = "Business Microcomputer Applications"
                //};
                //var cis350 = new Course()
                //{
                //    Id = 1200,
                //    Dept = "CIS",
                //    CourseNumber = 350,
                //    Section = "X",
                //    Description = "Distributed Applications I"
                //};

                //context.Courses.AddRange(cis225, cis350);
                //context.SaveChanges();

                //var enrollment1a = new StudentCourse()
                //{   
                //    StudentId = 100,
                //    CourseId = 1000
                //};

                //var enrollment1b = new StudentCourse()
                //{
                //    StudentId = 100,
                //    CourseId = 1200
                //};

                //var enrollment2a = new StudentCourse()
                //{
                //    StudentId = 200,
                //    CourseId = 1200
                //};

                //context.StudentCourses.AddRange(enrollment1a, enrollment1b, enrollment2a);
                //context.SaveChanges();

                var students = context.Students;

                foreach (var s in students)
                {
                    Console.WriteLine($"{s.Lastname}, {s.Firstname}");
                }

                var enrollments = context.Students
                    .Where(s => s.Firstname == "Melissa")
                    .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                    .FirstOrDefault();
                
                Console.WriteLine($"ID: {enrollments.Id} {enrollments.Lastname}, {enrollments.Firstname}");

                foreach (var sc in enrollments.StudentCourses)
                {
                    Console.WriteLine($"{sc.Course.Dept} {sc.Course.CourseNumber} {sc.Course.Section} - {sc.Course.Description}");
                }

                Console.WriteLine("End program.");
            }
        }
    }
}
