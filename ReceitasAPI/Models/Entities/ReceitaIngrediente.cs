﻿namespace ReceitasAPI.Models.Entities
{
    public class ReceitaIngrediente
    {
        public int Id { get; set; } 
        public int IngredienteId { get; set; }
        public Ingrediente Ingrediente { get; set; }

        public int ReceitaId { get; set; }
        public Receita Receita { get; set; }

        public decimal Quantidade { get; set; }
    }
}
