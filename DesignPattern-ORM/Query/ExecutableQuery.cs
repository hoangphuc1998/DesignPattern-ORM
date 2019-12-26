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
        protected Dictionary<string, string> featureMap;
        protected ExecutableQuery(string tableName, DBManager dbManager, Parser parser, Dictionary<string, string> featureMap)
        {
            this.tableName = tableName;
            this.dbManager = dbManager;
            this.parser = parser;
            this.featureMap = featureMap;
        }
        public abstract int Execute();
    }
}
