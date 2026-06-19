using StudentManagement.Human;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Globalization;
namespace StudentManagement.Resource
{
   class StudentService
    {
        
        //  CHECK ID IN DATABASE
        public static bool IdInDatabase(int id)
        {


            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentManagement;Integrated Security=True;Encrypt=True;";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                string sql = "Select COUNT(1) from Student " +
                             "where Id = @Id";
                using(SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cnn.Open();

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        //1. ADD STUDENT
        public static void addStudent()
        {
            Console.Write("StudentID: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Invalid entry");
                return;
            }

            bool check = IdInDatabase(id);
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

            AddToDatabase(student);

        }



        //1.1. ADD TO DATABASE
        public static void AddToDatabase(Student student)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentManagement;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "Insert into [dbo].[Student](Id, Name, Age, Gender, Major) VALUES (@Id, @Name, @Age, @Gender, @Major)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", student.Id);
                    cmd.Parameters.AddWithValue("@Name", student.name);
                    cmd.Parameters.AddWithValue("@Age", student.age);
                    cmd.Parameters.AddWithValue("@Gender", student.gender.ToString());
                    cmd.Parameters.AddWithValue("@Major", student.major);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        //2. VIEW DATABASE
        public static void viewDatabase()
        {
            Console.WriteLine($"{"Id",-10} {"Name",-25} {"Age",-5} {"Gender",-10} {"Major",-25}");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentManagement;Integrated Security=True;Encrypt=True;";
            string sql = "Select * from Student";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string name = Convert.ToString(reader["Name"]);
                            int age = Convert.ToInt32(reader["Age"]);
                            string gender = Convert.ToString(reader["Gender"]);
                            string major = Convert.ToString(reader["Major"]);
                            Console.WriteLine($"{id,-10} {name,-25} {age,-5} {gender,-10} {major,-25}");
                        }
                    }
                }
            }
        }



        //3. UPDATE INFORMATION 
        public static void updateStudent()
        {
            int Id0;
            Console.Write("Enter the studentID of the Student you want to modify: ");
            if (!int.TryParse(Console.ReadLine(), out Id0))
            {
                Console.Write("Invalid entry");
                return;
            }

            if (IdInDatabase(Id0))
            {
                Console.Write("Enter the new ID: ");
                int Id;
                if (!int.TryParse(Console.ReadLine(), out Id))
                {
                    Console.Write("Invalid entry");
                    return;
                }

                bool check = IdInDatabase(Id);
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
                UpdateToDatabase(oldId, student);

            }
            else
            {
                Console.WriteLine("The ID is not found.");
            }

        }



        //3.1. UPDATE DATABASE
        public static void UpdateToDatabase(int oldID, Student student)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentManagement;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                string sql = "Update Student Set Id = @Id,  " +
                                            "Name = @Name, " +
                                            "Age = @Age, " +
                                            "Gender = @Gender, " +
                                            "Major = @Major " +
                                            "Where Id = @oldId";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", student.Id);
                    cmd.Parameters.AddWithValue("@Name", student.name);
                    cmd.Parameters.AddWithValue("@Age", student.age);
                    cmd.Parameters.AddWithValue("@Gender", student.gender.ToString());
                    cmd.Parameters.AddWithValue("@Major", student.major);
                    cmd.Parameters.AddWithValue("@oldId", oldID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        //4. DELETE STUDENT
        public static void deleteStudent()
        {
            Console.Write("Enter the studentID of the Student you want to delete: ");
            int id;
            while(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry, re-entering:");
            }
            if (!IdInDatabase(id))
            {
                Console.WriteLine("The ID is not found.");
            }
            else
            {
                Delete1FromDatabase(id);
                Console.WriteLine($"The student with the ID {id} was removed.");

            }
        }


        //4.1. DELETE 1 VALUE IN DATABASE

        public static void Delete1FromDatabase(int Id)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentManagement;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "Delete from Student Where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@Id", Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        //MainHub
        public static void mainHubStudent()
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
                        viewDatabase(); break;
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
