
using System;
using StudentManagement.DatabaseConnection;
using StudentManagement.Model;
namespace StudentManagement.Service
{
    public class StudentService : IStudentRepository
    {
        private readonly IDatabase Repository;

        public StudentService(IDatabase repository)
        {
            Repository = repository;
        }

        //1. ADD STUDENT
        public void Add(Student student)
        {
            bool check = Repository.IdInDatabase(student.Id);
            if (check == true)
            {
                Console.Write("ID already exist");
                return;
            }
            Repository.AddToDatabase(student);

        }


        //2.VIEW ALL
        public void View()
        {
            Repository.viewDatabase();
        }



        //3. UPDATE INFORMATION 
        public void Update(Student student, int oldId)
        {


            if (!Repository.IdInDatabase(oldId))
            {
                Console.Write("ID not found");
                return;
            }


            if (Repository.IdInDatabase(student.Id) && student.Id != oldId)
            {
                Console.Write("The ID you entered already exist");
                return;
            }


            Repository.UpdateToDatabase(oldId, student);


        }






        //4. DELETE STUDENT
        public void Delete(int id)
        {

            if (!Repository.IdInDatabase(id))
            {
                Console.WriteLine("The ID is not found.");
            }
            else
            {
                Repository.Delete1FromDatabase(id);
                Console.WriteLine($"The student with the ID {id} was removed.");

            }
        }
    }
}
