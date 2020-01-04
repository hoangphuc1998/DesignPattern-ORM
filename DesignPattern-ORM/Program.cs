using System;
using System.Collections.Generic;

namespace DesignPattern_ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            //DBFactory factory = new MySQLFactory();
            //DBManager dbManager = factory.CreateDBManager("localhost", 3306, "school", "root", "palo1234");
            //Parser parser = factory.CreateParser();
            //ORMManager<Student> orm = new ORMManager<Student>(dbManager, parser);

            //List<Object> res = orm.Select().AddProjection("ten").GroupBy("lop").AddProjection("ten", Aggregate.COUNT, "demten")
            //    .Having(Condition.Equal("ten",41,Aggregate.COUNT)).ToList();
            //foreach(string key in ((Dictionary<string, Object>)res[0]).Keys)
            //{
            //    Console.WriteLine(key);
            //}
            //Console.WriteLine(((Dictionary<string, Object>)res[0])["ten"]);

            //Student student = new Student("Trang Trung Hoang Phuc", true, "123@gmail.com", "1234546", "Tp.HCM", new DateTime(1998, 5, 24), 2);
            //int numCol = orm.Insert(student).Execute();
            //Console.WriteLine("Number of effected cols: " + numCol);
            //int numCol = orm.Update(student).Execute();
            //Console.WriteLine("Number of effected cols: " + numCol);
            //List<List<string>> s = sql.Select("SELECT * FROM Students");
            //foreach (List<string> ss in s)
            //{
            //    foreach (string sss in ss)
            //    {
            //        Console.Write(sss + "\t");
            //    }
            //    Console.WriteLine();
            //}

            DBFactory factory2 = new PostgresFactory();
            DBManager dBManager2 = factory2.CreateDBManager("localhost",5432,"school","postgres","123");
            Parser parser2 = factory2.CreateParser();
            /*
            ORMManager<Student> orm2 = new ORMManager<Student>(dBManager2, parser2);
            // student = new Student("Trang Trung Hoang Phuc", true, "123@gmail.com", "1234546", "Tp.HCM", new DateTime(1998, 5, 24), 2);
            //int numCol = orm2.Insert(student).Execute();
            
            List<Object> s = orm2.Select().Where(Condition.LessThanOrEqual("Id", 3)).ToList();
            foreach (Object x in s)
            {
                Student student = (Student)x;
                Console.WriteLine(student.Id + " " + student.ten);
            }
            */
            ORMManager<Class> orm2 = new ORMManager<Class>(dBManager2, parser2);
            List<Object> s = orm2.Select().Where(Condition.GreaterThan("Id", 2)).Include(typeof(Student), new string[] { "ten", "sdt" }).ToList();
            foreach (Object x in s)
            {
                Class c = (Class)x;
                Console.WriteLine(c.Id + " " + c.tenLop);
                foreach(Object xx in c.x)
                {
                    Student cc = (Student)xx;
                    Console.WriteLine(cc.ten);
                }
                Console.WriteLine("-----------------------");
            }
            dBManager2.Disconnect();
        }
    }
}
