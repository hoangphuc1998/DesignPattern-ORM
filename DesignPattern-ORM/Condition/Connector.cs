using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    abstract class Connector:Condition
    {
        protected List<Condition> conditions;

        public abstract string getLogic();
        public override string toSQL(Dictionary<string, string> featureMap, string tableName)
        {
            string opt = getLogic();
            if (conditions.Count == 0)
            {
                return "";
            }
            string res = conditions[0].toSQL(featureMap, tableName);
            for (int i = 1; i<conditions.Count; i++)
            {
                res += " " + opt + " " + conditions[i].toSQL(featureMap, tableName);
            }
            res = "(" + res + ")";
            return res;
        }
        public Condition Add(Condition condition)
        {
            this.conditions.Add(condition);
            return this;
        }
    }
}
