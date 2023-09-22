using Microsoft.EntityFrameworkCore;
using PizzaApp.Data.Models;

namespace PizzaApp.Data.Repositories;

public interface IPizzaRepository
{
    Task<Pizza[]> GetAllAsync();
    Task AddTestDataAsync();
}

public class PizzaRepository : IPizzaRepository
{
    private readonly PizzaContext _context;

    public PizzaRepository(PizzaContext context)
    {
        _context = context;
    }

    public Task<Pizza[]> GetAllAsync() => _context.Pizzas.AsNoTracking().ToArrayAsync();

    public async Task AddTestDataAsync()
    {
        _context.Pizzas.Add(new Pizza
        {
            Id = Guid.NewGuid(),
            Name = "Margherita"
        });

        await _context.SaveChangesAsync();
    }
}