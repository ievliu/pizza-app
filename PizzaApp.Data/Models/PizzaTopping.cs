using PizzaApp.Contracts;

namespace PizzaApp.Data.Models;

public class PizzaTopping
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public required PizzaToppingType PizzaToppingType { get; set; }
}