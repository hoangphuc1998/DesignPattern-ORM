using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class And:SingleCondition
    {
        public And(Condition a, Condition b)
        {
            leftCondition = a;
            rightCondition = b;
        }
        public override string getLogic()
        {
            return "AND";
        }
    }
}
