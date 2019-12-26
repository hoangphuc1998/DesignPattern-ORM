using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    abstract class SingleCondition:Condition
    {
        protected List<Condition> conditions;

        public abstract string getLogic();
        public override string toSQL()
        {
            string opt = getLogic();
            if (conditions.Count == 0)
            {
                return "";
            }
            string res = conditions[0].toSQL();
            for (int i = 1; i<conditions.Count; i++)
            {
                res += " " + opt + " " + conditions[i].toSQL();
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
