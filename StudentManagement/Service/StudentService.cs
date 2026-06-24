
using System;
using StudentManagement.DatabaseConnection;
using StudentManagement.Model;
namespace StudentManagement.Service
{
    public class StudentService : IStudentRepository
    {
        private readonly IDatabase<Student> Repository;

        public StudentService(IDatabase<Student> repository)
        {
            Repository = repository;
        }


        //1. ADD STUDENT
        public void Add(Student student)
        {
            if (Repository.IdInDatabase(student.Id))
            {
                throw new Exception("The Id you enter already exist.");
            }
            Repository.AddToDatabase(student);

        }


        //2.VIEW ALL
        public List<Student> View()
        {
            return Repository.viewDatabase();
        }



        //3. UPDATE INFORMATION 
        public void Update(Student student, int oldId)
        {
            if (!Repository.IdInDatabase(oldId))
            {
                throw new Exception("The Id of Student you want to change does not exist.");
            }

            if (Repository.IdInDatabase(student.Id) && student.Id != oldId)
            {
                throw new Exception("The new Id you enter already exist in the database.");
            }

            Repository.UpdateToDatabase(oldId, student);
        }



        //4. DELETE STUDENT
        public void Delete(int id)
        {
            if (!Repository.IdInDatabase(id))
            {
                throw new Exception("The Id of Student you want to change does not exist.");
            }
            Repository.Delete1FromDatabase(id);
        }
    }
}
