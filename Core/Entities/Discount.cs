using Core.Enums;
using System.Collections.Generic;

namespace Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Discount : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DiscountTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal DiscountValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DiscountType DiscountType
        {
            get => (DiscountType)DiscountTypeId;
            set => DiscountTypeId = (int)value;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<BillDiscount> Bills { get; set; }
    }
}
