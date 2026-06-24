using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement
{
    class InputHelper
    {
        public static int GetInt(string prompt)
        {
            int val;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out val) && val > 0) { return val; }
                Console.WriteLine("Invalid input, must be an interger and larger than 0");
            }
        }

        public static string GetString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string val = Console.ReadLine();
                if (!string.IsNullOrEmpty(val)) return val;
                Console.WriteLine("The value can't be null");
            }
        }

        public static string GenderCheck(string prompt) {
            while (true)
            {
                Console.Write(prompt);
                string gender = Console.ReadLine().ToUpper();
                if (gender == "MALE") return "Male";
                else if (gender == "FEMALE") return "Female";
                else if (gender == "OTHERS") return "Others";
                else
                {
                    Console.WriteLine("Input can only be Male, Female or Others");
                }
            }
        }
    }
}
