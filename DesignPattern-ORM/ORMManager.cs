using DesignPattern_ORM.Attribute;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DesignPattern_ORM
{
    class ORMManager<T>
    {
        private Dictionary<string, string> featureMap = new Dictionary<string, string>();
        private string tableName;
        private DBManager dbManager;
        private Parser parser;
        public ORMManager(DBManager dbManager, Parser parser)
        {
            this.dbManager = dbManager;
            Type type = typeof(T);
            PropertyInfo[] propertyInfo = type.GetProperties();
            foreach (PropertyInfo pInfo in propertyInfo)
            {
                featureMap.Add(pInfo.Name, pInfo.GetCustomAttribute<Column>().columnName);
            }
            this.tableName = type.GetCustomAttribute<TableName>().tableName;
            this.dbManager = dbManager;
            this.parser = parser;
        }
        
        
        public int Insert(T obj)
        {
            //TODO: implement Insert
            throw new NotImplementedException();
        }
    }
}
