using StudentManagement.Human;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Resource
{
    internal class StudentService
    {
        //HELPER

        //FIND STUDENT
        public static Student findStudentByID(List<Student> students)
        {

            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID");
                return null;
            }

            Student student = students.Find(x => x.Id == id);
            if (student == null)
            {
                //Console.WriteLine("Student not found.");
                return null;
            }
            else return student;
        }


        //CHECK ID
        public static bool findID(int ID, List<Student> students)
        {
            foreach (Student student in students)
            {
                if (student.Id == ID) return true;
            }
            return false;
        }

        //1. ADD STUDENT
        public static void addStudent(List<Student> students)
        {
            Console.Write("StudentID: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Invalid entry");
                return;
            }

            bool check = findID(id, students);
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

            students.Add(new Student(id, name, age, gender, major));

        }

        //2. VIEW ALL STUDENTS
        public static void viewAll(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No Students found.");
            }
            else
            {
                Console.WriteLine($"{"StudentID",-10}  {"Student Name",-20}  {"Age",-5}  {"Gender",-10}  {"Major",-20}");
                foreach (Student student in students.
                    OrderBy(x => x.major).
                    ThenBy(y => y.Id))
                {
                    Console.WriteLine($"{student.Id,-10}  {student.name,-20}  {student.age,-5}  {student.gender,-10}  {student.major,-20}");
                }
            }
        }

        //3. UPDATE INFORMATION 
        public static void updateStudent(List<Student> students)
        {
            Console.Write("Enter the studentID of the Student you want to modify: ");
            Student student = findStudentByID(students);
            if (student != null)
            {
                Console.Write("Enter the new ID: ");
                int Id;
                if (!int.TryParse(Console.ReadLine(), out Id))
                {
                    Console.Write("Invalid entry");
                    return;
                }

                bool check = findID(Id, students);
                if (check == true && Id != student.Id)
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



                student.Id = Id;
                student.name = name;
                student.age = age;
                student.gender = Gender;
                student.major = major;


            }
            else
            {
                Console.WriteLine("The ID is not found.");
            }

        }


        //4. DELETE STUDENT
        public static void deleteStudent(List<Student> students)
        {
            Console.Write("Enter the studentID of the Student you want to delete: ");
            Student student = findStudentByID(students);
            if (student == null)
            {
                Console.WriteLine("The ID is not found.");
            }
            else
            {
                int id = student.Id;
                students.Remove(student);
                Console.WriteLine($"The student with the ID {id} was removed.");

            }
        }


        public static void mainHubStudent(List<Student> students)
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
                        addStudent(students); break;
                    case 2:
                        viewAll(students); break;
                    case 3:
                        updateStudent(students); break;
                    case 4:
                        deleteStudent(students); break;
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
