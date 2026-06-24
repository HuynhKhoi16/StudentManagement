using StudentManagement.Model;
using StudentManagement.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement
{
    public class Menu_UI
    {
        private readonly IStudentRepository studentService;

        public Menu_UI(IStudentRepository studentService)
        {
            this.studentService = studentService;
        }


        //CHECK EXISTING ID
        public bool IdExist(int id)
        {
            return studentService.Idcheck(id);
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

                Console.Write("Choose the number to proceed: ");




                int num;

                if (!int.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine("Invalid entry, must be a number.");
                    return;
                }


                switch (num)
                {



                    case 1:
                        {
                            Console.Write("StudentID: ");
                            int id;
                            if (!int.TryParse(Console.ReadLine(), out id))
                            {
                                Console.Write("Invalid entry");
                                break;
                            }

                            if (IdExist(id))
                            {
                                Console.Write("The id you entered already exists");
                                break; ;
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

                            studentService.Add(student);
                            break;
                        }






                    case 2:
                        studentService.View(); break;





                    case 3:
                        {
                            int Id0;
                            Console.Write("Enter the studentID of the Student you want to modify: ");
                            if (!int.TryParse(Console.ReadLine(), out Id0))
                            {
                                Console.Write("Invalid entry");
                                break ;
                            }


                            if (!IdExist(Id0))
                            {
                                Console.Write("The id you entered cannot be found");
                                break; ;
                            }

                            Console.Write("Enter the new ID: ");
                            int Id;
                            if (!int.TryParse(Console.ReadLine(), out Id))
                            {
                                Console.Write("Invalid entry");
                                return;
                            }

                            if (IdExist(Id0) && Id0 != Id)
                            {
                                Console.Write("The id you entered already exists");
                                break; ;
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

                            studentService.Update(student, oldId);
                            break;
                        }



                    case 4:
                        {
                            Console.Write("Enter the studentID of the Student you want to delete: ");
                            int id;
                            while (!int.TryParse(Console.ReadLine(), out id))
                            {
                                Console.WriteLine("Invalid entry, re-entering:");
                            }

                            if (!IdExist(id))
                            {
                                Console.Write("The id you try to delete does not exist");
                                break; ;
                            }

                            studentService.Delete(id); break;
                        }



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
