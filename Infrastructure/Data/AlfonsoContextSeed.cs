﻿using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AlfonsoContextSeed
    {
        public static async Task SeedAsync(AlfonsoContext alfonsoContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                alfonsoContext.Database.Migrate();

                if (!alfonsoContext.CatalogBrands.Any())
                {
                    alfonsoContext.CatalogBrands.AddRange(GetPreconfiguredCatalogBrands());
                    await alfonsoContext.SaveChangesAsync();
                }

                if (!alfonsoContext.CatalogTypes.Any())
                {
                    alfonsoContext.CatalogTypes.AddRange(GetPreconfiguredCatalogTypes());
                    await alfonsoContext.SaveChangesAsync();
                }

                if (!alfonsoContext.CatalogItems.Any())
                {
                    alfonsoContext.CatalogItems.AddRange(GetPreconfiguredItems());
                    await alfonsoContext.SaveChangesAsync();
                }

            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<AlfonsoContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(alfonsoContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new CatalogBrand() { Brand = "IPhone"},
                new CatalogBrand() { Brand = "Samsung"},
                new CatalogBrand() { Brand = "LG"},
                new CatalogBrand() { Brand = "Xaomi"},
                new CatalogBrand() { Brand = "Huawei"},
                new CatalogBrand() { Brand = "Other" }
            };
        }

        private static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType() { Type = "Smartphone"},
                new CatalogType() { Type = "Tablet"},
                new CatalogType() { Type = "TV" },
                new CatalogType() { Type = "Computer" },
                new CatalogType() { Type = "Laptop" },
                new CatalogType() { Type = "HomeAppliance" },
                new CatalogType() { Type = "Camera" }
            };
        }

        private static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            var catalogItems = new List<CatalogItem>();

            for (int i = 0; i < 8; i++)
            {
                catalogItems.Add(
                    new CatalogItem()
                    {
                        CatalogTypeId = 1,
                        CatalogBrandId = 1,
                        Name = "IPhone X",
                        Slug = "iphone-x",
                        Star = 4.4,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        Summary = "A seasonal delight we offer every autumn.  Pumpking bread with just a bit of spice, cream cheese frosting with just a hint of home.",
                        Price = 19.5M,
                        PictureUri = "product-52.png"
                    });
            }

            for (int i = 0; i < 8; i++)
            {
                catalogItems.Add(
                    new CatalogItem()
                    {
                        CatalogTypeId = 1,
                        CatalogBrandId = 1,
                        Name = "Huawei Nova i2",
                        Slug = "huawai-nova-i2",
                        Star = 4.2,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        Summary = "A seasonal delight we offer every autumn.  Pumpking bread with just a bit of spice, cream cheese frosting with just a hint of home.",
                        Price = 4.2M,
                        PictureUri = "product-53.png"
                    });
            }

            for (int i = 0; i < 8; i++)
            {
                catalogItems.Add(
                    new CatalogItem()
                    {
                        CatalogTypeId = 1,
                        CatalogBrandId = 1,
                        Name = "Samsung Galaxy S9",
                        Slug = "samsung-galaxy-s9",
                        Star = 4.6,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        Summary = "A seasonal delight we offer every autumn.  Pumpking bread with just a bit of spice, cream cheese frosting with just a hint of home.",
                        Price = 4.2M,
                        PictureUri = "product-17.png"
                    });
            }

            for (int i = 0; i < 8; i++)
            {
                catalogItems.Add(
                    new CatalogItem()
                    {
                        CatalogTypeId = 1,
                        CatalogBrandId = 1,
                        Name = "LG Stylus 4",
                        Slug = "lg-stylus-4",
                        Star = 4.1,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        Summary = "A seasonal delight we offer every autumn.  Pumpking bread with just a bit of spice, cream cheese frosting with just a hint of home.",
                        Price = 4.2M,
                        PictureUri = "product-54.png"
                    });
            }

            return catalogItems;
        }

    }
}
