using ApiAndEntityFramework.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAndEntityFramework.Api.Persistence
{
    public class CarContext : DbContext
    {

        public CarContext( DbContextOptions<CarContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var carEntity = modelBuilder.Entity<Car>();

            carEntity.Property(p => p.Model).HasMaxLength(255);
            carEntity.Property(p => p.PriceAtPremiere).HasPrecision(9,2); 
        }

    }
}
