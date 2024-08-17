using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Course> courseDictionary = new Dictionary<string, Course>();

            while (true)
            {
                Console.WriteLine("\nCourse Management System");
                Console.WriteLine("1. Add a new course");
                Console.WriteLine("2. Access a course");
                Console.WriteLine("3. Display all courses");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddCourse(courseDictionary);
                        break;
                    case "2":
                        AccessCourse(courseDictionary);
                        break;
                    case "3":
                        DisplayAllCourses(courseDictionary);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        static void AddCourse(Dictionary<string, Course> courseDict)
        {
            Console.Write("Enter Course Code: ");
            string courseCode = Console.ReadLine();

            Console.Write("Enter Course Title: ");
            string courseTitle = Console.ReadLine();

            Console.Write("Enter Course Description: ");
            string courseDescription = Console.ReadLine();

            Console.Write("Enter Number of Credits: ");
            int numberOfCredits;
            while (!int.TryParse(Console.ReadLine(), out numberOfCredits))
            {
                Console.Write("Invalid input. Please enter a valid number for credits: ");
            }

            if (!courseDict.ContainsKey(courseCode))
            {
                courseDict[courseCode] = new Course(courseCode, courseTitle, courseDescription, numberOfCredits);
                Console.WriteLine($"Course {courseCode} added successfully.");
            }
            else
            {
                Console.WriteLine($"Course {courseCode} already exists.");
            }
        }

        static void AccessCourse(Dictionary<string, Course> courseDict)
        {
            Console.Write("Enter Course Code to access: ");
            string courseCode = Console.ReadLine();

            if (courseDict.TryGetValue(courseCode, out Course course))
            {
                Console.WriteLine("Course found: " + course);
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }

        static void DisplayAllCourses(Dictionary<string, Course> courseDict)
        {
            Console.WriteLine("All courses in the system:");
            foreach (var course in courseDict.Values)
            {
                Console.WriteLine(course);
            }
        }
    }
}