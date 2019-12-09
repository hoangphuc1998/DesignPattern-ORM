using DesignPattern_ORM.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    [TableName("Student")]
    class Student
    {
        
        [Column("StudentID")]
        public int Id { get; set; }
        [Column("StudentName")]
        public string name { get; set; }
        [Column("StudentScore")]
        public float mark { get; set; }
    }
}
