using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_ORM
{
    abstract class DBManager
    {
        public abstract void Connect(string host, int port, string database, string username, string password);
        public abstract List<Lis<string>> Select(string querry);
        public abstract int Insert(string querry); //Return number of rows effected
        public abstract int Update(string querry); //Return number of rows effected
        public abstract int Delete(string querry); //Return number of rows effected
    }
}
