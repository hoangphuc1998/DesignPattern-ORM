using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DesignPattern_ORM
{
    [AttributeUsage(AttributeTargets.All)]
    class HasMany : FlagsAttribute
    {
        public string className { get; set; }
        public string key { get; set; }
        public string foreignKey { get; set; }
        public HasMany(string name, string inside, string fk)
        {
            className = name;
            key = inside;
            foreignKey = fk;
        }
    }
}
