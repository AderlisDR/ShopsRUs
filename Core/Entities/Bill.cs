using System.Collections.Generic;

namespace Core.Entities
{
    /// <summary>
    /// Represents a bill.
    /// </summary>
    public partial class Bill : BaseEntity
    {
        /// <summary>
        /// The user of the owner of the bill.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Indicates the bill total amount without discounts.
        /// </summary>
        public decimal TotalGrossAmount { get; set; }

        /// <summary>
        /// Indicates the bill total discount amount.
        /// </summary>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// Indicates the bill total amount with discounts.
        /// </summary>
        public decimal TotalNetAmount { get; set; }

        ///<inheritdoc/>
        public virtual User User { get; set; }

        /// <summary>
        /// The items related to the bill.
        /// </summary>
        public virtual IList<BillItem> Items { get; set; }

        /// <summary>
        /// The discounts related to the bill.
        /// </summary>
        public virtual IList<BillDiscount> Discounts { get; set; }
    }
}
