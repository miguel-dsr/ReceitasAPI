using System.ComponentModel.DataAnnotations;

namespace ReceitasAPI.Models.Dtos
{
    public class ReceitaIngredienteDto
    {
        [Required]
        public int IngredienteId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero")]
        public decimal Quantidade { get; set; }
    }
}
