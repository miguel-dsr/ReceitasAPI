using Microsoft.AspNetCore.Mvc;
using ReceitasAPI.Data;
using ReceitasAPI.Models.Dtos;
using ReceitasAPI.Models.Entities;

namespace ReceitasAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientesController : ControllerBase
{
    private readonly AppDbContext dbContext;

    public IngredientesController(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult GetAllIngredientes()
    {
        var todosIngredientes = dbContext.Ingrediente.ToList();
        return Ok(todosIngredientes);
    }

    [HttpGet("{id}")]
    public IActionResult GetIngrediente(int id)
    {
        var ingrediente = dbContext.Ingrediente.Find(id);
        if (ingrediente == null)
        {
            return NotFound();
        }
        return Ok(ingrediente);
    }

    [HttpPost]
    public IActionResult AddIngrediente(CreateIngredienteDto createIngredienteDto)
    {
        var ingredienteEntity = new Ingrediente
        {
            Nome = createIngredienteDto.Nome,
            UnidadeMedida = createIngredienteDto.UnidadeMedida,
        };

        dbContext.Ingrediente.Add(ingredienteEntity);
        dbContext.SaveChanges();

        return CreatedAtAction(nameof(GetIngrediente), new { id = ingredienteEntity.Id }, ingredienteEntity);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateIngrediente(int id, UpdateIngredienteDto updateIngredienteDto)
    {
        var ingrediente = dbContext.Ingrediente.Find(id);
        if (ingrediente == null)
        {
            return NotFound();
        }

        ingrediente.Nome = updateIngredienteDto.Nome;
        ingrediente.UnidadeMedida = updateIngredienteDto.UnidadeMedida;
        dbContext.SaveChanges();

        return Ok(ingrediente);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteIngrediente(int id)
    {
        var ingrediente = dbContext.Ingrediente.Find(id);
        if (ingrediente == null)
        {
            return NotFound();
        }

        dbContext.Ingrediente.Remove(ingrediente);
        dbContext.SaveChanges();

        return NoContent(); // ou Ok()
    }
}
