using SqliteAdoDotNet.DatabaseHandler;
using SqliteAdoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteAdoDotNet.DAL
{
    public class PeopleDal
    {
        SqliteDatabaseHandler handler;
        public PeopleDal()
        {
            handler = new SqliteDatabaseHandler();
        }

        public int InsertData(string Name) => handler.TranactionData($"Insert into People(name) values('{Name}');");
        public int UpdateData(Int64 Id,string Name) => handler.TranactionData($"update People set name = '{Name}' where Id = {Id} ;");
        public int DeleteData(Int64 Id) => handler.TranactionData($"delete from People where Id = {Id} ;");

        public IEnumerable<People> Getdate()
        {
            DataTable tbl = handler.GetData("Select * from People;");
            return from x in tbl.AsEnumerable() select new People { Id = x.Field<Int64>("Id"), Name = x.Field<string>("Name") };
        }
    }
}
