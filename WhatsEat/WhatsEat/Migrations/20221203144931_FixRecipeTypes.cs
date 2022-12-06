using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatsEat.Migrations
{
    /// <inheritdoc />
    public partial class FixRecipeTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "recipeId",
                table: "RecipeType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "recipeId",
                table: "RecipeType",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
