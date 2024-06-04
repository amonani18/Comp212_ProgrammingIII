using Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        // Create a dictionary to store courses
        Dictionary<string, Course> courseDictionary = new Dictionary<string, Course>();

        // Add some courses
        AddCourse(courseDictionary, new Course("CS101", "Introduction to Computer Science", "Basic concepts of computer science", 4));
        AddCourse(courseDictionary, new Course("ENG102", "English Literature", "Overview of English literature", 3));
        AddCourse(courseDictionary, new Course("MATH201", "Calculus I", "Introduction to Calculus", 4));

        // Access a course
        AccessCourse(courseDictionary, "CS101");

        // Display all courses
        DisplayAllCourses(courseDictionary);
    }

    static void AddCourse(Dictionary<string, Course> courseDict, Course course)
    {
        if (!courseDict.ContainsKey(course.CourseCode))
        {
            courseDict[course.CourseCode] = course;
            Console.WriteLine($"Course {course.CourseCode} added successfully.");
        }
        else
        {
            Console.WriteLine($"Course {course.CourseCode} already exists.");
        }
    }

    static void AccessCourse(Dictionary<string, Course> courseDict, string courseCode)
    {
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
