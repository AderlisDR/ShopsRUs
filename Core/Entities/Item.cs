using System.Collections.Generic;

namespace Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Item : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ItemType Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<BillItem> Bills { get; set; }
    }
}
