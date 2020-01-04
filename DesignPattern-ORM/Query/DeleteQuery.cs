using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class DeleteQuery : ExecutableQuery
    {
        Disjunction condition = new Disjunction();
        public DeleteQuery(string tableName, DBManager dbManager, Parser parser, Dictionary<string, string> featureMap, Condition condition) : base(tableName, dbManager, parser, featureMap)
        {
            this.condition.Add(condition);
        }
        public DeleteQuery(string tableName, DBManager dbManager, Parser parser, Dictionary<string, string> featureMap) : base(tableName, dbManager, parser, featureMap) { }
        public DeleteQuery Where(Condition condition)
        {
            this.condition.Add(condition);
            return this;
        }
        public override int Execute()
        {
            string conditionStr = condition.toSQL(featureMap, tableName);
            if (conditionStr.Length == 0)
            {
                throw new Exception("Delete condition is not specified");
            }
            return dbManager.Delete(parser.ParseDeleteQuery(tableName, conditionStr));
        }
    }
}
