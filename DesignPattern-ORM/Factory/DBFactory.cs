using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    interface DBFactory
    {
        public abstract DBManager CreateDBManager(string host, int port, string database, string username, string password);
        public abstract Parser CreateParser();
    }
}
