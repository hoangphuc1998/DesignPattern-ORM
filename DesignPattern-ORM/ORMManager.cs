using DesignPattern_ORM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DesignPattern_ORM
{
    class ORMManager<T> where T: new()
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
                if (pInfo.GetCustomAttribute<Column>() == null) continue;
                featureMap.Add(pInfo.Name, pInfo.GetCustomAttribute<Column>().columnName.ToLower());
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
        
        
        public InsertQuery Insert(T obj)
        {
            Dictionary<string, Object> valueMap = new Dictionary<string, Object>();
            //Iterate through attributes of class
            foreach(string attr in featureMap.Keys)
            {
                Object value = GetValue(obj, attr);
                //Check if attribute is a list or dictionary
                if (!(value is ICollection) && !(obj is ICollection))
                {
                    if (autoincrementCols.Contains(attr))
                    {
                        continue;
                    }
                    valueMap.Add(attr, value);
                }
            }
            return new InsertQuery(tableName, dbManager, parser, featureMap, valueMap);
        }

        public DeleteQuery Delete(T obj)
        {
            Conjunction condition = new Conjunction();
            foreach(string attr in featureMap.Keys)
            {
                Object value = GetValue(obj, attr);
                //Check if attribute is a list or dictionary
                if (!(value is ICollection) && !(obj is ICollection))
                {
                    condition.Add(Condition.Equal(attr, value));
                }
            }
            return new DeleteQuery(tableName, dbManager, parser,featureMap, condition);
        }

        public DeleteQuery Delete(Condition condition)
        {
            return new DeleteQuery(tableName, dbManager, parser,featureMap, condition);
        }
        public DeleteQuery Delete()
        {
            return new DeleteQuery(tableName, dbManager, parser, featureMap);
        }
        
        public UpdateQuery Update(T obj)
        {
            Conjunction condition = new Conjunction();
            foreach (string key in primaryKeys)
            {
                condition.Add(Condition.Equal(key, GetValue(obj, key)));
            }
            Dictionary<string, Object> setValues = new Dictionary<string, object>();
            foreach (string feature in featureMap.Keys)
            {
                if (primaryKeys.Contains(feature))
                {
                    continue;
                }
                setValues.Add(feature, GetValue(obj, feature));
            }
            return new UpdateQuery(tableName, dbManager, parser,featureMap, setValues, condition);
        }
        public UpdateQuery Update()
        {
            return new UpdateQuery(tableName, dbManager, parser, featureMap);
        }
        public SelectQuery<T> Select()
        {
            return new SelectQuery<T>(tableName, dbManager, parser, featureMap);
        }
    }
}
