using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatsEat.Migrations
{
    public partial class SeedRoles : Migration
    {
        private string ManagerRoleId = Guid.NewGuid().ToString();
        private string UserRoleId = Guid.NewGuid().ToString();
        private string AdminRoleId = Guid.NewGuid().ToString();

        private string User1Id = Guid.NewGuid().ToString();
        private string User2Id = Guid.NewGuid().ToString();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);

            SeedUser(migrationBuilder);

            SeedUserRoles(migrationBuilder);
        }

        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{AdminRoleId}', 'Администратор', 'АДМИНИСТРАТОР', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{ManagerRoleId}', 'Менеджер', 'МЕНЕДЖЕР', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{UserRoleId}', 'Пользователь', 'ПОЛЬЗОВАТЕЛЬ', null);");
        }

        private void SeedUser(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @$"INSERT [dbo].[AspNetUsers] 
                            ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], 
                            [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], 
                            [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
                   VALUES 
                            (N'{User1Id}', N'Admin', N'Admin', N'aganudaiche@gmail.com', N'AGANUDAICHE@GMAIL.COM', 
                            N'aganudaiche@gmail.com', N'AGANUDAICHE@GMAIL.COM', 0, 
                            N'AQAAAAEAACcQAAAAEH8DGtUZXNnuBNyTzOvw67/T1W037vfqmzZ6uHXdgFHMd+7OCQbK9vkw+mpMuqUqVg==', 
                            N'YUPAFWNGZI2UC5FOITC7PX5J7XZTAZAA', N'8e150555-a20d-4610-93ff-49c5af44f749', NULL, 0, 0, NULL, 1, 0)");

            migrationBuilder.Sql(
                @$"INSERT [dbo].[AspNetUsers] 
                            ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], 
                            [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], 
                            [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
                   VALUES 
                            (N'{User2Id}', N'Manager', N'Manager', N'manager@manager.manager', N'MANAGER@MANAGER.MANAGER', 
                            N'manager@manager.manager', N'MANAGER@MANAGER.MANAGER', 0, 
                            N'AQAAAAEAACcQAAAAEHUAybT6jy0om10cub0Ke7z07xldzSuWKKVjDNGftRjsKTrbM1caIvwak+7pK2Iv4g==', 
                            N'YUPAFWNGZI2UC5FOITC7PX5J7XZTAZAA', N'8e150555-a20d-4610-93ff-49c5af44f749', NULL, 0, 0, NULL, 1, 0)");
        }

        private void SeedUserRoles(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User1Id}', '{ManagerRoleId}');
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User1Id}', '{AdminRoleId}');");

            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User2Id}', '{UserRoleId}');
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User2Id}', '{ManagerRoleId}');");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
