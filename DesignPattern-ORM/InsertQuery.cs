using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern_ORM
{
    class InsertQuery : ExecutableQuery
    {
        private Dictionary<string, string> values;
        public InsertQuery(string tableName, DBManager dbManager, Dictionary<string, string> values) : base(tableName, dbManager)
        {
            this.values = values;
        }
        public override string getExecutableQuery()
        {
            string query = "INSERT INTO " + this.tableName + "(";
            foreach (string key in this.values.Keys.ToArray()){
                query += key + ",";
            }
            query = query.Remove(query.Length - 1, 1) + ")";
            query += " VALUES(";
            foreach (string value in this.values.Values.ToArray())
            {
                query += value + ",";
            }
            query = query.Remove(query.Length - 1, 1) + ")";
            return query;
        }

        public override int Execute()
        {
            return dbManager.Insert(getExecutableQuery());
        }
    }
}
