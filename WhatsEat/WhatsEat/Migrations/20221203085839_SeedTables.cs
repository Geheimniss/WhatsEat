using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatsEat.Migrations
{
    /// <inheritdoc />
    public partial class SeedTables : Migration
    { 
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRegionAndCountryTables(migrationBuilder);
        }

        private void SeedRegionAndCountryTables(MigrationBuilder migrationBuilder)
        {
            //Азия и ее страны
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Regions] ([Name]) VALUES ('Азия');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Countries] ([regionId], [Name]) 
            VALUES 
            ('1', 'Кыргызстан'),
            ('1', 'Узбекистан'),
            ('1', 'Узбекистан'),
            ('1', 'Япония'),
            ('1', 'Индия'),
            ('1', 'Китай'),
            ('1', 'Вьетнам'),
            ('1', 'Турция'),
            ('1', 'Корея')");

            //Европа
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Regions] ([Name]) VALUES ('Европа');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Countries] ([regionId], [Name]) 
            VALUES 
            ('2', 'Франция'),
            ('2', 'Германия'),
            ('2', 'Италия'),
            ('2', 'Испания'),
            ('2', 'Португалия'),
            ('2', 'Венгрия'),
            ('2', 'Россия'),
            ('2', 'Нидерланды'),
            ('2', 'Швейцария'),
            ('2', 'Украина'),
            ('2', 'Беларусь'),
            ('2', 'Грузия'),
            ('2', 'Греция'),
            ('2', 'Польша'),
            ('2', 'Молдавия'),
            ('2', 'Чехия'),
            ('2', 'Страны Скандинавии')");

            //Обе Америки
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Regions] ([Name]) VALUES ('Северная и Южная Америки');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Countries] ([regionId], [Name]) 
            VALUES 
            ('3', 'США'),
            ('3', 'Мексика'),
            ('3', 'Канада'),
            ('3', 'Бразилия'),
            ('3', 'Аргентина'),
            ('3', 'Чили')");
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
