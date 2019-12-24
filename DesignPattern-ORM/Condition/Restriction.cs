using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    abstract class Restriction:Condition
    {   
        protected string param { get; set; }
        protected Object value { get; set; }
        public abstract string getRestrictionOperator();
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
        public override string toSQL()
        {
            return param + getRestrictionOperator() + parseValue(value);
        }
    }
}
