using System;
using System.Collections.Generic;
using System.Text;
using StudentManagement.Model;

namespace StudentManagement.DatabaseConnection
{
    public interface IDatabase <T> where T : class
    {
        void AddToDatabase(T entity);
        List<T> viewDatabase();
        void UpdateToDatabase(int oldID, T entity);
        void Delete1FromDatabase(int Id);
        bool IdInDatabase(int id);
    }
}
