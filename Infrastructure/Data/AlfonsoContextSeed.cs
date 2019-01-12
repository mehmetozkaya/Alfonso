using ApplicationCore.Entities;
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
                    alfonsoContext.CatalogBrands.AddRange(GetPreconfiguredCatalogTypes());
                    await alfonsoContext.SaveChangesAsync();
                }


            }
            catch (Exception)
            {
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
                new CatalogBrand() { Brand = "Other" }
            };
        }

        private static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType() { Type = "Mug"},
                new CatalogType() { Type = "T-Shirt" },
                new CatalogType() { Type = "Sheet" },
                new CatalogType() { Type = "USB Memory Stick" }
            };
        }

    }
}
