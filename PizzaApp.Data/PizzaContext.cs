using Microsoft.EntityFrameworkCore;
using PizzaApp.Data.Models;

namespace PizzaApp.Data;

public class PizzaContext : DbContext
{
    public required DbSet<Pizza> Pizzas { get; set; }
    
    public PizzaContext(DbContextOptions<PizzaContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pizza>().HasData(new Pizza
        {
            Id = Guid.NewGuid(),
            Name = "Margherita"
        });
        
        base.OnModelCreating(modelBuilder);
    }
}