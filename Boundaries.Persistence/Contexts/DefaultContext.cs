using Boundaries.Persistence.Builders;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Boundaries.Persistence.Contexts
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class DefaultContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserEntityBuilder(modelBuilder.Entity<User>());
            new ItemTypeEntityBuilder(modelBuilder.Entity<ItemType>());
            new ItemEntityBuilder(modelBuilder.Entity<Item>());
            new DiscountEntityBuilder(modelBuilder.Entity<Discount>());
            new BillEntityBuilder(modelBuilder.Entity<Bill>());
            new BillItemEntityBuilder(modelBuilder.Entity<BillItem>());
            new BillDiscountEntityBuilder(modelBuilder.Entity<BillDiscount>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
