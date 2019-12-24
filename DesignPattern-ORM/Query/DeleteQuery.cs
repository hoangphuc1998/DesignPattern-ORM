using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class DeleteQuery : ExecutableQuery
    {
        Condition condition;
        public DeleteQuery(string tableName, DBManager dbManager, Parser parser, Condition condition) : base(tableName, dbManager, parser)
        {
            this.condition = condition;
        }
        public override int Execute()
        {
            return dbManager.Delete(parser.ParseDeleteQuery(tableName, condition.toSQL()));
        }
    }
}
