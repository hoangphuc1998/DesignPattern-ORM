using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class Equal : Restriction
    {
        public Equal(string a, Object b, string aggFunc = "")
        {
            param = a;
            value = b;
            this.aggFunc = aggFunc;
        }
        public override string getRestrictionOperator()
        {
            return "=";
        }
    }
}
