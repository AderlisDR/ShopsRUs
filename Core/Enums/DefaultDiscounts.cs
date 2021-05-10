namespace Core.Enums
{
    /// <summary>
    /// Represents default discounts.
    /// </summary>
    public enum DefaultDiscounts
    {
        /// <summary>
        /// Discount id for affiliated users.
        /// </summary>
        Affiliated = 1,

        /// <summary>
        /// Discount id for employed users.
        /// </summary>
        Employees = 2,

        /// <summary>
        /// Discount id for clients with more than two years being clients.
        /// </summary>
        TwoYearsClient = 3,

        /// <summary>
        /// Discount id for bills with total amount over 100 dollars.
        /// </summary>
        OverHundredDolars = 4
    }
}
