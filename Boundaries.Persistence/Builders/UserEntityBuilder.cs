using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Boundaries.Persistence.Builders
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class UserEntityBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityBuilder"></param>
        public UserEntityBuilder(EntityTypeBuilder<User> entityBuilder)
        {
            // Entity seeds
            var userSeeds = new List<User>
            {
                new User { Id = 1, Name = "Juan Pérez", IsAffiliated = true, IsEmployee = false, AffiliatedOnUtc = DateTime.UtcNow, CreatedOnUtc = DateTime.UtcNow },
                new User { Id = 2, Name = "María Magdalena", IsAffiliated = true, IsEmployee = true, AffiliatedOnUtc = DateTime.UtcNow, CreatedOnUtc = DateTime.UtcNow },
                new User { Id = 3, Name = "Pedro Almonte", IsAffiliated = false, IsEmployee = false, AffiliatedOnUtc = null, CreatedOnUtc = DateTime.UtcNow }
            };

            // Entity configuration
            entityBuilder.HasKey(prop => prop.Id);
            entityBuilder.Property(prop => prop.Name).IsRequired().HasMaxLength(50);
            entityBuilder.Property(prop => prop.IsEmployee).IsRequired();
            entityBuilder.Property(prop => prop.IsAffiliated).IsRequired();
            entityBuilder.Property(prop => prop.AffiliatedOnUtc).IsRequired(false);
            entityBuilder.Property(prop => prop.CreatedOnUtc).IsRequired();
            entityBuilder.HasData(userSeeds);
        }
    }
}
