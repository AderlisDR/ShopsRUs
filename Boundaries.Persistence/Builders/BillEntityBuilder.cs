using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Builders
{
    /// <summary>
    /// Represents an <see cref="EntityTypeBuilder"/> for <see cref="Bill"/> entity.
    /// </summary>
    public sealed class BillEntityBuilder
    {
        /// <summary>
        /// Initializes a new instance of <see cref="UserEntityBuilder"/>.
        /// </summary>
        /// <param name="entityBuilder">An instance of <see cref="EntityTypeBuilder{T}"/> where T is <see cref="Bill"/>.</param>
        public BillEntityBuilder(EntityTypeBuilder<Bill> entityBuilder)
        {
            // Entity configuration
            entityBuilder.HasKey(prop => prop.Id);
            entityBuilder.Property(prop => prop.UserId).IsRequired();
            entityBuilder.Property(prop => prop.TotalGrossAmount).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(prop => prop.DiscountAmount).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(prop => prop.TotalNetAmount).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(prop => prop.CreatedOnUtc).IsRequired();
            entityBuilder.HasOne(prop => prop.User).WithMany(prop => prop.Bills).HasForeignKey(prop => prop.UserId);
        }
    }
}
