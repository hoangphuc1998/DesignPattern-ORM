using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    abstract class DBManager
    {
        public abstract void Connect(string host, int port, string database, string username, string password);
      
    }
}
