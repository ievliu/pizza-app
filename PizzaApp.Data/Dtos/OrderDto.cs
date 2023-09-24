namespace PizzaApp.Contracts;

public class OrderDto
{
    public int Id { get; set; }
    public required PizzaSize PizzaSize { get; set; }
    public required PizzaToppingType[] PizzaToppings { get; set; }
    public required decimal Total { get; set; }
}