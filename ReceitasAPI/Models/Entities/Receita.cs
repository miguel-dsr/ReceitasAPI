namespace ReceitasAPI.Models.Entities
{
    public class Receita
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string ModoPreparo { get; set; }
        public List<ReceitaIngrediente> Ingredientes { get; set; }
    }
}
