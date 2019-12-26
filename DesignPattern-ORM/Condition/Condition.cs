using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    abstract class Condition
    {
        // protected bool isNot = false;
        public abstract string toSQL(Dictionary<string, string> featureMap, string aggFunc = "");
        /**
         USAGE
        
         * */
         public static Conjunction And(Condition a, Condition b)
        {
            return new Conjunction(a, b);
        }
        public static Disjunction Or(Condition a, Condition b)
        {
            return new Disjunction(a, b);
        }
        public static Conjunction Conjunction()
        {
            return new Conjunction();
        }
        public static Disjunction Disjunction()
        {
            return new Disjunction();
        }
        public static LessThan LessThan(string a, Object b)
        {
            return new LessThan(a, b);
        }

        public static Equal Equal(string a, Object b)
        {
            return new Equal(a, b);
        }
    }
}
