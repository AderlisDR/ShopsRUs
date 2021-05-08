namespace Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class BillDiscount
    {
        /// <summary>
        /// 
        /// </summary>
        public int BillId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DiscountId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Bill Bill { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Discount Discount { get; set; }
    }
}
