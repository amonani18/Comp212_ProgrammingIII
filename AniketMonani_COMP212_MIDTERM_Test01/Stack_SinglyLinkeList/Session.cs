using System;
/*
 * Student Name - Aniket Monani
 * Student ID - 301422485
*/
namespace Stack_SinglyLinkedList
{
    // Model class for Session data
    public class Session : IEquatable<Session>
    {
        public string ID { get; set; }
        public string Semester { get; set; }
        public string CourseTitle { get; set; }
        public int Enrollment { get; set; }

        public Session(string id, string semester, string courseTitle, int enrollment)
        {
            ID = id;
            Semester = semester;
            CourseTitle = courseTitle;
            Enrollment = enrollment;
        }

        // Override ToString for easy printing
        public override string ToString()
        {
            return $"{ID}, {Semester}, {CourseTitle}, {Enrollment}";
        }

        // Implement Equals method for comparison
        public bool Equals(Session other)
        {
            if (other == null) return false;
            return ID == other.ID &&
                   Semester == other.Semester &&
                   CourseTitle == other.CourseTitle &&
                   Enrollment == other.Enrollment;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is Session otherSession)
                return Equals(otherSession);
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Semester, CourseTitle, Enrollment);
        }
    }
}
