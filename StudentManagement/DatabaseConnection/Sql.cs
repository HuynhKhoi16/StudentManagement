using Microsoft.Data.SqlClient;
using StudentManagement.Human;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.DatabaseConnection
{
    public class Sql : Database
    {
        private readonly string ConnectionString;


        public Sql (string connectionString)
        {
            ConnectionString = connectionString;
        }

        //  CHECK ID IN DATABASE
        public bool IdInDatabase(int id)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                string sql = "Select COUNT(1) from Student " +
                             "where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cnn.Open();

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        //1.1. ADD TO DATABASE
        public void AddToDatabase(Student student)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
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
        public void viewDatabase()
        {
            Console.WriteLine($"{"Id",-10} {"Name",-25} {"Age",-5} {"Gender",-10} {"Major",-25}");
            string sql = "Select * from Student";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
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


        //3.1. UPDATE DATABASE
        public void UpdateToDatabase(int oldID, Student student)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
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


        public void Delete1FromDatabase(int Id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
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
    }
}
