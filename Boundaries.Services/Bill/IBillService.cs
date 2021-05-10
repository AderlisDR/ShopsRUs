using System.Threading.Tasks;

namespace Boundaries.Services.Bill
{
    /// <summary>
    /// Represents a contract for <see cref="Core.Entities.Bill"/> services.
    /// </summary>
    public interface IBillService
    {
        /// <summary>
        /// Inserts a new bill and retrieves a the total amount after applying discounts.
        /// </summary>
        /// <param name="bill">An instance of <see cref="Core.Entities.Bill"/>.</param>
        /// <returns>An instance of <see cref="Task{TResult}"/> where TResult is a <see cref="decimal"/> with the total amount of the bill.</returns>
        Task<decimal> CreateBill(Core.Entities.Bill bill);
    }
}
