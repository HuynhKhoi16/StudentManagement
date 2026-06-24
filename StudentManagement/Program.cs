using System;
using StudentManagement.Model;
using StudentManagement.Service;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.DatabaseConnection;

namespace StudentManagement
{
    class program
    {
        static void Main(string[] args)
        {
            
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentManagement;Integrated Security=True;Encrypt=True;";
            string tableName = "Student";
            /*
            IDatabase db = new Sql(connectionString, tableName);
            IStudentRepository Service = new StudentService(db);
            Menu_UI Front = new Menu_UI(Service);
            Front.mainHubStudent();
            */


            
            var services = new ServiceCollection();
            // 1. Đăng ký các dịch vụ
            // Giả sử class Database của bạn chứa logic SQL
            services.AddSingleton<IDatabase<Student>>(new Sql(connectionString, tableName));
            services.AddSingleton<IStudentRepository, StudentService>();
            services.AddSingleton<Menu_UI>();

            // 2. Build
            var serviceProvider = services.BuildServiceProvider();

            // 3. Lấy StudentService đã được DI chuẩn bị sẵn
            var app = serviceProvider.GetRequiredService<Menu_UI>();

            // 4. Chạy ứng dụng
            app.mainHubStudent();
            
        }
    }
}


