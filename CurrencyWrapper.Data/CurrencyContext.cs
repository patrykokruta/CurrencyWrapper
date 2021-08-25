using CurrencyWrapper.Data.Configurations;
using CurrencyWrapper.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWrapper.Data
{
    public class CurrencyContext : DbContext
    {
        public CurrencyContext(DbContextOptions<CurrencyContext> options) : base(options)
        {

        }
        public DbSet<CurrencyExchange> CurrencyExchanges { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyExchangeConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
        }
    }
}
