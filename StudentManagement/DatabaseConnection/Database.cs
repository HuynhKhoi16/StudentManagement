using System;
using System.Collections.Generic;
using System.Text;
using StudentManagement.Model;

namespace StudentManagement.DatabaseConnection
{
    public interface IDatabase
    {
        void AddToDatabase(Student student);
        void viewDatabase();
        void UpdateToDatabase(int oldID, Student student);
        void Delete1FromDatabase(int Id);
        bool IdInDatabase(int id);
    }
}
