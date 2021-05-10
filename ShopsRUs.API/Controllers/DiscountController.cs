using AutoMapper;
using Boundaries.Services.Discount;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopsRUs.API.Controllers
{
    [Route("api/discounts")]
    [ApiController]
    public sealed class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(
            IDiscountService discountService,
            IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IList<Discount> discounts = await _discountService.GetAllAsync();
                return Ok(discounts);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpGet("{id}/percentage")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                decimal percentage = await _discountService.GetDiscountPercentageByDiscountIdAsync(id);
                return Ok(new { DiscountPercentage = percentage });
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDiscountRequestModel request)
        {
            try
            {
                var newDiscount = _mapper.Map<Discount>(request);
                await _discountService.CreateAsync(newDiscount);
                return Ok();
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(new { Error = e.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }
    }
}
