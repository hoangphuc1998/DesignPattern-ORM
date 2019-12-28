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
        public string ten { get; set; }
        [Column("IsMale")]
        public bool gioiTinh {get;set;}
        [Column("Email")]
        public string mail {get; set;}
        [Column("PhoneNumber")]
        public string sdt {get;set;}
        [Column("Address")]
        public string diaChi {get; set;}
        [Column("DOB")]
        public DateTime ngaySinh {get;set;}
        [Column("ClassID")]
        public int lop {get;set;}

        public Student(int id, string ten, bool gioiTinh, string mail, string sdt, string diaChi, DateTime ngaySinh, int lop)
        {
            Id = id;
            this.ten = ten;
            this.gioiTinh = gioiTinh;
            this.mail = mail;
            this.sdt = sdt;
            this.diaChi = diaChi;
            this.ngaySinh = ngaySinh;
            this.lop = lop;
        }

        public Student(string ten, bool gioiTinh, string mail, string sdt, string diaChi, DateTime ngaySinh, int lop)
        {
            this.ten = ten;
            this.gioiTinh = gioiTinh;
            this.mail = mail;
            this.sdt = sdt;
            this.diaChi = diaChi;
            this.ngaySinh = ngaySinh;
            this.lop = lop;
        }

        public Student() { }
    }
}