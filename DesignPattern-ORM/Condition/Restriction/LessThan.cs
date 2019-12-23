using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class LessThan : Restriction
    {
        public LessThan(string a, string b) {
            param = a;
            value = b;
        }
        public override string getRestrictionOperator()
        {
            return "<";
        }
    }
}
