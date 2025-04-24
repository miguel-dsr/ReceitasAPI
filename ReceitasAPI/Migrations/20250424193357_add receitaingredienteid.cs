using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceitasAPI.Migrations
{
    /// <inheritdoc />
    public partial class addreceitaingredienteid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ReceitaIngredientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReceitaIngredientes");
        }
    }
}
