using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatsEat.Migrations
{
    /// <inheritdoc />
    public partial class SeedRecipeTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRecipeTypesSQL(migrationBuilder);
        }

        private void SeedRecipeTypesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[RecipeType] ([Name])
            VALUES 
            ('Суп'),
            ('Второе'),
            ('Десерт'),
            ('Салат'),
            ('Выпечка'),
            ('Завтрак'),
            ('Соус'),
            ('Коктейль/напиток'),
            ('Закуска');");
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
