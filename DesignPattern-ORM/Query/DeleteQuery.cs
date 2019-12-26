using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class DeleteQuery : ExecutableQuery
    {
        Disjunction condition = new Disjunction();
        public DeleteQuery(string tableName, DBManager dbManager, Parser parser, Condition condition) : base(tableName, dbManager, parser)
        {
            this.condition.Add(condition);
        }
        public DeleteQuery(string tableName, DBManager dbManager, Parser parser) : base(tableName, dbManager, parser) { }
        public DeleteQuery Where(Condition condition)
        {
            this.condition.Add(condition);
            return this;
        }
        public override int Execute()
        {
            string conditionStr = condition.toSQL();
            if (conditionStr.Length == 0)
            {
                throw new Exception("Delete condition is not specified");
            }
            return dbManager.Delete(parser.ParseDeleteQuery(tableName, conditionStr));
        }
    }
}
