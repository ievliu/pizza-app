using Microsoft.EntityFrameworkCore;
using PizzaApp.Contracts;
using PizzaApp.Data;
using PizzaApp.Data.Models;

namespace PizzaApp.Server.Services;

public interface IOrderService
{
    Task<OrderDto[]> GetAllAsync();
    Task<OrderDto?> GetByIdAsync(int id);
    Task<OrderDto?> CreateAsync(OrderDto orderDto);
}

public class OrderService : IOrderService
{
    private readonly PizzaContext _context;
    private readonly ILogger<OrderService> _logger;

    public OrderService(PizzaContext context, ILogger<OrderService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<OrderDto[]> GetAllAsync()
    {
        _logger.LogInformation("Getting all orders");

        var orders = await _context.Orders.AsNoTracking().ToArrayAsync();

        return orders.Select(o => o.ToDto()).ToArray();
    }

    public async Task<OrderDto?> GetByIdAsync(int id)
    {
        _logger.LogInformation("Getting order with id {id}", id);

        var order = await _context.Orders
            .AsNoTracking()
            .Include(o => o.PizzaToppings)
            .FirstOrDefaultAsync(o => o.Id == id);

        return order?.ToDto();
    }

    public async Task<OrderDto?> CreateAsync(OrderDto orderDto)
    {
        _logger.LogInformation("Creating order");

        var order = new Order
        {
            PizzaSize = orderDto.PizzaSize,
            PizzaToppings = orderDto.PizzaToppings.Select(p => new PizzaTopping
            {
                PizzaToppingType = p
            }).ToArray(),
            DateCreated = DateTime.UtcNow,
            Total = orderDto.Total
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return order.ToDto();
    }
}