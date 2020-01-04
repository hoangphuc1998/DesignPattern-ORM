using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace DesignPattern_ORM
{
    class Include<T> where T : new()
    {
        private SelectQuery<T> wrappee;
        private string otherTable;
        private string insideKey;
        private string forgeinKey;
        public Include(SelectQuery<T> w, Type included)
            {
            HasMany pInfo = getIncluded(included.ToString());
            if (pInfo != null)
            {
                wrappee = w;
                otherTable = included.GetCustomAttribute<TableName>().tableName;
                insideKey = pInfo.key.ToLower();
                forgeinKey = pInfo.foreignKey.ToLower();
            }
            else
            {
                throw new Exception(typeof(T).ToString() + " doesn't has many " + included.ToString());
            }

        }

        private HasMany getIncluded(string included)
        {
            Type type = typeof(T);
            PropertyInfo[] propertyInfo = type.GetProperties();
            foreach (PropertyInfo pInfo in propertyInfo)
            {
                HasMany hasMany = pInfo.GetCustomAttribute<HasMany>();
                if (hasMany == null) continue;
                if (hasMany.className.ToLower() == included.Replace("DesignPattern_ORM.", "").ToLower() )
                {
                    return hasMany;
                }
            }
            return null; 
        }

        public List<Object> ToList()
        {
            string selectStr = wrappee.GetProjectionStr();
            string conditionStr = wrappee.GetConditionStr();
            string orderStr = wrappee.GetOrderStr();

            string join = string.Format("{0} join {1} on {0}.{2} = {1}.{3}", wrappee.tableName, otherTable, insideKey, forgeinKey);
            Console.WriteLine(join);
            List<List<string>> res = wrappee.dbManager.Select(wrappee.parser.ParseSelectQuery(join, selectStr, conditionStr, "", "", orderStr));
            for (int i = 0; i < res.Count; i++)
            {
                for (int j = 0; j < res[i].Count; j++) Console.Write(res[i][j] + " ");
                Console.WriteLine();
            }
            return null;

        }
    }
}
