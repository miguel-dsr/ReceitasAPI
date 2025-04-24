using ReceitasAPI.Models.Dtos;

public class CreateReceitaDto
{
    public required string Nome { get; set; }
    public required string ModoPreparo { get; set; }
    public List<ReceitaIngredienteDto> Ingredientes { get; set; } = new();
}