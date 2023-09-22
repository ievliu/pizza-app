using PizzaApp.Contracts;

namespace PizzaApp.Data.Models;

public class Pizza
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public PizzaDto ToDto() => new()
    {
        Id = Id,
        Name = Name
    };
}