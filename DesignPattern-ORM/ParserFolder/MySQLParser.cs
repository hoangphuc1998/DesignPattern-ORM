using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern_ORM { 
    class MySQLParser : Parser
    {
        public override string ParseDeleteQuery(string tableName, string whereCondition)
        {
            string query = "DELETE FROM " + tableName + " WHERE " + whereCondition;
            return query;
        }

        public override string ParseInsertQuery(string tableName, Dictionary<string, string> values)
        {
            string query = "INSERT INTO " + tableName + "(";
            foreach (string key in values.Keys.ToArray())
            {
                query += key + ",";
            }
            query = query.Remove(query.Length - 1, 1) + ")";
            query += " VALUES(";
            foreach (string value in values.Values.ToArray())
            {
                query += value + ",";
            }
            query = query.Remove(query.Length - 1, 1) + ")";
            return query;
        }

        public override string ParseUpdateQuery(string tableName, Dictionary<string, string> setValues, string whereCondtion)
        {
            string query = "UPDATE " + tableName + " SET ";
            foreach (string key in setValues.Keys.ToArray())
            {
                query += key + "=" + setValues[key] + ",";
            }
            query = query.Remove(query.Length - 1, 1) + " WHERE " + whereCondtion;
            return query;
        }

        public override string ParseValue(Object obj, Type type)
        {
            if (type == typeof(string))
                return "\"" + obj.ToString() + "\"";
            else if (type == typeof(DateTime))
            {
                return "\"" + ((DateTime)obj).ToString("yyyy-MM-dd HH:mm:ss") + "\"";
            }
            return obj.ToString();
        }
    }
}
