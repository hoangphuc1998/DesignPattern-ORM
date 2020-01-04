using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    [TableName("Classes")]
    class Class
    {
        [Column("ID", isKey: true, autoincrement: true)]
        public int Id { get; set; }
        [Column("Name")]
        public string tenLop { get; set; }
        [Column("ListStudents")]
        public List<Student> dsHocSinh;

        [HasMany("Student", "Id", "classid")]
        public List<Student> x { get; set; }
    }
}
