using System.Collections.Generic;

namespace Core.Entities
{
    /// <summary>
    /// Represents an item.
    /// </summary>
    public partial class Item : BaseEntity
    {
        /// <summary>
        /// Indicates the name of the item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates the id of the corresponding <see cref="ItemType"/>.
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Indicates the unit price for the item.
        /// </summary>
        public decimal UnitPrice { get; set; }
        
        ///<inheritdoc/>
        public virtual ItemType Type { get; set; }

        /// <summary>
        /// Bills related to the item.
        /// </summary>
        public virtual IList<BillItem> Bills { get; set; }
    }
}
