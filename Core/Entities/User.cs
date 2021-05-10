using System;
using System.Collections.Generic;

namespace Core.Entities
{
    /// <summary>
    /// Represents an user.
    /// </summary>
    public partial class User : BaseEntity
    {
        /// <summary>
        /// Indicates the name of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates if is an employee.
        /// </summary>
        public bool IsEmployee { get; set; }

        /// <summary>
        /// Indicates if is affiliated.
        /// </summary>
        public bool IsAffiliated { get; set; }

        /// <summary>
        /// Indicates the date of affiliation.
        /// </summary>
        public DateTime? AffiliatedOnUtc { get; set; }

        /// <summary>
        /// Bills for the user.
        /// </summary>
        public virtual IList<Bill> Bills { get; set; }
    }
}
