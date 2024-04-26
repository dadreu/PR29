using Microsoft.EntityFrameworkCore;
using PR29.Classes.Common;
using PR29.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PR29.Classes
{
    public class ClubContext : DbContext
    {
        public DbSet<Clubs> Clubs { get; set; }
        public ClubContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);
        }
    }
}
