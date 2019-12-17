using System;
using System.Collections.Generic;
using System.Text;
namespace DesignPattern_ORM
{
    abstract class ExecutableQuery
    {
        protected string tableName;
        protected DBManager dbManager;
        protected Parser parser;
        protected ExecutableQuery(string tableName, DBManager dbManager, Parser parser)
        {
            this.tableName = tableName;
            this.dbManager = dbManager;
            this.parser = parser;
        }
        public abstract int Execute();
    }
}
