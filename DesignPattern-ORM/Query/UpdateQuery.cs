using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class UpdateQuery : ExecutableQuery
    {
        private Dictionary<string, Object> updateValues = new Dictionary<string, Object>();
        private Disjunction condition = new Disjunction();

        public UpdateQuery(string tableName, DBManager dbManager, Parser parser,Dictionary<string, string> featureMap, Dictionary<string, Object> updateValues, Condition condition)
            :base(tableName, dbManager, parser, featureMap)
        {
            this.updateValues = updateValues;
            this.condition.Add(condition);
        }
        public UpdateQuery(string tableName, DBManager dbManager, Parser parser, Dictionary<string, string> featureMap) : base(tableName, dbManager, parser, featureMap) { }
        public UpdateQuery Where(Condition condition)
        {
            this.condition.Add(condition);
            return this;
        }
        public UpdateQuery Set(string attr, Object value)
        {
            this.updateValues.Add(attr, value);
            return this;
        }
        public override int Execute()
        {
            if (updateValues.Count == 0)
            {
                throw new Exception("There is nothing to update");
            }
            string conditionStr = condition.toSQL(featureMap);
            if (conditionStr.Length == 0)
            {
                throw new Exception("Update condition is not specified");
            }
            Dictionary<string, string> values = new Dictionary<string, string>();
            foreach(string key in this.updateValues.Keys)
            {
                Object value = this.updateValues[key];
                values.Add(key, parser.ParseValue(value, value.GetType()));
            }
            string query = parser.ParseUpdateQuery(this.tableName, values, conditionStr);
            return dbManager.Update(query);
        }
    }
}
