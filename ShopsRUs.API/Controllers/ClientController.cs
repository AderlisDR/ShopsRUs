using AutoMapper;
using Boundaries.Services.Client;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopsRUs.API.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public sealed class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(
            IClientService clientService,
            IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IList<User> clients = await _clientService.GetAllAsync();
                return Ok(clients);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClientRequestModel request)
        {
            try
            {
                var newUser = _mapper.Map<User>(request);
                await _clientService.CreateAsync(newUser);
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                User client = await _clientService.GetByIdAsync(id);
                return Ok(client);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpGet("by-name")]
        public IActionResult GetByNAme([FromQuery] string name)
        {
            try
            {
                User client = _clientService.GetByName(name);
                return Ok(client);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }
    }
}
