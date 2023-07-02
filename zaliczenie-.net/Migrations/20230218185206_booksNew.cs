using Microsoft.EntityFrameworkCore.Migrations;

namespace zaliczenie_.net.Migrations
{
    public partial class booksNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                schema: "dbo",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Tittle",
                schema: "dbo",
                table: "Books",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Section",
                schema: "dbo",
                table: "Books",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                schema: "dbo",
                table: "Books",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                schema: "dbo",
                table: "Books",
                column: "Tittle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                schema: "dbo",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Section",
                schema: "dbo",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                schema: "dbo",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Tittle",
                schema: "dbo",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                schema: "dbo",
                table: "Books",
                column: "idBook");
        }
    }
}
