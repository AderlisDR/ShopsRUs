using AutoMapper;
using Boundaries.Services.Bill;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.API.Models;
using System;
using System.Threading.Tasks;

namespace ShopsRUs.API.Controllers
{
    [Route("api/bills")]
    [ApiController]
    public sealed class BillController : ControllerBase
    {
        private readonly IBillService _billService;
        private readonly IMapper _mapper;

        public BillController(
            IBillService billService,
            IMapper mapper)
        {
            _billService = billService;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBillRequestModel request)
        {
            try
            {
                var newBill = _mapper.Map<Bill>(request);
                decimal totalNetAmount = await _billService.CreateBill(newBill);
                return Ok(new { BillNetTotalAmount = totalNetAmount });
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
