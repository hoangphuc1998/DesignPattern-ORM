using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    abstract class Condition
    {
        // protected bool isNot = false;
        public abstract string toSQL(Dictionary<string, string> featureMap);
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
        public static LessThan LessThan(string a, Object b, string aggFunc = "")
        {
            return new LessThan(a, b, aggFunc);
        }

        public static Equal Equal(string a, Object b, string aggFunc = "")
        {
            return new Equal(a, b, aggFunc);
        }
        public static GreaterThan GreaterThan(string a, Object b, string aggFunc = "")
        {
            return new GreaterThan(a, b, aggFunc);
        }
        public static GreaterThanOrEqual GreaterThanOrEqual(string a, Object b, string aggFunc = "")
        {
            return new GreaterThanOrEqual(a, b, aggFunc);
        }
        public static LessThanOrEqual LessThanOrEqual(string a, Object b, string aggFunc = "")
        {
            return new LessThanOrEqual(a, b, aggFunc);
        }
        public static Like Like(string a, Object b, string aggFunc = "")
        {
            return new Like(a, b, aggFunc);
        }
        public static Not Not(Condition condition)
        {
            return new Not(condition);
        }
    }
}
