using System;
using StudentManagement.Human;
using StudentManagement.Resource;
using StudentManagement.Testing;
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

            Database db = new Sql(connectionString, tableName);
            StudentService Service = new StudentService(db);
            Menu_UI Front = new Menu_UI(Service);
            Front.mainHubStudent();



            /*
            var services = new ServiceCollection();
            // 1. Đăng ký các dịch vụ
            // Giả sử class Database của bạn chứa logic SQL
            services.AddSingleton<Database>(new Sql(connectionString, databaseName));
            services.AddSingleton<StudentService>();

            // 2. Build
            var serviceProvider = services.BuildServiceProvider();

            // 3. Lấy StudentService đã được DI chuẩn bị sẵn
            var app = serviceProvider.GetRequiredService<StudentService>();

            // 4. Chạy ứng dụng
            app.mainHubStudent();
            */

        }
    }
}


