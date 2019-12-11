using DesignPattern_ORM.Attribute;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DesignPattern_ORM
{
    class ORMManager<T>
    {
        public ORMManager()
        {
            Type type = typeof(T);
            PropertyInfo[] propertyInfo = type.GetProperties();
            foreach (PropertyInfo pInfo in propertyInfo)
            {
                Console.WriteLine(pInfo.Name);
                Console.WriteLine(pInfo.GetCustomAttribute<Column>().columnName);
            }
            Console.WriteLine("Table Name: " + type.GetCustomAttribute<TableName>().tableName);
        }
        private Dictionary<string, string> featureMap = new Dictionary<string, string>();
    }
}
