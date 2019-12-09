using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM.Attribute
{
    [AttributeUsage(AttributeTargets.All)]
    class Column: FlagsAttribute
    {
        public string columnName { get; set; }
        public Column(string column)
        {
            columnName = column;
        }
    }
}
