using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Builders
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class BillItemEntityBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityBuilder"></param>
        public BillItemEntityBuilder(EntityTypeBuilder<BillItem> entityBuilder)
        {
            // Entity configuration
            entityBuilder.HasKey(prop => new { prop.BillId, prop.ItemId });
            entityBuilder.Property(prop => prop.Quantity).IsRequired();
            entityBuilder.Property(prop => prop.UnitPrice).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(prop => prop.SubTotalAmount).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.HasOne(prop => prop.Bill).WithMany(prop => prop.Items).HasForeignKey(prop => prop.ItemId);
            entityBuilder.HasOne(prop => prop.Item).WithMany(prop => prop.Bills).HasForeignKey(prop => prop.BillId);
        }
    }
}
