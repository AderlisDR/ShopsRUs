using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Boundaries.Persistence.Builders
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ItemEntityBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityBuilder"></param>
        public ItemEntityBuilder(EntityTypeBuilder<Item> entityBuilder)
        {
            // Entity seeds
            var itemSeeds = new List<Item>
            {
                new Item { Id = 1, Name = "Manzana", TypeId = 1, UnitPrice = 24.99M, CreatedOnUtc = DateTime.UtcNow },
                new Item { Id = 2, Name = "Pantalon", TypeId = 3, UnitPrice = 299.99M, CreatedOnUtc = DateTime.UtcNow },
                new Item { Id = 3, Name = "Mistolin", TypeId = 2, UnitPrice = 84.99M, CreatedOnUtc = DateTime.UtcNow }
            };

            // Entity configuration
            entityBuilder.HasKey(prop => prop.Id);
            entityBuilder.Property(prop => prop.Name).IsRequired().HasMaxLength(30);
            entityBuilder.Property(prop => prop.TypeId).IsRequired();
            entityBuilder.Property(prop => prop.UnitPrice).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(prop => prop.CreatedOnUtc).IsRequired();
            entityBuilder.HasOne(prop => prop.Type).WithMany(prop => prop.Items).HasForeignKey(prop => prop.TypeId);
            entityBuilder.HasData(itemSeeds);
        }
    }
}
