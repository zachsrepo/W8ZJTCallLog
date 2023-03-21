using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallLogTesting.Models;

namespace CallLogTesting
{
    public class HamsDbContext : DbContext
    {
        //Tables accessible
        public DbSet<Ham> Hams { get; set; }

        public HamsDbContext() { }
        public HamsDbContext(DbContextOptions<HamsDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connStr = "server=localhost\\sqlexpress;" +
                "database=HamsLogDB;" +
                "trusted_connection=true;" +
                "trustServerCertificate=true;";
            optionsBuilder.UseSqlServer(connStr);
        }
    }
}
