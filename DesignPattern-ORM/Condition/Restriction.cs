using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    abstract class Restriction:Condition
    {   
        protected string param { get; set; }
        protected Object value { get; set; }
        protected string aggFunc { get; set; }
        public abstract string getRestrictionOperator();
        public Restriction(string param, Object value, string aggFunc)
        {
            this.param = param;
            this.value = value;
            this.aggFunc = aggFunc;
        }
        public string parseValue(Object obj)
        {
            Type type = obj.GetType();
            if (type == typeof(string))
                return "\"" + obj.ToString() + "\"";
            else if (type == typeof(DateTime))
            {
                return "\"" + ((DateTime)obj).ToString("yyyy-MM-dd HH:mm:ss") + "\"";
            }
            return obj.ToString();
        }
        public override string toSQL(Dictionary<string, string> featureMap, string tableName)
        {
            if (featureMap.ContainsKey(param) == false)
            {
                throw new Exception("There is no \"" + param + "\" attribute in class");
            }
            string attr = featureMap[param];
            attr = tableName + "." + attr;
            if (aggFunc.Length != 0)
            {
                attr = aggFunc + "(" + attr + ")";
            }
            return attr + getRestrictionOperator() + parseValue(value);
        }
    }
}
