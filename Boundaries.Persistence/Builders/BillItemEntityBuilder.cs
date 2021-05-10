using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Builders
{
    /// <summary>
    /// Represents an <see cref="EntityTypeBuilder"/> for <see cref="BillItem"/> entity.
    /// </summary>
    public sealed class BillItemEntityBuilder
    {
        /// <summary>
        /// Initializes a new instance of <see cref="UserEntityBuilder"/>.
        /// </summary>
        /// <param name="entityBuilder">An instance of <see cref="EntityTypeBuilder{T}"/> where T is <see cref="BillItem"/>.</param>
        public BillItemEntityBuilder(EntityTypeBuilder<BillItem> entityBuilder)
        {
            // Entity configuration
            entityBuilder.HasKey(prop => prop.Id);
            entityBuilder.Property(prop => prop.Quantity).IsRequired();
            entityBuilder.Property(prop => prop.UnitPrice).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(prop => prop.SubTotalAmount).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(prop => prop.SubTotalDiscount).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(prop => prop.CreatedOnUtc).IsRequired();
            entityBuilder.HasOne(prop => prop.Bill).WithMany(prop => prop.Items).HasForeignKey(prop => prop.BillId);
            entityBuilder.HasOne(prop => prop.Item).WithMany(prop => prop.Bills).HasForeignKey(prop => prop.ItemId);
        }
    }
}
