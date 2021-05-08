using Core.Entities;
using Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Boundaries.Persistence.Builders
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class DiscountEntityBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityBuilder"></param>
        public DiscountEntityBuilder(EntityTypeBuilder<Discount> entityBuilder)
        {
            // Entity seeds
            var discountSeeds = new List<Discount>
            {
                new Discount { Id = 1, Name = "10% Afiliados", Description = "10% de descuento para clientes afiliados", DiscountType = DiscountType.Percentage, DiscountValue = 10.00M, CreatedOnUtc = DateTime.Now },
                new Discount { Id = 2, Name = "30% Empleados", Description = "30% de descuento para empleados", DiscountType = DiscountType.Percentage, DiscountValue = 30.00M, CreatedOnUtc = DateTime.Now },
                new Discount { Id = 3, Name = "5% 2 años con nosotros", Description = "10% de descuento para clientes afiliados", DiscountType = DiscountType.Percentage, DiscountValue = 10.00M, CreatedOnUtc = DateTime.Now }
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
