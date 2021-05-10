using Boundaries.Persistence.Builders;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Boundaries.Persistence.Contexts
{
    /// <summary>
    /// Represents a default db context.
    /// </summary>
    public sealed class DefaultContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of <see cref="DefaultContext"/>
        /// </summary>
        /// <param name="options">An instance of <see cref="DbContextOptions{T}"/> where T is <see cref="DefaultContext"/>.</param>
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options) { }

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
