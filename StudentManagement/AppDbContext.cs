using Microsoft.EntityFrameworkCore;
using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=StudentManagement;Integrated Security=True;Encrypt=True;");
        }
    }
}
