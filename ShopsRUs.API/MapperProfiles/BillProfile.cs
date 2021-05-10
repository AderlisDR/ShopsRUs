using AutoMapper;
using Core.Entities;
using ShopsRUs.API.Models;

namespace ShopsRUs.API.MapperProfiles
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class BillProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public BillProfile()
        {
            CreateMap<CreateBillRequestModel, Bill>();
            CreateMap<BillItemModel, BillItem>();
        }
    }
}
