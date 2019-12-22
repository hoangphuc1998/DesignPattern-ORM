using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM.Attribute
{
    [AttributeUsage(AttributeTargets.All)]
    class Column: FlagsAttribute
    {
        public string columnName { get; set; }
        public bool isKey {get; set; }
        public bool autoincrement {get;set;}
        public Column(string column, bool isKey = false, bool autoincrement = false)
        {
            columnName = column;
            isKey = isKey;
            autoincrease = autoincrease;
        }
    }
}
