namespace StudentsAndCourses
{
    using System;

    public class Student : IComparable<Student>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(Student other)
        {
            return this.LastName.CompareTo(other.LastName);
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
