using DesignPattern_ORM.Attribute;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DesignPattern_ORM
{
    class ORMManager<T>
    {
        Object GetValue(Object src, string propName){
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
        private Dictionary<string, string> featureMap = new Dictionary<string, string>();
        private List<string> primaryKeys = new List<string>();
        private List<string> autoincrementCols = new List<string>();
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
                if (pInfo.GetCustomAttribute<Column>().isKey == true){
                    primaryKeys.Add(pInfo.Name);
                }
                if (pInfo.GetCustomAttribute<Column>().autoincrement == true){
                    autoincrementCols.Add(pInfo.Name);
                }
            }
            this.tableName = type.GetCustomAttribute<TableName>().tableName;
            this.dbManager = dbManager;
            this.parser = parser;
        }
        
        
        public int Insert(T obj)
        {
            Dictionary<string, Object> valueMap = new Dictionary<string, Object>();
            //Iterate through attributes of class
            foreach(string attr in featureMap.Keys){
                Object value = GetValue(obj, attr);
                //Check if attribute is a list or dictionary
                if (value is ICollection<> || obj is ICollection){
                    continue;
                }
                if (autoincrementCols.Any(attr.Contains)){
                    continue;
                }
                valueMap.Add(attr, value);
            }
            return new InsertQuery(tableName, dbManager, parser, valueMap).Execute();
        }
    }
}
