using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;

namespace DesignPattern_ORM
{
    class Include<T> where T : new()
    {
        private SelectQuery<T> wrappee;
        private Type included;
        private string otherTable;
        private string insideKey;
        private string forgeinKey;
        private PropertyInfo hasManyAttr;
        public Dictionary<string, string> aliasMap = new Dictionary<string, string>();
        private string[] projection;
        private Dictionary<string, string> featureMap = new Dictionary<string, string>();
        public Include(SelectQuery<T> w, Type included, string[] projection)
            {
            int matchProjection = projection.Length;
            HasMany pInfo = getIncluded(included.ToString());
            if (pInfo != null)
            {
                wrappee = w;
                otherTable = included.GetCustomAttribute<TableName>().tableName;
                insideKey = pInfo.key.ToLower();
                forgeinKey = pInfo.foreignKey.ToLower();

                PropertyInfo[] propertyInfo = included.GetProperties();
                foreach (PropertyInfo pInfoIncluded in propertyInfo)
                {
                    if (pInfoIncluded.GetCustomAttribute<Column>() == null)
                    {
                        continue;
                    };
                    featureMap.Add(pInfoIncluded.Name, pInfoIncluded.GetCustomAttribute<Column>().columnName.ToLower());
                    aliasMap.Add(pInfoIncluded.GetCustomAttribute<Column>().columnName.ToLower(), pInfoIncluded.Name);
                    if (isValid(pInfoIncluded.Name, projection)) matchProjection--;
                }
                if (matchProjection != 0)
                {
                    throw new Exception("Invalid projection attribute.");
                }
                this.projection = projection;
                this.included = included;
            }
            else
            {
                throw new Exception(typeof(T).ToString() + " doesn't has many " + included.ToString());
            }

        }
        private bool isValid(string attr, string[] lst)
        {
            for (int i = 0; i < lst.Length; i++)
            {
                if (lst[i] == attr) return true;
            }
            return false;
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
                    hasManyAttr = pInfo;
                    return hasMany;
                }
            }
            return null; 
        }

        private string GetUnique() {
            Type type = typeof(T);
            PropertyInfo[] propertyInfo = type.GetProperties();
            foreach (PropertyInfo pInfo in propertyInfo)
            {
                if (pInfo.GetCustomAttribute<Column>() == null)
                {
                    continue;
                };
                if (pInfo.GetCustomAttribute<Column>().isKey == true)
                {
                    return pInfo.Name;
                }
            }
            return null;
        }
        private string GetProjectionStr()
        {
            string primaryKey = GetUnique();
            //Console.WriteLine(primaryKey + " " + featureMap[primaryKey]);
            string ans = wrappee.tableName + "." + featureMap[primaryKey] + ",";
            
            ans += wrappee.GetProjectionStr();
            if (ans.Length > 0) ans += ",";
            foreach(string attr in projection)
            {
                ans += otherTable + "." + featureMap[attr] + ",";
            }
            return ans.Substring(0, ans.Length - 1);
        }
        public List<Object> ToList()
        {
            string selectStr = GetProjectionStr();
            string conditionStr = wrappee.GetConditionStr();
            string orderStr = wrappee.GetOrderStr();

            string join = string.Format("{0} left join {1} on {0}.{2} = {1}.{3}", wrappee.tableName, otherTable, insideKey, forgeinKey);
            string[] header = selectStr.Split(',');

            //foreach (string s in selectStr.Split(',')) Console.WriteLine(s);
            
            List<List<string>> v = wrappee.dbManager.Select(wrappee.parser.ParseSelectQuery(join, selectStr, conditionStr, "", "", orderStr));

            List<List<string>> baseList = new List<List<String>>();
            int numColBase = 0;
            for (int i = 0; i < header.Length; i++)
            {
                if (header[i].IndexOf(wrappee.tableName) != 0)
                {
                    numColBase = i;
                    break;
                } 
            }
            
            List<object> includedObject = new List<object>();
            for (int i = 0; i < v.Count; i++)
            {
                List<string> tmp = new List<string>();
                for (int j = 1; j < numColBase; j++)
                {
                    tmp.Add(v[i][j]);
                }
                if (baseList.Count == 0 || v[i][0] != v[i - 1][0])
                {
                    baseList.Add(tmp);
                }
            }


            object instance = null;
            IList list = null;
            int current = -1;
            List<object> finalList = wrappee.ParseResult(baseList);
            for (int i = 1; i < v.Count; i++)
            {
                if (v[i][0] != v[i-1][0])
                {
                    current += 1;
                    instance = Activator.CreateInstance(hasManyAttr.PropertyType);
                    list = (IList)instance;
                    hasManyAttr.SetValue(finalList[current], list, null);
                }
                object x = Activator.CreateInstance(included); 
                for (int j = numColBase; j < v[i].Count; j++)
                {
                    PropertyInfo propInfo = included.GetProperty(aliasMap[v[0][j]]);
                    Object convertObj = Convert.ChangeType(v[i][j], propInfo.PropertyType);
                    propInfo.SetValue(x, convertObj);
                }
                list.Add(x);

            }
            //Console.WriteLine(finalList.GetType().GetGenericArguments()[0]);
            
            return finalList;

        }
    }
}
