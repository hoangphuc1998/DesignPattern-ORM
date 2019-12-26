using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DesignPattern_ORM
{
    [AttributeUsage(AttributeTargets.All)]
    class TableName : FlagsAttribute
    {
        public string tableName { get; set; }
        public TableName(string name)
        {
            tableName = name;
        }
    }
}
