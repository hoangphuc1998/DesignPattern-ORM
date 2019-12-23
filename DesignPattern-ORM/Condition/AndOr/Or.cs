using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class Or:SingleCondition
    {
        public Or(Condition a, Condition b)
        {
            leftCondition = a;
            rightCondition = b;
        }
        public override string getLogic()
        {
            return "OR";
        }
    }
}
