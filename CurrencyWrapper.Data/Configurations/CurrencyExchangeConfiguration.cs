using CurrencyWrapper.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWrapper.Data.Configurations
{
    class CurrencyExchangeConfiguration : IEntityTypeConfiguration<CurrencyExchange>
    {
        public void Configure(EntityTypeBuilder<CurrencyExchange> builder)
        {
            builder.ToTable("CurrencyExchanges");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Date)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(x => x.Rate)
                .HasColumnType("decimal(20,10)");
        }
    }
}
