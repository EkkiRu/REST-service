using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_service.Date
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public string connectionString = "Server = localhost; Database = Test; Trusted_Connection = True;";

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
