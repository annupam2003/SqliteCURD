using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace SqliteAdoDotNet.DatabaseHandler
{
    public class SqliteDatabaseHandler
    {
        readonly string connectionString = @"data source = c:\temp\MyData.db";
        
        public DataTable GetData(string query)
        {
            DataTable tbl = new DataTable();
            using (var con = new SQLiteConnection(connectionString))
            {
                using(var cmd = new SQLiteCommand(query, con))
                {
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(tbl);
                    }
                }
            }
            return tbl;
        }

        public int TranactionData(string query)
        {
            using (var con = new SQLiteConnection(connectionString))
            {
                using (var cmd = new SQLiteCommand(query, con))
                {
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
