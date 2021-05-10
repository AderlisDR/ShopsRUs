using Core.Entities;
using Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Boundaries.Persistence.Builders
{
    /// <summary>
    /// Represents an <see cref="EntityTypeBuilder"/> for <see cref="Discount"/> entity.
    /// </summary>
    public sealed class DiscountEntityBuilder
    {
        /// <summary>
        /// Initializes a new instance of <see cref="UserEntityBuilder"/>.
        /// </summary>
        /// <param name="entityBuilder">An instance of <see cref="EntityTypeBuilder{T}"/> where T is <see cref="Discount"/>.</param>
        public DiscountEntityBuilder(EntityTypeBuilder<Discount> entityBuilder)
        {
            // Entity seeds
            var discountSeeds = new List<Discount>
            {
                new Discount { Id = 1, Name = "10%", Description = "10% de descuento para clientes afiliados", DiscountType = DiscountType.Percentage, DiscountValue = 10.00M, CreatedOnUtc = DateTime.Now },
                new Discount { Id = 2, Name = "30%", Description = "30% de descuento para empleados", DiscountType = DiscountType.Percentage, DiscountValue = 30.00M, CreatedOnUtc = DateTime.Now },
                new Discount { Id = 3, Name = "5%", Description = "5% de descuento para clientes con más de 2 años en la tienda", DiscountType = DiscountType.Percentage, DiscountValue = 5.00M, CreatedOnUtc = DateTime.Now },
                new Discount { Id = 4, Name = "$5", Description = "$5 dólares por cada $100 dólares en compras", DiscountType = DiscountType.Amount, DiscountValue = 5.00M, CreatedOnUtc = DateTime.Now }
            };

            // Entity configuration
            entityBuilder.HasKey(prop => prop.Id);
            entityBuilder.Property(prop => prop.Name).IsRequired().HasMaxLength(50);
            entityBuilder.Property(prop => prop.Description).IsRequired().HasMaxLength(200);
            entityBuilder.Property(prop => prop.DiscountTypeId).IsRequired();
            entityBuilder.Property(prop => prop.DiscountValue).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(prop => prop.CreatedOnUtc).IsRequired();
            entityBuilder.HasData(discountSeeds);
        }
    }
}
