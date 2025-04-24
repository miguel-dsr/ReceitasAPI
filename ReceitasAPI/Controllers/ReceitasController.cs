using Microsoft.AspNetCore.Mvc;
using ReceitasAPI.Data;
using ReceitasAPI.Models.Dtos;
using ReceitasAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ReceitasAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReceitasController : ControllerBase
{
    private readonly AppDbContext dbContext;

    public ReceitasController(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult GetAllReceitas()
    {
        var todasReceitas = dbContext.Receita
            .Include(r => r.Ingredientes)
            .ThenInclude(ri => ri.Ingrediente)
            .ToList();

        return Ok(todasReceitas);
    }

    [HttpGet("{id}")]
    public IActionResult GetReceita(int id)
    {
        var receita = dbContext.Receita
            .Include(r => r.Ingredientes)
            .ThenInclude(ri => ri.Ingrediente)
            .FirstOrDefault(r => r.Id == id);

        if (receita == null)
        {
            return NotFound();
        }
        return Ok(receita);
    }

    [HttpPost]
    public IActionResult AddReceita(CreateReceitaDto createReceitaDto)
    {
        foreach (var ingredienteDto in createReceitaDto.Ingredientes)
        {
            if (!dbContext.Ingrediente.Any(i => i.Id == ingredienteDto.IngredienteId))
            {
                return BadRequest($"Ingrediente com ID {ingredienteDto.IngredienteId} não encontrado");
            }
        }

        var receitaEntity = new Receita
        {
            Nome = createReceitaDto.Nome,
            ModoPreparo = createReceitaDto.ModoPreparo,
            Ingredientes = createReceitaDto.Ingredientes.Select(i => new ReceitaIngrediente
            {
                IngredienteId = i.IngredienteId,
                Quantidade = i.Quantidade
            }).ToList()
        };

        dbContext.Receita.Add(receitaEntity);
        dbContext.SaveChanges();

        return CreatedAtAction(nameof(GetReceita), new { id = receitaEntity.Id }, receitaEntity);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateReceita(int id, UpdateReceitaDto updateReceitaDto)
    {
        var receita = dbContext.Receita
            .Include(r => r.Ingredientes)
            .FirstOrDefault(r => r.Id == id);

        if (receita == null)
        {
            return NotFound();
        }

        receita.Nome = updateReceitaDto.Nome;
        receita.ModoPreparo = updateReceitaDto.ModoPreparo;

        dbContext.ReceitaIngredientes.RemoveRange(receita.Ingredientes);
        receita.Ingredientes = updateReceitaDto.Ingredientes.Select(i => new ReceitaIngrediente
        {
            IngredienteId = i.IngredienteId,
            Quantidade = i.Quantidade
        }).ToList();

        dbContext.SaveChanges();
        return Ok(receita);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteReceita(int id)
    {
        var receita = dbContext.Receita.Find(id);
        if (receita == null)
        {
            return NotFound();
        }

        dbContext.Receita.Remove(receita);
        dbContext.SaveChanges();

        return NoContent(); // ou Ok();
    }
}
