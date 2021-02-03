using LiquidApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidApi.Context
{
    public class LiquidApiContext : DbContext
    {
        public LiquidApiContext(DbContextOptions<LiquidApiContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
