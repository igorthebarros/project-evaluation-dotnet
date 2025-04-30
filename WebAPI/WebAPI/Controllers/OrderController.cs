using Application.Dtos;
using AutoMapper;
using Domain.Contracts.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;
        public OrderController(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDto dto, CancellationToken token)
        {
            var order = _mapper.Map<Order>(dto);
            var result = await _service.CreateAsync(order, token);

            if (result == null)
                return BadRequest($"Error trying to create the Order with id {dto.Id}.");

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromHeader] Guid id, CancellationToken token)
        {
            var result = await _service.GetByIdAsync(id, token);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await _service.GetAllAsync(token);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] OrderDto dto, CancellationToken token)
        {
            var order = _mapper.Map<Order>(dto);

            var orderUpdated = await _service.UpdateAsync(order, token);

            if (orderUpdated == null)
                return BadRequest($"Error trying to update the Order with id {dto.Id}.");

            var result = _mapper.Map<OrderDto>(orderUpdated);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromHeader] Guid id, CancellationToken token)
        { 
            var result = await _service.DeleteAsync(id, token);

            if (result == false)
                return BadRequest($"Error trying to delete the Order with id {id}.");

            return Ok(result);
        }
    }
}
