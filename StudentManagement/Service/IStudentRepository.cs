using StudentManagement.DatabaseConnection;
using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Service
{
    public interface IStudentRepository
    {
        bool Idcheck(int id);
        void Add(Student student);
        void View();
        void Update(Student student, int oldId);
        void Delete(int id);




    }
}
