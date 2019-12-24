using DesignPattern_ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    [TableName("Students")]
    class Student
    {
        
        [Column("ID", isKey: true, autoincrement: true)]
        public int Id { get; set; }
        [Column("Name")]
        public string name { get; set; }
        [Column("IsMale")]
        public bool isMale {get;set;}
        [Column("Email")]
        public string email {get; set;}
        [Column("PhoneNumber")]
        public string phoneNumber {get;set;}
        [Column("Address")]
        public string address {get; set;}
        [Column("DOB")]
        public DateTime DOB {get;set;}
        [Column("ClassID")]
        public int classID {get;set;}

        public Student(string name, bool isMale, string email, string phoneNumber, string address, DateTime dOB, int classID)
        {
            this.name = name;
            this.isMale = isMale;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address;
            DOB = dOB;
            this.classID = classID;
        }
    }
}