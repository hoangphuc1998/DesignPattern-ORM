using System;
using System.Collections.Generic;

namespace DesignPattern_ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connect to database
            DBFactory factory = new MySQLFactory();
            DBManager dbManager = factory.CreateDBManager("localhost", 3306, "school", "root", "palo1234");
            Parser parser = factory.CreateParser();
            ORMManager<Student> orm = new ORMManager<Student>(dbManager, parser);
            // Insert using an object
            //Student student = new Student("Design Pattern", true, "123@gmail.com", "1234546", "Tp.HCM", new DateTime(1998, 5, 24), 2);
            //int numCol = orm.Insert(student).Execute();

            // Update using an object
            //Student student = new Student(31, "Design Pattern K16", true, "designpattern@gmail.com", "1234546", "Tp.HCM", new DateTime(1998, 5, 24), 2);
            //int numCol = orm.Update(student).Execute();
            // Update using Set, Where
            //int numCol = orm.Update().Set("diaChi", "VietNam").Where(Condition.Equal("sdt", "1234546")).Execute();
            // Delete using an object
            //Student student = new Student(31, "Design Pattern K16", true, "designpattern@gmail.com", "1234546", "VietNam", new DateTime(1998, 5, 24), 2);
            //int numCol = orm.Delete(student).Execute();
            // Delete using Where
            //int numCol = orm.Delete().Where(Condition.Equal("ten", "Beilul Poplee")).Execute();
            //Console.WriteLine("Number of effected cols: " + numCol);
            //Select all student from class 1
            List<Object> studentList = orm.Select().Where(Condition.Equal("lop", 1)).ToList();
            foreach(Object s in studentList)
            {
                Student student = s as Student;
                Console.WriteLine("Name: " + student.ten);
                Console.WriteLine("IsMale: " + student.gioiTinh);
                Console.WriteLine("Email: " + student.mail);
                Console.WriteLine("Phone Number: " + student.sdt);
                Console.WriteLine("Address: " + student.diaChi);
                Console.WriteLine("DOB: " + student.ngaySinh);
                Console.WriteLine("ClassID: " + student.lop);
                Console.WriteLine("---------------------");
            }
            // Select name of first student of class with less than 5 students
            List<Object> res = orm.Select().AddProjection("ten").GroupBy("lop").AddProjection("ten", Aggregate.COUNT, "dem")
                .Having(Condition.LessThan("ten", 5, Aggregate.COUNT)).ToList();
            foreach (Object r in res)
            {
                Dictionary<string, Object> dict = r as Dictionary<string, Object>;
                Console.WriteLine("Name: " + dict["ten"]);
                Console.WriteLine("Number of students in class: " + dict["dem"]);
                Console.WriteLine("--------------------");
            }

            // Select with one-to-many relationship
            ORMManager<Class> orm2 = new ORMManager<Class>(dbManager, parser);
            List<Object> classList = orm2.Select().Where(Condition.GreaterThan("Id", 1)).Include(typeof(Student)).ToList();
            foreach (Object x in classList)
            {
                Class c = (Class)x;
                Console.WriteLine(c.Id + " - " + c.tenLop);
                Console.WriteLine("Students: ");
                foreach (Object s in c.x)
                {
                    Student student = (Student)s;
                    Console.WriteLine("\t" + student.ten + " " + student.diaChi);
                }
                Console.WriteLine("-----------------------");
            }
            dbManager.Disconnect();
        }
    }
}
