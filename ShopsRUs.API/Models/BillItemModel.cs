namespace ShopsRUs.API.Models
{
    /// <summary>
    /// Represents a model for bill item requests.
    /// </summary>
    public sealed class BillItemModel
    {
        /// <summary>
        /// Indicates the id of the item.
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// Indicates the quantity of the item.
        /// </summary>
        public int Quantity { get; set; }
    }
}
