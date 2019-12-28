using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DesignPattern_ORM
{
    class SelectQuery<T> where T:new()
    {
        public int ASC = 0;
        public int DESC = 1;
        protected string tableName;
        protected DBManager dbManager;
        protected Parser parser;
        protected Dictionary<string, string> projections;
        protected Dictionary<string, int> orderBy;
        protected Dictionary<string, string> featureMap;
        protected Dictionary<string, string> colMap;
        protected Disjunction condition;
        public SelectQuery() { }
        public SelectQuery(string tableName, DBManager dbManager, Parser parser, Dictionary<string, string> featureMap) 
        {
            this.tableName = tableName;
            this.dbManager = dbManager;
            this.parser = parser;
            this.projections = new Dictionary<string, string>();
            this.condition = new Disjunction();
            this.featureMap = featureMap;
            this.orderBy = new Dictionary<string, int>();
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
        public SelectQuery<T> AddProjection(string attr, string alias = "")
        {
            if (alias.Length == 0)
            {
                alias = attr;
            }
            this.projections.Add(attr, alias);
            return this;
        }
        public SelectQuery<T> OrderBy(string attr, string order = "ASC")
        {
            if (order.Equals("DECS"))
            {
                this.orderBy.Add(attr, DESC);
            }
            else
            {
                this.orderBy.Add(attr, ASC);
            }
            return this;
        }
        protected virtual string GetProjectionStr()
        {
            string select = "";
            if (projections.Count == 0)
            {
                select = "*";
            }
            else
            {
                foreach (string projection in projections.Keys)
                {
                    select += featureMap[projection] + " AS " + projections[projection] + ",";
                }
                select = select.Remove(select.Length - 1, 1);
            }
            return select;
        }
        protected virtual string GetConditionStr()
        {
            return condition.toSQL(featureMap);
        }
        protected virtual string GetOrderStr()
        {
            string order = "";
            if (orderBy.Count != 0)
            {
                foreach (string attr in orderBy.Keys)
                {
                    order += featureMap[attr];
                    if (orderBy[attr] == DESC)
                    {
                        order += " DESC, ";
                    }
                    else
                    {
                        order += " ASC, ";
                    }
                }
                order = order.Remove(order.Length - 1, 1);
            }
            return order;
        }
        protected virtual string GetGroupByStr()
        {
            return "";
        }
        protected virtual string GetHavingStr()
        {
            return "";
        }
        public List<Object> ToList()
        {
            string selectStr = GetProjectionStr();
            string conditionStr = GetConditionStr();
            string groupByStr = GetGroupByStr();
            string orderStr = GetOrderStr();
            string havingStr = GetHavingStr();

            List<List<string>> res = dbManager.Select(parser.ParseSelectQuery(tableName, selectStr, conditionStr, groupByStr, havingStr, orderStr));
            return ParseResult(res);
        }
        protected List<Object> ParseResult(List<List<string>> values)
        {
            List<Object> res = new List<Object>();
            Dictionary<int, string> colIndex = new Dictionary<int, string>();
            Type type = typeof(T);
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
                        PropertyInfo propInfo = type.GetProperty(colMap[colIndex[j]]);
                        Object convertObj = Convert.ChangeType(values[i][j], propInfo.PropertyType);
                        propInfo.SetValue(obj, convertObj);
                    }
                }
                else
                {
                    obj = new Dictionary<string, Object>();
                    for (int j = 0; j < values[i].Count; j++)
                    {
                        string propName = colMap[colIndex[j]];
                        PropertyInfo propInfo = type.GetProperty(propName);
                        Object convertObj = Convert.ChangeType(values[i][j], propInfo.PropertyType);
                        ((Dictionary<string, Object>)obj).Add(propName, convertObj);
                    }
                }
                res.Add(obj);
            }
            return res;
        }
    }
}
