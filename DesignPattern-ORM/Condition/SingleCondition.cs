using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    abstract class SingleCondition:Condition
    {
        protected Condition leftCondition;
        protected Condition rightCondition;

        public abstract string getLogic();
        public override string toSQL()
        {
            return "( " + leftCondition.toSQL() + " " + getLogic() + " " + rightCondition.toSQL() + " )";
        }
    }
}
