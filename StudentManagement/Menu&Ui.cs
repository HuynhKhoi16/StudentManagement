using StudentManagement.Model;
using StudentManagement.Service;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace StudentManagement
{
    public class Menu_UI
    {
        private readonly StudentService studentService;

        public Menu_UI(StudentService studentService)
        {
            this.studentService = studentService;
        }


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


                int num = InputHelper.GetInt("Choose the number to proceed: ");

                switch (num)
                {
                    case 1:
                    {
                        try{
                            int id = InputHelper.GetInt("Enter new Student Id: ");

                            string name = InputHelper.GetString("The new Student name is: ");

                            int age = InputHelper.GetInt("Age: ");

                            string gender = InputHelper.GenderCheck("Gender (Male, Female, Others): ");

                            string major = InputHelper.GetString("Major: ");

                            studentService.AddToDatabase(new Student(id, name, age, gender, major));
                            Console.WriteLine($"The student with the Id {id} is just added to the database");
                            }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"\nError: {ex.Message}");
                        }
                        break;
                    }
                        



                    case 2:
                        Console.WriteLine($"{"Id",-10} {"Name",-25} {"Age",-5} {"Gender",-10} {"Major",-25}");
                        List<Student> students = studentService.ViewAll();

                        foreach(var student in students)
                        {
                            Console.WriteLine($"{student.Id,-10} {student.name,-25} {student.age,-5} {student.gender,-10} {student.major,-25}");
                        }
                        break;


                    case 3:
                    {
                        try {                            
                            int Id0 = InputHelper.GetInt("Enter the Student Id you want to modify: "); ;

                            int Id = InputHelper.GetInt("Enter the new Id: ");

                            string name = InputHelper.GetString("Enter the new name: ");

                            int age = InputHelper.GetInt("Enter the new age: ");

                            string gender = InputHelper.GenderCheck("Enter the gender: ");

                            string major = InputHelper.GetString("Enter the new major: ");

                            studentService.UpdateToDatabase(new Student(Id, name, age, gender, major), Id0);

                            if (Id0 != Id)
                            {
                                Console.WriteLine($"The student with the id {Id} is modified in the database");
                            }
                            else Console.WriteLine($"The student with the new id {Id} is modified in the database");

                            }
                        catch (Exception ex){
                            Console.WriteLine($"\nError: {ex.Message}");
                        }
                        break;
                    }


                    case 4:
                    {
                        try{
                            int id = InputHelper.GetInt("Enter the Id of the student you want to delete: ");

                            studentService.DeleteFromDatabase(id);
                            Console.WriteLine($"The student with the id {id} is removed from the database");
                            }
                        catch(Exception ex)
                        {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                    }

                    case 5:
                        return;


                    default:
                        Console.WriteLine("\nOut of range number, must be between 1 and 5.\n");
                        break;

                }
            }
        }
    }
}
