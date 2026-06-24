using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using StudentManagement.Service;

namespace StudentManagement.DatabaseConnection
{
    public class Sql : IDatabase<Student>
    {
        private readonly string ConnectionString;
        private readonly string TableName;


        public Sql(string connectionString, string tableName)
        {
            ConnectionString = connectionString;
            TableName = tableName;
        }

        //  CHECK ID IN DATABASE
        public bool IdInDatabase(int id)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                string sql = $"Select COUNT(1) from {TableName} " +
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
                string sql = $"Insert into {TableName}(Id, Name, Age, Gender, Major) VALUES (@Id, @Name, @Age, @Gender, @Major)";
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
            Console.WriteLine($"The student with the Id {student.Id} is just added to the database");
        }

        //2. VIEW DATABASE
        public List<Student> viewDatabase()
        {
            List<Student> students = new List<Student>();
            string sql = $"Select * from {TableName}";

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
                            students.Add(new Student(id, name, age, gender, major));
                        }
                    }
                }
            }
            return students;
        }


        //3.1. UPDATE DATABASE
        public void UpdateToDatabase(int oldID, Student student)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {

                string sql = $"Update {TableName} Set Id = @Id,  " +
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
                string sql = $"Delete from {TableName} Where Id = @Id";
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
