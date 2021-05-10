using AutoMapper;
using Core.Entities;
using ShopsRUs.API.Models;

namespace ShopsRUs.API.MapperProfiles
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class DiscountProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public DiscountProfile()
        {
            CreateMap<CreateDiscountRequestModel, Discount>();
        }
    }
}
