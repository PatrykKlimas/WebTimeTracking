using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTimeTracking.Models;

namespace WebTimeTracking.Data
{

    public class TimeTrackingContext : DbContext
    {
        private readonly IConfiguration _config;
        public TimeTrackingContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Boss> Bosses { get; set; }
        public DbSet<TimeTracking> TimeTrackings { get; set; }
        public DbSet<TimeRecord> TimeRecords { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:TimeTrackingContextDb"]);
        }
    
}
}
