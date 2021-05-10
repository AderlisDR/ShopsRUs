namespace Core.Entities
{
    /// <summary>
    /// Represents the relation between a bill and a discount.
    /// </summary>
    public partial class BillDiscount : BaseEntity
    {
        /// <summary>
        /// Indicates the id of the bill.
        /// </summary>
        public int BillId { get; set; }

        /// <summary>
        /// Indicates the id of the discount.
        /// </summary>
        public int DiscountId { get; set; }

        ///<inheritdoc/>
        public virtual Bill Bill { get; set; }

        ///<inheritdoc/>
        public virtual Discount Discount { get; set; }
    }
}
