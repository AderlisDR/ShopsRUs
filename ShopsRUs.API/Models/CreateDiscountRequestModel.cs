namespace ShopsRUs.API.Models
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CreateDiscountRequestModel
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
    }
}
