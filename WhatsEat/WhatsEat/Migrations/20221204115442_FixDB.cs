using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatsEat.Migrations
{
    /// <inheritdoc />
    public partial class FixDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_RecipeDetails_RecipeDetailsId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Products_ProductId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeType_RecipeTypeId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_ProductId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeTypeId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Products_RecipeDetailsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeTypeId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeDetailsId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductRecipeDetails",
                columns: table => new
                {
                    productsId = table.Column<int>(type: "int", nullable: false),
                    recipeDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRecipeDetails", x => new { x.productsId, x.recipeDetailsId });
                    table.ForeignKey(
                        name: "FK_ProductRecipeDetails_Products_productsId",
                        column: x => x.productsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductRecipeDetails_RecipeDetails_recipeDetailsId",
                        column: x => x.recipeDetailsId,
                        principalTable: "RecipeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRecipeDetails_recipeDetailsId",
                table: "ProductRecipeDetails",
                column: "recipeDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductRecipeDetails");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeTypeId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeDetailsId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ProductId",
                table: "Recipes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeTypeId",
                table: "Recipes",
                column: "RecipeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RecipeDetailsId",
                table: "Products",
                column: "RecipeDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_RecipeDetails_RecipeDetailsId",
                table: "Products",
                column: "RecipeDetailsId",
                principalTable: "RecipeDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Products_ProductId",
                table: "Recipes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeType_RecipeTypeId",
                table: "Recipes",
                column: "RecipeTypeId",
                principalTable: "RecipeType",
                principalColumn: "Id");
        }
    }
}
