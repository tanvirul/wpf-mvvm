using ITARoutePlanner.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITARoutePlanner.EF
{
    public class ITARoutePlannerDbContext : DbContext
    {
        public DbSet<Spacecraft> Spacecrafts { get; set; }
        public DbSet<Planet> Planetes { get; set; }
        public ITARoutePlannerDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
