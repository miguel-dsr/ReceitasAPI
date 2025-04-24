namespace ReceitasAPI.Models.Entities
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public required string Nome {  get; set; }
        public required string UnidadeMedida { get; set; }
    }
}
