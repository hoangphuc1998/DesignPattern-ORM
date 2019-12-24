using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class Equal : Restriction
    {
        public Equal(string a, Object b)
        {
            param = a;
            value = b;
        }
        public override string getRestrictionOperator()
        {
            return "=";
        }
    }
}
