using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Builders
{
    /// <summary>
    /// Represents an <see cref="EntityTypeBuilder"/> for <see cref="BillDiscount"/> entity.
    /// </summary>
    public sealed class BillDiscountEntityBuilder
    {
        /// <summary>
        /// Initializes a new instance of <see cref="UserEntityBuilder"/>.
        /// </summary>
        /// <param name="entityBuilder">An instance of <see cref="EntityTypeBuilder{T}"/> where T is <see cref="BillDiscount"/>.</param>
        public BillDiscountEntityBuilder(EntityTypeBuilder<BillDiscount> entityBuilder)
        {
            // Entity configuration
            entityBuilder.HasKey(prop => prop.Id);
            entityBuilder.Property(prop => prop.CreatedOnUtc).IsRequired();
            entityBuilder.HasOne(prop => prop.Bill).WithMany(prop => prop.Discounts).HasForeignKey(prop => prop.BillId);
            entityBuilder.HasOne(prop => prop.Discount).WithMany(prop => prop.Bills).HasForeignKey(prop => prop.DiscountId);
        }
    }
}
