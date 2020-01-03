using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace DesignPattern_ORM
{
    class PostgresManager : DBManager
    {
        private NpgsqlConnection conn;
        public PostgresManager(string host, int port, string database, string username, string password)
        {
            String connString = 
                "Host=" + host + 
                ";Port=" + port.ToString() +
                ";Username=" + username +
                ";Password=" + password +
                ";Database=" + database;
            conn = new NpgsqlConnection(connString);
            try
            {
                conn.Open();
                Console.WriteLine("Connect Successfully");
            } catch
            {
                Console.WriteLine("Connect Failed");
            }
        }
    }
}
