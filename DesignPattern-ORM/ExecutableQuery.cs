using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    abstract class ExecutableQuery
    {
        protected string tableName;
        protected DBManager dbManager;
        protected ExecutableQuery(string tableName, DBManager dbManager)
        {
            this.tableName = tableName;
            this.dbManager = dbManager;
        }
        public abstract string getExecutableQuery();
        public abstract int Execute();
    }
}
