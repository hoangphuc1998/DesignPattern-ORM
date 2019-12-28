using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class LessThan : Restriction
    {
        public LessThan(string a, Object b, string aggFunc = "") {
            param = a;
            value = b;
            this.aggFunc = aggFunc;
        }
        public override string getRestrictionOperator()
        {
            return "<";
        }
    }
}
