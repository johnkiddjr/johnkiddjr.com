﻿using Infrastructure.Models;
using Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace Infrastructure.Contexts
{
    public class MainSiteContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public MainSiteContext()
        {
        }

        public MainSiteContext(DbContextOptions<MainSiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<PortfolioLink> PortfolioLinks { get; set; }
        public virtual DbSet<LinkGroup> LinkGroups { get; set; }
        public virtual DbSet<Bio> Bios { get; set; }
        public virtual DbSet<BioDetail> BioDetails { get; set; }
        public virtual DbSet<BioSection> BioSections { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Objective> Objectives { get; set; }
        public virtual DbSet<ObjectiveDetail> ObjectivesDetails { get; set; }
        public virtual DbSet<Overview> Overviews { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<ArticleTag> ArticleTagRelations { get; set; }
        public virtual DbSet<CardBackground> CardBackgrounds { get; set; }
        public virtual DbSet<PrivacyPolicy> PrivacyPolicies { get; set; }
        public virtual DbSet<HighScore> HighScores { get; set; }
        public virtual DbSet<ProjectImage> ProjectImages { get; set; }
        public virtual DbSet<ProjectLink> ProjectLinks { get; set; }
        public virtual DbSet<AdminSection> AdminSections { get; set; }
        public virtual DbSet<AdminSectionItem> AdminSectionsItems { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<ProjectPlatform> ProjectPlatforms { get; set; }

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

            modelBuilder.Entity<Article>()
                .HasIndex(a => a.Slug)
                .IsUnique(true);

            modelBuilder.Entity<Project>()
                .HasIndex(a => a.ProjectSlug)
                .IsUnique(true);

            //seed data here
            modelBuilder.SeedData();
        }
    }
}
