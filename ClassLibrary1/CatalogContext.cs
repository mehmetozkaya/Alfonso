using Microsoft.EntityFrameworkCore;
using System;

namespace ClassLibrary1
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {

        }

        protected CatalogContext()
        {

        }

        public DbSet<Basket> Baskets { get; set; }

    }
}
