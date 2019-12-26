using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DesignPattern_ORM
{
    class SelectQuery<T> where T:new()
    {
        protected string tableName;
        protected DBManager dbManager;
        protected Parser parser;
        protected List<string> projections;
        protected List<string> orderBy;
        protected Dictionary<string, string> featureMap;
        protected Dictionary<string, string> colMap;
        protected Disjunction condition;
        public SelectQuery(string tableName, DBManager dbManager, Parser parser, Dictionary<string, string> featureMap) 
        {
            this.tableName = tableName;
            this.dbManager = dbManager;
            this.parser = parser;
            this.projections = new List<string>();
            this.condition = new Disjunction();
            this.featureMap = featureMap;
            this.orderBy = new List<string>();
            colMap = new Dictionary<string, string>();
            foreach(string attr in featureMap.Keys)
            {
                colMap.Add(featureMap[attr], attr);
            }
        }
        public SelectQuery<T> Where(Condition condition)
        {
            this.condition.Add(condition);
            return this;
        }
        public List<Object> ToList()
        {
            string select = "";
            if (projections.Count == 0)
            {
                select = "*";
            }
            else
            {
                foreach (string projection in projections)
                {
                    select += featureMap[projection] + ",";
                }
                select = select.Remove(select.Length - 1, 1);
            }
            string conditionStr = condition.toSQL(featureMap);
            string order = "";
            if (orderBy.Count != 0)
            {
                foreach (string attr in orderBy)
                {
                    order += featureMap[attr] + ",";
                }
                order = order.Remove(order.Length - 1, 1);
            }
            List<List<string>> res = dbManager.Select(parser.ParseSelectQuery(tableName, select, conditionStr, orderBy:order));
            return ParseResult(res);
        }
        protected List<Object> ParseResult(List<List<string>> values)
        {
            List<Object> res = new List<Object>();
            Dictionary<int, string> colIndex = new Dictionary<int, string>();
            for (int i = 0; i< values[0].Count; i++)
            {
                colIndex.Add(i, values[0][i]);
            }
            for (int i = 1; i<values.Count; i++)
            {
                Object obj = new object();
                if (projections.Count == 0)
                {
                    obj = new T();
                    for (int j = 0; j < values[i].Count; j++)
                    {
                        Type type = typeof(T);
                        PropertyInfo propInfo = type.GetProperty(colMap[colIndex[j]]);
                        Object convertObj = Convert.ChangeType(values[i][j], propInfo.PropertyType);
                        propInfo.SetValue(obj, convertObj);
                    }
                }
                else
                {
                    //TODO: add parse for Dictionary
                }
                res.Add(obj);
            }
            return res;
        }
    }
}
