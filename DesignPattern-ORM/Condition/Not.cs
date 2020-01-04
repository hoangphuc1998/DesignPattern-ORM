using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class Not : Condition
    {
        protected Condition coreCondition;
        public Not(Condition condition)
        {
            this.coreCondition = condition;
        }
        public override string toSQL(Dictionary<string, string> featureMap, string tableName)
        {
            return "(NOT " + coreCondition.toSQL(featureMap, tableName) + ")";
        }
    }
}
