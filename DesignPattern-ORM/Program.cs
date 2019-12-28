﻿using System;
using System.Collections.Generic;

namespace DesignPattern_ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            MySQLManager sql = new MySQLManager("localhost", 3306, "school", "root", "palo1234");
            MySQLParser parser = new MySQLParser();
            ORMManager<Student> orm = new ORMManager<Student>(sql, parser);
            
            List<Object> res = orm.Select().AddProjection("ten").GroupBy("lop").AddProjection("ten", Aggregate.COUNT, "demten")
                .Having(Condition.Equal("ten",41,Aggregate.COUNT)).ToList();
            foreach(string key in ((Dictionary<string, Object>)res[0]).Keys)
            {
                Console.WriteLine(key);
            }
            Console.WriteLine(((Dictionary<string, Object>)res[0])["ten"]);
            
            //Student student = new Student(502,"Trang Trung Hoang Phuc", true, "123@gmail.com", "1234546", "Tp.HCM", new DateTime(1998, 5, 24), 2);
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
        }
    }
}
