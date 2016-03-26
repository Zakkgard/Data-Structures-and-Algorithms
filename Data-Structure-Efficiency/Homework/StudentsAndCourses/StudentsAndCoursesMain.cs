namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsAndCoursesMain
    {
        public static void Main()
        {
            var coursesStudents = new SortedDictionary<string, SortedSet<Student>>();

            for (int i = 0; i < 10; i++)
            {
                var input = Console.ReadLine().Split('|');
                var course = input[2].Trim();
                var firstName = input[0].Trim();
                var lastName = input[1].Trim();

                if (!coursesStudents.ContainsKey(course))
                {
                    coursesStudents.Add(course, new SortedSet<Student>());
                }

                coursesStudents[course].Add(new Student { FirstName = firstName, LastName = lastName });
            }

            foreach (var course in coursesStudents)
            {
                Console.WriteLine("{0}: {1}", course.Key, string.Join(", ", course.Value.Select(s => s.ToString()).ToList()));
            }
        }
    }
}
