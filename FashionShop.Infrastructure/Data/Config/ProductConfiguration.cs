﻿using FashionShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionShop.Infrastructure.Data.Config;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(255);
    }
}
