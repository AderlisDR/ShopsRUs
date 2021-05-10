using System.Collections.Generic;

namespace ShopsRUs.API.Models
{
    /// <summary>
    /// Represents a request to create a bill.
    /// </summary>
    public sealed class CreateBillRequestModel
    {
        /// <summary>
        /// The user of the owner of the bill.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The items related to the bill.
        /// </summary>
        public IList<BillItemModel> Items { get; set; }
    }
}
