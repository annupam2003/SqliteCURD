using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteEF6
{
    public class DataContext : DbContext
    {
        static readonly string SQLiteConnectionString = @"Data Source=C:\Temp\MyData.db";
        //public DataContext() : base(new SQLiteConnection()
        //{
        //    ConnectionString = new SQLiteConnectionStringBuilder()
        //    {
        //        DataSource = "MyData.db",
        //        ForeignKeys = true
        //    }.ConnectionString
        //}, true)
        //{
        //}
        public DataContext() : base(new SQLiteConnection(SQLiteConnectionString), true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        //one dataset prop for each table:
        public DbSet<People> people { get; set; }
    }
}
