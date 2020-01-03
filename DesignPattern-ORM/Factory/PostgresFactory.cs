using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    class PostgresFactory : DBFactory
    {
        public DBManager CreateDBManager(string host, int port, string database, string username, string password)
        {
            return new PostgresManager(host, port, database, username, password);
        }

        public Parser CreateParser()
        {
            return new PostgresParser();
        }
    }
}
