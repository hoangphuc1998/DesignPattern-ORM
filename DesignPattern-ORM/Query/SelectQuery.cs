using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class SelectQuery<T>
    {
        private string tableName;
        private DBManager dbManager;
        private Parser parser;
        private List<string> projections;
        private List<string> orderBy;
        private Disjunction condition;
        public SelectQuery(string tableName, DBManager dbManager, Parser parser) 
        {
            this.tableName = tableName;
            this.dbManager = dbManager;
            this.parser = parser;
            this.projections = new List<string>();
            this.condition = new Disjunction();
        }
        public SelectQuery<T> Where(Condition condition)
        {
            this.condition.Add(condition);
            return this;
        }
        public List<Object> ToList()
        {

            throw new NotImplementedException();
        }
    }
}
