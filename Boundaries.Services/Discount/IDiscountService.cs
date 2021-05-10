using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boundaries.Services.Discount
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDiscountService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IList<Core.Entities.Discount>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<decimal> GetDiscountPercentageByDiscountIdAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="discount"></param>
        /// <returns></returns>
        Task CreateAsync(Core.Entities.Discount discount);
    }
}
