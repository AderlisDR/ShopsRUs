using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Boundaries.Persistence.Builders
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ItemTypeEntityBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityBuilder"></param>
        public ItemTypeEntityBuilder(EntityTypeBuilder<ItemType> entityBuilder)
        {
            // Entity seeds
            var itemTypeSeeds = new List<ItemType>
            {
                new ItemType { Id = 1, Name = "Comestible", CreatedOnUtc = DateTime.UtcNow },
                new ItemType { Id = 2, Name = "Limpieza", CreatedOnUtc = DateTime.UtcNow },
                new ItemType { Id = 3, Name = "Ropa", CreatedOnUtc = DateTime.UtcNow }
            };

            // Entity configuration
            entityBuilder.HasKey(prop => prop.Id);
            entityBuilder.Property(prop => prop.Name).IsRequired().HasMaxLength(15);
            entityBuilder.Property(prop => prop.CreatedOnUtc).IsRequired();
            entityBuilder.HasData(itemTypeSeeds);
        }
    }
}
