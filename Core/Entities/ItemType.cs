using System.Collections.Generic;

namespace Core.Entities
{
    /// <summary>
    /// Represents an item type.
    /// </summary>
    public partial class ItemType : BaseEntity
    {
        /// <summary>
        /// Indicates a name for the item type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Items related to the type.
        /// </summary>
        public virtual IList<Item> Items { get; set; }
    }
}
