using System;

namespace Core
{
    /// <summary>
    /// Represents common properties for entities.
    /// </summary>
    public partial class BaseEntity
    {
        /// <summary>
        /// Indicates the entity id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Indicates the entity creation date.
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
