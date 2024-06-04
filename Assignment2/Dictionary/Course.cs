using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class Course
    {
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public int NumberOfCredits { get; set; }

        public Course(string courseCode, string courseTitle, string courseDescription, int numberOfCredits)
        {
            CourseCode = courseCode;
            CourseTitle = courseTitle;
            CourseDescription = courseDescription;
            NumberOfCredits = numberOfCredits;
        }

        public override string ToString()
        {
            return $"Course Code: {CourseCode}, Title: {CourseTitle}, Description: {CourseDescription}, Credits: {NumberOfCredits}";
        }
    }
}
