using System;
using StudentManagement.Human;
using StudentManagement.Resource;
using StudentManagement.Testing;


namespace StudentManagement
{
    class program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student> { };
            StudentExample.Example1(students);

            StudentService.mainHubStudent(students);
        }
    }
}


