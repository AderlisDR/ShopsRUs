using System;
using System.Collections.Generic;

namespace Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class User : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsEmployee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsAffiliated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? AffiliatedOnUtc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<Bill> Bills { get; set; }
    }
}
