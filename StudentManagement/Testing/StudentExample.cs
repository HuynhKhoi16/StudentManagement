using System;
using System.Collections.Generic;
using System.Text;
using StudentManagement.Human;
using StudentManagement.Resource;
using Microsoft.Data.SqlClient;

namespace StudentManagement.Testing
{
    class StudentExample
    {
        public static void Example1()
        {

            Student student = new Student(2352608, "Huynh Minh Khoi", 21, "Male", "Computer Science");
            
            StudentService.AddToDatabase(student);
            student = new Student(2352145, "Nguyen long", 21, "Male", "Computer Science");
            
            StudentService.AddToDatabase(student);
            student = new Student(2214925, "Nguyen Lien Son", 22, "Others", "Chemical Engineering");
            
            StudentService.AddToDatabase(student);
            student = new Student(2532104, "Tran Thi Ha", 19, "Female", "Mechanical Engineering");
            
            StudentService.AddToDatabase(student);



            
        }
    }
}
