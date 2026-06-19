using StudentManagement.Human;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Globalization;
using StudentManagement.DatabaseConnection;
namespace StudentManagement.Resource
{
   class StudentService
    {
        private readonly Database Repository;

        public StudentService(Database repository)
        {
            Repository = repository;
        }

        //1. ADD STUDENT
        public void addStudent()
        {
            Console.Write("StudentID: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Invalid entry");
                return;
            }

            bool check = Repository.IdInDatabase(id);
            if (check == true)
            {
                Console.Write("ID already exist");
                return;
            }

            Console.Write("Fullname: ");
            string name = Console.ReadLine();

            Console.Write("Age: ");
            int age;

            if (!int.TryParse((string)Console.ReadLine(), out age) || age < 0)
            {
                Console.Write("Invalid age");
                return;
            }

            Console.Write("Gender: ");
            string gender = Console.ReadLine();

            Console.Write("Major: ");
            string major = Console.ReadLine();

            Student student = new Student(id, name, age, gender, major);

            Repository.AddToDatabase(student);

        }



        



        //3. UPDATE INFORMATION 
        public void updateStudent()
        {
            int Id0;
            Console.Write("Enter the studentID of the Student you want to modify: ");
            if (!int.TryParse(Console.ReadLine(), out Id0))
            {
                Console.Write("Invalid entry");
                return;
            }

            if (Repository.IdInDatabase(Id0))
            {
                Console.Write("Enter the new ID: ");
                int Id;
                if (!int.TryParse(Console.ReadLine(), out Id))
                {
                    Console.Write("Invalid entry");
                    return;
                }

                bool check = Repository.IdInDatabase(Id);
                if (check == true && Id != Id0)
                {
                    Console.Write("ID already exist");
                    return;
                }

                Console.Write("Enter the new name: ");
                string name = Console.ReadLine();

                Console.Write("Enter the new age: ");

                int age;

                if (!int.TryParse((string)Console.ReadLine(), out age) || age < 0)
                {
                    Console.Write("Invalid age");
                    return;
                }



                Console.Write("Reenter the Gender: ");
                string gender = Console.ReadLine().ToUpper();
                Gender Gender;
                switch (gender)
                {
                    case "MALE":
                        Gender = Gender.Male; break;
                    case "FEMALE":
                        Gender = Gender.Female; break;
                    case "OTHERS":
                        Gender = Gender.Others; break;
                    default:
                        Console.WriteLine("Invalid gender");
                        return;
                }

                Console.Write("Enter the new major: ");
                string major = Console.ReadLine();


                int oldId = Id0;
                Student student = new Student(Id, name, age, gender, major);
                Repository.UpdateToDatabase(oldId, student);

            }
            else
            {
                Console.WriteLine("The ID is not found.");
            }

        }



        


        //4. DELETE STUDENT
        public void deleteStudent()
        {
            Console.Write("Enter the studentID of the Student you want to delete: ");
            int id;
            while(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry, re-entering:");
            }
            if (!Repository.IdInDatabase(id))
            {
                Console.WriteLine("The ID is not found.");
            }
            else
            {
                Repository.Delete1FromDatabase(id);
                Console.WriteLine($"The student with the ID {id} was removed.");

            }
        }


        //4.1. DELETE 1 VALUE IN DATABASE

        


        //MainHub
        public void mainHubStudent()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("====WELCOME TO STUDENT MANAGEMENT SYSTEM====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View all students");
                Console.WriteLine("3. Update Student information");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");

                Console.Write("Choose the number to proceed: ");




                int num;

                if (!int.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine("Invalid entry, must be a number.");
                }


                switch (num)
                {
                    case 1:
                        addStudent(); break;
                    case 2:
                        Repository.viewDatabase(); break;
                    case 3:
                        updateStudent(); break;
                    case 4:
                        deleteStudent(); break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Out of range number, must be between 1 and 5.");
                        break;

                }
            }
        }
    }
}
