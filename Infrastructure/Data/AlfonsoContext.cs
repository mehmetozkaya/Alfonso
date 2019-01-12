using ApplicationCore.Entities;
using ApplicationCore.Entities.CompareAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class AlfonsoContext : DbContext
    {
        public AlfonsoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<Compare> Compares { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Compare>(ConfigureCompare);
            builder.Entity<CatalogBrand>(ConfigureCatalogBrand);
            builder.Entity<CatalogType>(ConfigureCatalogType);
            builder.Entity<CatalogItem>(ConfigureCatalogItem);            
        }



    }
}
