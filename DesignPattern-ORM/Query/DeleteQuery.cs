using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class DeleteQuery : ExecutableQuery
    {
        Condition condition;
        public DeleteQuery(string tableName, DBManager dbManager, Parser parser) : base(tableName, dbManager, parser) { }
        public override int Execute()
        {
            throw new NotImplementedException();
        }
    }
}
