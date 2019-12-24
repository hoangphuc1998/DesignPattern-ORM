using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    abstract class Condition
    {
        // protected bool isNot = false;
        public abstract string toSQL();
        /**
         USAGE
        
         * */
    }
}
