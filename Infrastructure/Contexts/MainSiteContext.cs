using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Contexts
{
    public class MainSiteContext : DbContext
    {
        public MainSiteContext()
        {
        }

        public MainSiteContext(DbContextOptions<MainSiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Project>? Projects { get; set; }
        public virtual DbSet<PortfolioLink>? PortfolioLinks { get; set; }
        public virtual DbSet<LinkGroup>? LinkGroups { get; set; }
        public virtual DbSet<Bio>? Bios { get; set; }
        public virtual DbSet<BioDetail>? BioDetails { get; set; }
        public virtual DbSet<BioSection>? BioSections { get; set; }
        public virtual DbSet<Contact>? Contacts { get; set; }
        public virtual DbSet<File>? Files { get; set; }
        public virtual DbSet<Objective>? Objectives { get; set; }
        public virtual DbSet<ObjectiveDetail>? ObjectivesDetails { get; set; }
        public virtual DbSet<Overview>? Overviews { get; set; }
        public virtual DbSet<Article>? Articles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new NotSupportedException("DbContext must be configured!");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data here
            modelBuilder.SeedData();
        }
    }
}
