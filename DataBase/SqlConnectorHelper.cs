﻿using System.Data;
using System.Data.SqlClient;

namespace DataBase
{
    class SqlConnectorHelper
    {
        private SqlConnection connection;

        public void ConnectToDataBase()
        {
            connection = new SqlConnection("Server = DESKTOP-Q1KV8N7\\SQLEXPRESS; Database = Airport; Integrated Security = true");
            this.connection.Open();
        }

        public DataTable MakeQuery(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (!query.StartsWith("SELECT")) return null;
            return table;
        }

        public void CloseConnection()
        {
            connection.Close();
        }
    }
}
