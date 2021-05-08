using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Builders
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class BillDiscountEntityBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityBuilder"></param>
        public BillDiscountEntityBuilder(EntityTypeBuilder<BillDiscount> entityBuilder)
        {
            // Entity configuration
            entityBuilder.HasKey(prop => new { prop.BillId, prop.DiscountId });
            entityBuilder.HasOne(prop => prop.Bill).WithMany(prop => prop.Discounts).HasForeignKey(prop => prop.DiscountId);
            entityBuilder.HasOne(prop => prop.Discount).WithMany(prop => prop.Bills).HasForeignKey(prop => prop.BillId);
        }
    }
}
