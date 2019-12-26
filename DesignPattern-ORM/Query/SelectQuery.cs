using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class SelectQuery<T>
    {
        protected string tableName;
        protected DBManager dbManager;
        protected Parser parser;
        protected List<string> projections;
        protected List<string> orderBy;
        protected Dictionary<string, string> featureMap;
        protected Disjunction condition;
        public SelectQuery(string tableName, DBManager dbManager, Parser parser, Dictionary<string, string> featureMap) 
        {
            this.tableName = tableName;
            this.dbManager = dbManager;
            this.parser = parser;
            this.projections = new List<string>();
            this.condition = new Disjunction();
            this.featureMap = featureMap;
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
