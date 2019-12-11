using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace DesignPattern_ORM
{
    class MySQLManager : DBManager
    {
        private MySqlConnection connection;
        public override void Connect(string host, int port, string database, string username, string password)
        {
            String connString = GetConnectionString(host, port, database, username, password);
            connection = new MySqlConnection(connString);
        }

        public string GetConnectionString(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;
            return connString;
        }

        public MySQLManager(string host, int port, string database, string username, string password)
        {
            try
            {
                Connect(host, port, database, username, password);
                Console.WriteLine("Connect Successfully");
            }
            catch
            {
                Console.WriteLine("Connect Failed");
            }
        }
    }
}
