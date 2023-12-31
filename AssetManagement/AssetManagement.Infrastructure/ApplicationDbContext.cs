﻿using AssetManagement.Domain;
using AssetManagement.Infrastructure;
using AssetManagement.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AssetManagement.Infrastructure
{
    /// <summary>
    /// Database context for current application
    /// </summary>
    public class ApplicationDbContext : DbContextBase
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<QRcode> QRcode { get; set; } // потом удалить

        public DbSet<Department> departments { get; set; }

        public DbSet<Operation> operations { get; set; }

        public DbSet<ProductMovement> productMovements { get; set; }

        public DbSet<Route> routes { get; set; }

        public DbSet<Stage> stages { get; set; }

        public DbSet<EventItem> EventItems { get; set; }

        public DbSet<ApplicationUserProfile> Profiles { get; set; }

        public DbSet<AppPermission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseOpenIddict<Guid>();
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // It should be removed when using real Database (not in memory mode)
            optionsBuilder.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            base.OnConfiguring(optionsBuilder);
        }
    }
}

/// <summary>
/// ATTENTION!
/// It should uncomment two line below when using real Database (not in memory mode). Don't forget update connection string.
/// </summary>
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=AssetAlmazDB2;Trusted_Connection=True;encrypt=false");
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}