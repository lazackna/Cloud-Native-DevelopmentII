using DataAccess.Configuration;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace DataAccess
{
    public abstract class DataContext : DbContext
    {
        public DbSet<Weather> WeatherData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new WeatherConfiguration());
        }

    }

}