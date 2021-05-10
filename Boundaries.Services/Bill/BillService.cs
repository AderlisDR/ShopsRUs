using Boundaries.Persistence;
using Core.Entities;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boundaries.Services.Bill
{
    /// <summary>
    /// Represents an implementation for <see cref="IBillService"/>.
    /// </summary>
    public sealed class BillService : IBillService
    {
        private readonly IRepository<Core.Entities.Bill> _billRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Item> _itemRepository;
        private readonly IRepository<Core.Entities.Discount> _discountRepository;
        private readonly IRepository<ItemType> _itemTypeRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="BillService"/>.
        /// </summary>
        /// <param name="billRepository"></param>
        /// <param name="userRepository"></param>
        /// <param name="itemRepository"></param>
        /// <param name="discountRepository"></param>
        /// <param name="itemTypeRepository"></param>
        public BillService(
            IRepository<Core.Entities.Bill> billRepository,
            IRepository<User> userRepository,
            IRepository<Item> itemRepository,
            IRepository<Core.Entities.Discount> discountRepository,
            IRepository<ItemType> itemTypeRepository)
        {
            _billRepository = billRepository;
            _userRepository = userRepository;
            _itemRepository = itemRepository;
            _discountRepository = discountRepository;
            _itemTypeRepository = itemTypeRepository;
        }

        private async Task<Core.Entities.Discount> GetPercentageDiscountToApplyOnBillByUser(User billOwner)
        {
            int twoYearsCount = 2;
            if (billOwner.IsAffiliated && !billOwner.IsEmployee) return await _discountRepository.GetByIdAsync((int)DefaultDiscounts.Affiliated);
            else if (billOwner.IsEmployee) return await _discountRepository.GetByIdAsync((int)DefaultDiscounts.Employees);
            else if (DateTime.UtcNow.Year - billOwner.CreatedOnUtc.Year >= twoYearsCount) return await _discountRepository.GetByIdAsync((int)DefaultDiscounts.TwoYearsClient);
            else return null;
        }

        private decimal GetBillItemSubTotalDiscount(decimal billItemSubtotalAmount, Core.Entities.Discount discountToApply)
        {
            return billItemSubtotalAmount * discountToApply.DiscountValue / 100.00M;
        }

        private IList<BillDiscount> GetBillDiscounts(Core.Entities.Bill bill, IList<Core.Entities.Discount> discounts)
        {
            var billDiscounts = new List<BillDiscount>();

            foreach (Core.Entities.Discount discount in discounts)
            {
                billDiscounts.Add(new BillDiscount { BillId = bill.Id, DiscountId = discount.Id, CreatedOnUtc = DateTime.UtcNow });
            }

            return billDiscounts;
        }

        ///<inheritdoc/>
        public async Task<decimal> CreateBill(Core.Entities.Bill bill)
        {
            if (bill.UserId == 0) throw new Exception("");
            if (bill.Items.Count == 0) throw new Exception("");
            User billOwner = await _userRepository.GetByIdAsync(bill.UserId);
            bill.CreatedOnUtc = DateTime.UtcNow;
            decimal orderTotalDiscount = 0.00M;
            var billDiscounts = new List<Core.Entities.Discount> { await GetPercentageDiscountToApplyOnBillByUser(billOwner) };

            foreach (BillItem billItem in bill.Items)
            {
                Item item = await _itemRepository.GetByIdAsync(billItem.ItemId);
                if (item is null) throw new Exception("");
                ItemType itemType = await _itemTypeRepository.GetByIdAsync(item.TypeId);
                billItem.CreatedOnUtc = DateTime.UtcNow;
                billItem.UnitPrice = item.UnitPrice;
                billItem.SubTotalAmount = billItem.UnitPrice * billItem.Quantity;
                billItem.SubTotalDiscount = itemType.Name == "Comestible" || billDiscounts.First() is null ?
                    0.00M : GetBillItemSubTotalDiscount(billItem.SubTotalAmount, billDiscounts.First());

                bill.TotalGrossAmount += billItem.SubTotalAmount;
                orderTotalDiscount += billItem.SubTotalDiscount;
            }

            int dollarsToApplyForAmountDiscount = 100;

            if (bill.TotalGrossAmount >= dollarsToApplyForAmountDiscount)
            {
                billDiscounts.Add(await _discountRepository.GetByIdAsync((int)DefaultDiscounts.OverHundredDolars));
                bill.DiscountAmount = orderTotalDiscount + ((int)bill.TotalGrossAmount / dollarsToApplyForAmountDiscount * billDiscounts.Last().DiscountValue);
            }
            else
            {
                bill.DiscountAmount = orderTotalDiscount;
            }

            bill.TotalNetAmount = bill.TotalGrossAmount - bill.DiscountAmount;
            bill.Discounts = GetBillDiscounts(bill, billDiscounts);

            await _billRepository.InsertAsync(bill);

            return bill.TotalNetAmount;
        }
    }
}
