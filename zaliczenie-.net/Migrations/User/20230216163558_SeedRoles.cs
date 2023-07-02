using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace zaliczenie_.net.Migrations.User
{
    public partial class SeedRoles : Migration
    {
        private string LibrarianRoleId = Guid.NewGuid().ToString();
        private string ReaderRoleId = Guid.NewGuid().ToString();

        private string LibrarianId = Guid.NewGuid().ToString();
        private string ReaderId = Guid.NewGuid().ToString();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);
            SeedUserRolesSQL(migrationBuilder);

        }
        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
            VALUES ('{LibrarianRoleId}', 'Librarian','LIBRARIAN', null)");
            migrationBuilder.Sql($@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
            VALUES ('{ReaderRoleId}', 'Reader','READER', null)");
        }
       
        private void SeedUserRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
            VALUES ('6bdf7867-7274-4ff2-b90f-07fe7eb03475', '{LibrarianRoleId}' )");
            migrationBuilder.Sql($@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
            VALUES ('9b223f2b-4b35-4f23-99ce-fd610de169e2', '{ReaderRoleId}' )");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
