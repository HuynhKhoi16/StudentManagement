using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Human
{
    public class Student : Person
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public Gender gender { get; set; }
        public string major { get; set; }

        public Student(int id, string name, int age, string gender, string major)
        {
            Id = id;
            this.name = name;
            this.age = age;
            this.major = major;

            gender = gender.ToUpper();
            switch (gender)
            {
                case "MALE":
                    this.gender = Gender.Male; break;
                case "FEMALE":
                    this.gender = Gender.Female; break;
                case "OTHERS":
                    this.gender = Gender.Others; break;
                default:
                    //throw new ArgumentException("There is an gender error here.");
                    return;
            }
        }

        public Student(Student student)
        {
            this.Id = student.Id;
            this.name = student.name;
            this.age = student.age;
            this.gender = student.gender;
            this.major = student.major;


        }
    }
}
