
using System;
using StudentManagement.Model;
namespace StudentManagement.Service
{
    public class StudentService
    {


        //1. ADD STUDENT
        public void AddToDatabase(Student student)
        {
            using (var db = new AppDbContext())
            {
                db.Students.Add(student);

                db.SaveChanges();
            }
        }


        //2.VIEW ALL
        public List<Student> ViewAll()
        {
            using (var db = new AppDbContext())
            {
                return db.Students.ToList();
            }

        }



        //UPDATE
        public void UpdateToDatabase(Student updatedStudent, int oldId)
        {
            using (var db = new AppDbContext())
            {
                var studentFix = db.Students.FirstOrDefault(s => s.Id == oldId);
                if (studentFix != null)
                {
                    db.Entry(studentFix).CurrentValues.SetValues(updatedStudent);

                    // Nếu bạn không muốn đổi Id, hãy ép nó giữ nguyên Id cũ
                    studentFix.Id = oldId;

                    db.SaveChanges();
                }
                else throw new Exception("The id is not found");
            }
        }


        //DELETE
        public void DeleteFromDatabase(int id)
        {
            using (var db = new AppDbContext())
            {

                // 1. Tìm bản ghi cần xóa
                var studentToDelete = db.Students.FirstOrDefault(s => s.Id == id);

                if (studentToDelete != null)
                {
                    // 2. Gọi lệnh Remove
                    db.Students.Remove(studentToDelete);

                    // 3. Gọi SaveChanges để thực hiện xóa thật sự trong DB
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("The id is not found!");
                }


            }
        }
    }
}
