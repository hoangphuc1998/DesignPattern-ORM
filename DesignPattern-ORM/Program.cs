using System;
using System.Collections.Generic;

namespace DesignPattern_ORM
{
    class Program
    {
        static void Main2(string[] args)
        {
            MySQLManager sql = new MySQLManager("localhost", 3306, "school", "root", "palo1234");
            MySQLParser parser = new MySQLParser();
            ORMManager<Student> orm = new ORMManager<Student>(sql, parser);

            Student student = new Student("Trang Trung Hoang Phuc", true, "123@gmail.com", "1234546", "Tp.HCM", new DateTime(1998, 5, 24), 2);
            Console.WriteLine(student.Id);
            //List<List<string>> s = sql.Select("SELECT * FROM Students");
            //foreach (List<string> ss in s)
            //{
            //    foreach (string sss in ss)
            //    {
            //        Console.Write(sss + "\t");
            //    }
            //    Console.WriteLine();
            //}
        }
        static void Main(string[] args)
        {
            Condition x = Condition.And(Condition.lt("x", 5), Condition.equal("L", "Asca"));
            Console.WriteLine(x.toSQL());
        }
    }
}
