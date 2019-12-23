using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    abstract class Restriction:Condition
    {
        protected string param { get; set; }
        protected string value { get; set; }
        public abstract string getRestrictionOperator();
        public override string toSQL()
        {
            return param + getRestrictionOperator() + value;
        }
    }
}
