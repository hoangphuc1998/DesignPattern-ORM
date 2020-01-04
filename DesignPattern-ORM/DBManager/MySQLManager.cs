using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data;

namespace DesignPattern_ORM
{
    class MySQLManager : DBManager
    {
        private MySqlConnection connection;
        public override void Connect(string host, int port, string database, string username, string password)
        {
            String connString = GetConnectionString(host, port, database, username, password);
            connection = new MySqlConnection(connString);
            connection.Open();
        }
        public override void Disconnect()
        {
            connection.Close();
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
        public override List<List<string>> Select(string query)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = query;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                int numCol = reader.FieldCount;
                List<List<string>> res = new List<List<string>>();
                List<string> firstRow = new List<string>();
                for (int j = 0; j < numCol; j++)
                {
                    firstRow.Add(reader.GetName(j).ToLower());
                }
                res.Add(firstRow);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        List<string> row = new List<string>();
                        for (int j = 0; j < numCol; j++)
                        {
                            row.Add(reader.GetString(j));
                        }
                        res.Add(row);
                    }
                }
                return res;
            }
        }
        private int ExcecuteQuery(string query)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;
            cmd.Connection = connection;
            int rowCount = cmd.ExecuteNonQuery();
            return rowCount;
        }
        public override int Insert(string query)
        {
            return ExcecuteQuery(query);
        }
        public override int Update(string query)
        {
            return ExcecuteQuery(query);
        }
        public override int Delete(string query)
        {
            return ExcecuteQuery(query);
        }
    }
}
