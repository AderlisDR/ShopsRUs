using System.Collections.Generic;

namespace Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ItemType : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<Item> Items { get; set; }
    }
}
