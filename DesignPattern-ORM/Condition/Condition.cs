using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    abstract class Condition
    {
        // protected bool isNot = false;
        public abstract string toSQL();
        /**
         USAGE
        
         * */
         public static Condition And(Condition a, Condition b)
        {
            return new And(a, b);
        }
        public static Condition Or(Condition a, Condition b)
        {
            return new Or(a, b);
        }
        public static Condition lt(string a, Object b)
        {
            return new LessThan(a, b);
        }

        public static Condition equal(string a, Object b)
        {
            return new Equal(a, b);
        }
        public 
    }
}
