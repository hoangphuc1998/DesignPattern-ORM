using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class MySQLFactory : DBFactory
    {
        public DBManager CreateDBManager(string host, int port, string database, string username, string password)
        {
            return new MySQLManager(host, port, database, username, password);
        }

        public Parser CreateParser()
        {
            return new MySQLParser();
        }
    }
}
