using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceitasAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixderelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaIngredientes_Ingrediente_IngredienteId",
                table: "ReceitaIngredientes");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaIngredientes_Ingrediente_IngredienteId",
                table: "ReceitaIngredientes",
                column: "IngredienteId",
                principalTable: "Ingrediente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaIngredientes_Ingrediente_IngredienteId",
                table: "ReceitaIngredientes");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaIngredientes_Ingrediente_IngredienteId",
                table: "ReceitaIngredientes",
                column: "IngredienteId",
                principalTable: "Ingrediente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
