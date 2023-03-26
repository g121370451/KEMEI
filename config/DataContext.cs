using IceCream.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.config
{
    public class DataContext : DbContext
    {
        public DataContext() : base(new SQLiteConnection()
        {
            ConnectionString = new SQLiteConnectionStringBuilder()
            {
                DataSource = "Stock.db",
                ForeignKeys = true
            }.ConnectionString
        }, true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<IceCreamStock> iceCreamStocks { get; set; }

        public DbSet<MakingInfo> makingInfos { get; set; }
    }
}
