using Microsoft.AspNetCore.Mvc;
using PizzaApp.Data.Dtos;
using PizzaApp.Server.Services;

namespace PizzaApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<OrderDto[]>> GetAll()
    {
        var orders = await _orderService.GetAllAsync();

        return orders;
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrderDto?>> GetById(int id)
    {
        var order = await _orderService.GetByIdAsync(id);

        if (order is null)
        {
            return NotFound();
        }

        return order;
    }
    
    [HttpPost]
    public async Task<ActionResult<OrderDto?>> Create(OrderDto orderDto)
    {
        var order = await _orderService.CreateAsync(orderDto);

        return CreatedAtAction(nameof(GetById), new { id = order?.Id }, order);
    }
    
    [HttpPost("CalculateTotal")]
    public ActionResult<decimal> CalculateTotal(OrderDto orderDto)
    {
        var total = _orderService.CalculateTotal(orderDto);

        return total;
    }
}