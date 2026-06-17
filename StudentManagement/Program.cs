using System;
using StudentManagement.Human;
using StudentManagement.Resource;


namespace StudentManagement
{
    enum Gender
    {
        Male, Female, Others
    }


    class program
    {
        



        static void Main(string[] args)
        {
            List<Student> students = new List<Student> {
            new Student(2352608, "Huynh Minh Khoi", 21, "Male", "Computer Science"),
            new Student(2352145, "Nguyen long", 21, "Male", "Computer Science"),
            new Student(2214925, "Nguyen Lien Son",22,  "Others", "Chemical Engineering"),
            new Student(2532104,"Tran Thi Ha", 19, "Female", "Mechanical Engineering")
            };

            StudentService.mainHubStudent(students);



        }
    }
}


