namespace Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class BillItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int BillId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal SubTotalAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Bill Bill { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Item Item { get; set; }
    }
}
