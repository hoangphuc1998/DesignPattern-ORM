using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    abstract class DBManager
    {
        public abstract void Connect(string host, int port, string database, string username, string password);
        public abstract void Disconnect();
        public abstract List<List<string>> Select(string query);
        public abstract int Insert(string query); //Return number of rows effected
        public abstract int Update(string query); //Return number of rows effected
        public abstract int Delete(string query); //Return number of rows effected
    }
}
