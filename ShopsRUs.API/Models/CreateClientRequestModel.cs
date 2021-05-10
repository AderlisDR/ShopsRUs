namespace ShopsRUs.API.Models
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CreateClientRequestModel
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
    }
}
