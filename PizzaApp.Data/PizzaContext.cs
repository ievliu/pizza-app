using Microsoft.EntityFrameworkCore;
using PizzaApp.Data.Models;

namespace PizzaApp.Data;

public class PizzaContext : DbContext
{
    public required DbSet<Order> Orders { get; set; }
    public required DbSet<PizzaTopping> PizzaToppings { get; set; }

    public PizzaContext(DbContextOptions<PizzaContext> options)
        : base(options)
    {
    }
}