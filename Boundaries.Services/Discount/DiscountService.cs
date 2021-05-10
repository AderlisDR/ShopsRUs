using Boundaries.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boundaries.Services.Discount
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class DiscountService : IDiscountService
    {
        private readonly IRepository<Core.Entities.Discount> _discountRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="discountRepository"></param>
        public DiscountService(IRepository<Core.Entities.Discount> discountRepository)
        {
            _discountRepository = discountRepository;
        }

        ///<inheritdoc/>
        public async Task CreateAsync(Core.Entities.Discount discount)
        {
            discount.CreatedOnUtc = DateTime.UtcNow;
            await _discountRepository.InsertAsync(discount);
        }

        ///<inheritdoc/>
        public Task<IList<Core.Entities.Discount>> GetAllAsync() => _discountRepository.GetAllAsync();

        ///<inheritdoc/>
        public async Task<decimal> GetDiscountPercentageByDiscountIdAsync(int id)
        {
            if (id == 0) throw new Exception("Invalid discount ID.");
            Core.Entities.Discount foundDiscount = await _discountRepository.GetByIdAsync(id);
            if (foundDiscount is null) throw new Exception("Discount does not exists.");
            return foundDiscount.DiscountValue;
        }
    }
}
