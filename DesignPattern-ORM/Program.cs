using System;

namespace DesignPattern_ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            ORMManager<Student> orm = new ORMManager<Student>();
            MySQLManager sql = new MySQLManager("localhost", 3306, "JobSearch", "root", "palo1234");
        }
    }
}
