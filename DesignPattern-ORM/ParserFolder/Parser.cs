using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    abstract class Parser
    {
        public abstract string ParseValue(Object obj, Type type);
        public abstract string ParseInsertQuery(string tableName, Dictionary<string, string> values);
        public abstract string ParseDeleteQuery(string tableName, string whereCondition);
        public abstract string ParseUpdateQuery(string tableName, Dictionary<string, string> setValues, string whereCondtion);
    }
}
