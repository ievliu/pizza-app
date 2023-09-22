using Microsoft.AspNetCore.Mvc;
using PizzaApp.Contracts;
using PizzaApp.Data.Repositories;

namespace PizzaApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly ILogger<PizzaController> _logger;
    private readonly IPizzaRepository _pizzaRepository;

    public PizzaController(ILogger<PizzaController> logger, IPizzaRepository pizzaRepository)
    {
        _logger = logger;
        _pizzaRepository = pizzaRepository;
    }

    [HttpGet("/all")]
    public async Task<ActionResult<PizzaDto[]>> Get()
    {
        await _pizzaRepository.AddTestDataAsync();
        var pizzas = await _pizzaRepository.GetAllAsync();

        var dtos = pizzas.Select(p => p.ToDto()).ToArray();

        return dtos;
    }
}