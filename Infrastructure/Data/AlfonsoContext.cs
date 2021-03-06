﻿using ApplicationCore.Entities;
using ApplicationCore.Entities.CompareAggregate;
using ApplicationCore.Entities.FeatureAggregate;
using ApplicationCore.Entities.WishlistAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

        public DbSet<Compare> Compares { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Wishlist>(ConfigureWishlist);
            builder.Entity<Feature>(ConfigureFeature);
            builder.Entity<Compare>(ConfigureCompare);
            builder.Entity<CatalogBrand>(ConfigureCatalogBrand);
            builder.Entity<CatalogType>(ConfigureCatalogType);
            builder.Entity<CatalogItem>(ConfigureCatalogItem);            
        }

        private void ConfigureWishlist(EntityTypeBuilder<Wishlist> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Wishlist.Items));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
        private void ConfigureFeature(EntityTypeBuilder<Feature> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Feature.Items));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
        private void ConfigureCompare(EntityTypeBuilder<Compare> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Compare.Items));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureCatalogItem(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("Catalog");

            builder.Property(ci => ci.Id)
                .ForSqlServerUseSequenceHiLo("catalog_hilo")
                .IsRequired();

            builder.Property(ci => ci.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(ci => ci.Price)
                .IsRequired(true);

            builder.Property(ci => ci.PictureUri)
                .IsRequired(false);

            builder.HasOne(ci => ci.CatalogBrand)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogBrandId);

            builder.HasOne(ci => ci.CatalogType)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogTypeId);
            
        }

        private void ConfigureCatalogBrand(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.ToTable("CatalogBrand");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("catalog_brand_hilo")
               .IsRequired();

            builder.Property(cb => cb.Brand)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureCatalogType(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogType");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("catalog_type_hilo")
               .IsRequired();

            builder.Property(cb => cb.Type)
                .IsRequired()
                .HasMaxLength(100);
        }

    }
}
