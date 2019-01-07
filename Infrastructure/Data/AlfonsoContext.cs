using ApplicationCore.Entities;
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
    }
}
