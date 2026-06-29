using System;
using StudentManagement.Model;
using StudentManagement.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Options;

namespace StudentManagement
{
    class Program
    {
        static void Main(string[] args)
        {

            //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentManagement;Integrated Security=True;Encrypt=True;";
            //string tableName = "Student";
            /*
            IDatabase db = new Sql(connectionString, tableName);
            IStudentRepository Service = new StudentService(db);
            Menu_UI Front = new Menu_UI(Service);
            Front.mainHubStudent();
            */

            IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory()) // Đặt đường dẫn làm việc tại thư mục chứa file
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();


            var services = new ServiceCollection();
            services.Configure<Sql>(configuration.GetSection("DatabaseInformation"));

            services.AddSingleton<IDatabase<Student>, Sql>();
            services.AddSingleton<IStudentRepository, StudentService>();
            services.AddSingleton<Menu_UI>();

            var serviceProvider = services.BuildServiceProvider();
            // 1. Lấy "thành phẩm" Menu_UI ra từ container
            var menu = serviceProvider.GetRequiredService<Menu_UI>();

            // 2. Bây giờ mới gọi hàm mainHubStudent() của đối tượng đó
            menu.mainHubStudent();

        }
    }
}


