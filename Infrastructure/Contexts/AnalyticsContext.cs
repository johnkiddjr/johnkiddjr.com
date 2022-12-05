using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Contexts
{
    public class AnalyticsContext : DbContext
    {
        public AnalyticsContext() { }

        public AnalyticsContext(DbContextOptions<AnalyticsContext> options) : base(options) { }

        public virtual DbSet<AnalyticsLogEntry> AnalyticsLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new NotSupportedException("DBContext must be configured!");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}