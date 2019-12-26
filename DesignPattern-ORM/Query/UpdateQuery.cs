using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM.Query
{
    class UpdateQuery : ExecutableQuery
    {
        private Dictionary<string, Object> updateValues = new Dictionary<string, Object>();
        private Condition condition;

        public UpdateQuery(string tableName, DBManager dbManager, Parser parser, Dictionary<string, Object> updateValues, Condition condition)
            :base(tableName, dbManager, parser)
        {
            this.updateValues = updateValues;
            this.condition = condition;
        }
        public override int Execute()
        {
            throw new NotImplementedException();
        }
    }
}
