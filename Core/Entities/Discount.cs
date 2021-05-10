using Core.Enums;
using System.Collections.Generic;

namespace Core.Entities
{
    /// <summary>
    /// Represents a discount.
    /// </summary>
    public partial class Discount : BaseEntity
    {
        /// <summary>
        /// Indicates a name for the discount.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates the description of the descount.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Indicates the type of discount as an id.
        /// </summary>
        public int DiscountTypeId { get; set; }

        /// <summary>
        /// Indicates the value for the discount.
        /// </summary>
        public decimal DiscountValue { get; set; }

        /// <summary>
        /// Indicates the typeof discount.
        /// </summary>
        public DiscountType DiscountType
        {
            get => (DiscountType)DiscountTypeId;
            set => DiscountTypeId = (int)value;
        }

        /// <summary>
        /// Bills where the discount was applied.
        /// </summary>
        public virtual IList<BillDiscount> Bills { get; set; }
    }
}
