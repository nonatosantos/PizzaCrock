using Microsoft.EntityFrameworkCore;
using PizzaCrock.Domain.Entities;
using PizzaCrock.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCrock.Infra
{
    public class PizzaCrockDbContext: DbContext
    {
        public PizzaCrockDbContext(DbContextOptions<PizzaCrockDbContext> options):base(options)
        {

        }

        public DbSet<Additional> Additionals { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Flavor> Flavors { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}
