using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Builders
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class BillEntityBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityBuilder"></param>
        public BillEntityBuilder(EntityTypeBuilder<Bill> entityBuilder)
        {
            // Entity configuration
            entityBuilder.HasKey(prop => prop.Id);
            entityBuilder.Property(prop => prop.UserId).IsRequired();
            entityBuilder.Property(prop => prop.TotalAmount).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(prop => prop.DiscountAmount).HasColumnType("decimal(10,2)").IsRequired();
            entityBuilder.Property(prop => prop.CreatedOnUtc).IsRequired();
            entityBuilder.HasOne(prop => prop.User).WithMany(prop => prop.Bills).HasForeignKey(prop => prop.UserId);
        }
    }
}
