using Microsoft.EntityFrameworkCore;
using ReceitasAPI.Models.Entities;

namespace ReceitasAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Ingrediente> Ingrediente { get; set; }
        public DbSet<Receita> Receita { get; set; }
        public DbSet<ReceitaIngrediente> ReceitaIngredientes { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceitaIngrediente>(entity =>
            {
                entity.HasKey(ri => new { ri.ReceitaId, ri.IngredienteId });

                entity.HasOne(ri => ri.Receita)
                      .WithMany(r => r.Ingredientes)
                      .HasForeignKey(ri => ri.ReceitaId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ri => ri.Ingrediente)
                      .WithMany()
                      .HasForeignKey(ri => ri.IngredienteId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
