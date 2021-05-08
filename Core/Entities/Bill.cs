using System.Collections.Generic;

namespace Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Bill : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<BillItem> Items { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<BillDiscount> Discounts { get; set; }
    }
}
