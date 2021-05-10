using AutoMapper;
using Core.Entities;
using ShopsRUs.API.Models;

namespace ShopsRUs.API.MapperProfiles
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ClientProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public ClientProfile()
        {
            CreateMap<CreateClientRequestModel, User>();
        }
    }
}
