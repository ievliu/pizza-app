using PizzaApp.Data.Dtos;

namespace PizzaApp.Data.Models;

public class Order
{
    public int Id { get; set; }
    public required PizzaSize PizzaSize { get; set; }
    public IList<PizzaTopping>? PizzaToppings { get; set; }
    public required DateTime DateCreated { get; set; }
    public required decimal Total { get; set; }

    public OrderDto ToDto() => new()
    {
        Id = Id,
        PizzaSize = PizzaSize,
        PizzaToppings = PizzaToppings?.Select(p => p.PizzaToppingType).ToArray() ?? Array.Empty<PizzaToppingType>(),
        Total = Total
    };
}