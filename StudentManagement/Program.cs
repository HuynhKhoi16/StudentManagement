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
            StudentService studentService = new StudentService();
            Menu_UI menu = new Menu_UI(studentService);
            menu.mainHubStudent();
        }
    }
}


