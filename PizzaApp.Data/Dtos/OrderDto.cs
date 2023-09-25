using PizzaApp.Data.Models;

namespace PizzaApp.Data.Dtos;

public class OrderDto
{
    public int Id { get; set; }
    public required PizzaSize PizzaSize { get; set; }
    public required PizzaToppingType[] PizzaToppings { get; set; }
    public decimal Total { get; set; }
}