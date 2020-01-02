using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class GreaterThan : Restriction
    {
        public GreaterThan(string a, Object b, string aggFunc = "") : base(a, b, aggFunc)
        {

        }
        public override string getRestrictionOperator()
        {
            return ">";
        }
    }
}
