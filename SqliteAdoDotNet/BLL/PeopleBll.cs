using SqliteAdoDotNet.DAL;
using SqliteAdoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteAdoDotNet.BLL
{
    public class PeopleBll
    {
        PeopleDal dll;
        public PeopleBll() => dll = new PeopleDal();
        public int Insert(string name) => dll.InsertData(name);
        public int Update(Int64 Id,string name) => dll.UpdateData(Id,name);
        public int Delete(Int64 Id) => dll.DeleteData(Id);
        public List<People> getData() => dll.Getdate().ToList();
    }
}
