using System;
using System.Collections.Generic;
using System.Text;
using StudentManagement.Human;

namespace StudentManagement.Testing
{
    internal class StudentExample
    {
        public static void Example1(List<Student> students)
        {
            students.Add(new Student(2352608, "Huynh Minh Khoi", 21, "Male", "Computer Science"));
            students.Add(new Student(2352145, "Nguyen long", 21, "Male", "Computer Science"));
            students.Add(new Student(2214925, "Nguyen Lien Son", 22, "Others", "Chemical Engineering"));
            students.Add(new Student(2532104, "Tran Thi Ha", 19, "Female", "Mechanical Engineering"));
        }
    }
}
