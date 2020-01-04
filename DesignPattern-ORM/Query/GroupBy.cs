using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace DesignPattern_ORM
{
    class GroupByQuery<T> : SelectQuery<T> where T: new()
    {
        protected SelectQuery<T> wrapeeQuery;
        protected List<string> groupBy;
        protected Disjunction havingCondition;
        public GroupByQuery(SelectQuery<T> wrapee)
        {
            this.wrapeeQuery = wrapee;
            this.groupBy = new List<string>();
            this.havingCondition = new Disjunction();
            this.tableName = this.wrapeeQuery.tableName;
            this.dbManager = this.wrapeeQuery.dbManager;
            this.parser = this.wrapeeQuery.parser;
        }
        public override string GetProjectionStr()
        {
            return this.wrapeeQuery.GetProjectionStr();
        }
        public override string GetConditionStr()
        {
            return this.wrapeeQuery.GetConditionStr();
        }
        public override string GetOrderStr()
        {
            return this.wrapeeQuery.GetOrderStr();
        }
        public override string GetHavingStr()
        {
            return this.havingCondition.toSQL(this.wrapeeQuery.featureMap, this.wrapeeQuery.tableName);
        }
        public override string GetGroupByStr()
        {
            if (this.groupBy.Count == 0)
            {
                return "";
            }
            string groupByStr = "";
            foreach (string attr in this.groupBy)
            {
                groupByStr += attr + ",";
            }
            groupByStr = groupByStr.Remove(groupByStr.Length - 1, 1);
            return groupByStr;
        }
        public new GroupByQuery<T> Where(Condition condition)
        {
            this.wrapeeQuery.Where(condition);
            return this;
        }
        public GroupByQuery<T> AddProjection(string attr, string aggFunc = "", string alias = "")
        {
            if (aggFunc.Length != 0 && alias.Length == 0)
            {
                throw new Exception("Alias for Aggegate function is not specified");
            }
            string aggAttr = this.wrapeeQuery.featureMap[attr];
            if (aggFunc.Length != 0)
            {
                aggAttr = aggFunc + "(" + aggAttr + ")";
            }
            if (alias.Length == 0)
            {
                alias = attr;
            }
            this.wrapeeQuery.projections.Add(aggAttr, alias);
            this.wrapeeQuery.aliasMap.Add(alias, attr);
            return this;
        }
        public new GroupByQuery<T> GroupBy(string attr)
        {
            this.groupBy.Add(this.wrapeeQuery.featureMap[attr]);
            return this;
        }
        public new GroupByQuery<T> OrderBy(string attr, string order = "ASC")
        {
            this.wrapeeQuery.OrderBy(attr, order);
            return this;
        }
        public GroupByQuery<T> Having(Condition condition)
        {
            this.havingCondition.Add(condition);
            return this;
        }
        public override List<object> ParseResult(List<List<string>> values)
        {
            if (this.wrapeeQuery.projections.Count == 0)
            {
                foreach (string key in this.wrapeeQuery.featureMap.Keys)
                {

                    this.wrapeeQuery.aliasMap.Add(this.wrapeeQuery.featureMap[key], key);
                }
            }
            List<Object> res = new List<Object>();
            Dictionary<int, string> colIndex = new Dictionary<int, string>();
            Type type = typeof(T);
            for (int i = 0; i < values[0].Count; i++)
            {
                colIndex.Add(i, values[0][i]);
            }
            for (int i = 1; i < values.Count; i++)
            {
                Object obj = new object();
                if (this.wrapeeQuery.projections.Count == 0)
                {
                    obj = new T();

                    for (int j = 0; j < values[i].Count; j++)
                    {
                        PropertyInfo propInfo = type.GetProperty(this.wrapeeQuery.aliasMap[colIndex[j]]);
                        Object convertObj = Convert.ChangeType(values[i][j], propInfo.PropertyType);
                        propInfo.SetValue(obj, convertObj);
                    }
                }
                else
                {
                    obj = new Dictionary<string, Object>();
                    for (int j = 0; j < values[i].Count; j++)
                    {
                        string propName = this.wrapeeQuery.aliasMap[colIndex[j]];
                        PropertyInfo propInfo = type.GetProperty(propName);
                        Object convertObj = Convert.ChangeType(values[i][j], propInfo.PropertyType);
                        ((Dictionary<string, Object>)obj).Add(colIndex[j], convertObj);
                    }
                }
                res.Add(obj);
            }
            return res;
        }
    }
}
