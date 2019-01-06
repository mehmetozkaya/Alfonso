using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class AlfonsoContext : DbContext
    {
        public AlfonsoContext(DbContextOptions<AlfonsoContext> options) : base(options)
        {

        }

        public AlfonsoContext()
        {

        }

        public DbSet<Basket> Baskets { get; set; }
    }
}
