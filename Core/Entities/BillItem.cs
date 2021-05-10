namespace Core.Entities
{
    /// <summary>
    /// Represents the relation between a bill and an item.
    /// </summary>
    public partial class BillItem : BaseEntity
    {
        /// <summary>
        /// Indicates the id of the bill.
        /// </summary>
        public int BillId { get; set; }

        /// <summary>
        /// Indicates the id of the item.
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// Indicates the quantity of the item.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Indicates the unit price of the item.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Indicates the sub-total amount for the bill item.
        /// </summary>
        public decimal SubTotalAmount { get; set; }

        /// <summary>
        /// Indicates the sub-total discount amount for the bill item.
        /// </summary>
        public decimal SubTotalDiscount { get; set; }

        ///<inheritdoc/>
        public virtual Bill Bill { get; set; }

        ///<inheritdoc/>
        public virtual Item Item { get; set; }
    }
}
