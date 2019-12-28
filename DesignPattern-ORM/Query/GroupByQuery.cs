using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class GroupBy<T> : SelectQuery<T> where T: new()
    {
        protected SelectQuery<T> wrapeeQuery;
        public static string COUNT = "COUNT";
        public GroupBy(SelectQuery<T> wrapee)
        {
            this.wrapeeQuery = wrapee;
        }
        protected override string GetProjectionStr()
        {
            return base.GetProjectionStr();
        }
        public new GroupBy<T> Where(Condition condition)
        {
            this.wrapeeQuery.Where(condition);
            return this;
        }
    }
}
