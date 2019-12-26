using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern_ORM
{
    class InsertQuery : ExecutableQuery
    {
        private Dictionary<string, Object> values;
        public InsertQuery(string tableName, DBManager dbManager, Parser parser,Dictionary<string, string> featureMap, Dictionary<string, Object> values) : base(tableName, dbManager, parser, featureMap)
        {
            this.values = values;
        }

        public override int Execute()
        {
            Dictionary<string, string> valuesMap = new Dictionary<string, string>();
            foreach (KeyValuePair<string, Object> keyValuePair in values)
            {
                string parsed = parser.ParseValue(keyValuePair.Value, keyValuePair.Value.GetType());
                valuesMap.Add(keyValuePair.Key, parsed);
            }
            return dbManager.Insert(this.parser.ParseInsertQuery(this.tableName, valuesMap));
        }
    }
}
