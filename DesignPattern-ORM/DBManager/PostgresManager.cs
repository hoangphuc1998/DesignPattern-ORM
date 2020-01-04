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
            try
            {
                Connect(host, port, database, username, password);
                Console.WriteLine("Connect Successfully");
            } catch
            {
                Console.WriteLine("Connect Failed");
            }
        }

        public override void Connect(string host, int port, string database, string username, string password)
        {
            String connString =
                "Host=" + host +
                ";Port=" + port.ToString() +
                ";Username=" + username +
                ";Password=" + password +
                ";Database=" + database;
            conn = new NpgsqlConnection(connString);
            conn.Open();
        }

        public override int Delete(string query)
        {
            return ExcecuteQuery(query);
        }

        public override void Disconnect()
        {
            conn.Close();
        }

        public override int Insert(string query)
        {
            Console.WriteLine(query);
            return ExcecuteQuery(query);
        }

        public override List<List<string>> Select(string query)
        {
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataReader pgReader = command.ExecuteReader();
            List<List<string>> lst = new List<List<string>>();
            List<string> row = new List<string>();
            for (int i = 0; i < pgReader.FieldCount; i++)
                row.Add(pgReader.GetName(i).ToLower());
            lst.Add(row);
            while (pgReader.Read())
            {
                row = new List<string>();
                for (int i = 0; i < pgReader.FieldCount; i++)
                    row.Add(pgReader[i].ToString());
                lst.Add(row);
            }
              //Console.Write("{0}\t{1} \n", dr[0], dr[1]);
            return lst;
        }

        public override int Update(string query)
        {
            return ExcecuteQuery(query);
        }
        private int ExcecuteQuery(string query)
        {
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            int rowCount = Convert.ToInt32(command.ExecuteScalar());
            return rowCount;
        }
    }
}
