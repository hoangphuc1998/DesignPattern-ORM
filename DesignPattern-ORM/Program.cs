using System;
using System.Collections.Generic;

namespace DesignPattern_ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            ORMManager<Student> orm = new ORMManager<Student>();
            MySQLManager sql = new MySQLManager("localhost", 3306, "school", "root", "palo1234");
            List<List<string>> s = sql.Select("SELECT * FROM Students");
            foreach (List<string> ss in s)
            {
                foreach (string sss in ss)
                {
                    Console.Write(sss + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
