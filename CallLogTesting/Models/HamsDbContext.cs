using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CallLogTesting.Models
{
    public class HamsDbContext : DbContext
    {
        //Tables accessible
        public DbSet<Ham> Hams { get; set; }
        public DbSet<UsersAndSettings> UsersAndSettings { get; set; }

        public HamsDbContext() { }
        public HamsDbContext(DbContextOptions<HamsDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connStr = "data source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DBs\\HamsLogDB.mdf;Integrated Security=True";
            optionsBuilder.UseSqlServer(connStr);
            
        }
    }
}
