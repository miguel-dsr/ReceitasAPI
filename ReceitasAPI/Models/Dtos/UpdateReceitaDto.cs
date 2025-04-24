using ReceitasAPI.Models.Entities;

namespace ReceitasAPI.Models.Dtos
{
    public class UpdateReceitaDto
    {
        public required string Nome { get; set; }
        public required string ModoPreparo { get; set; }
        public List<ReceitaIngredienteDto> Ingredientes { get; set; } = new();
    }
}
