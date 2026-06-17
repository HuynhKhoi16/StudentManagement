using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Human
{
    interface Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public Gender gender { get; set; }
    }
}
