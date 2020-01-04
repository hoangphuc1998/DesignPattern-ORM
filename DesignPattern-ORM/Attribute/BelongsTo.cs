using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DesignPattern_ORM
{
    [AttributeUsage(AttributeTargets.All)]
    class BelongsTo : FlagsAttribute
    {
        public string className { get; set; }
        public string foreignKey { get; set; }
        public BelongsTo(string name, string fk)
        {
            className = name;
            foreignKey = fk;
        }
    }
}
