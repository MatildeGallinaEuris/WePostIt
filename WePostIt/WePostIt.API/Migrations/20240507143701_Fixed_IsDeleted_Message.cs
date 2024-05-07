using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WePostIt.API.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_IsDeleted_Message : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdDeleted",
                table: "Messages",
                newName: "IsDeleted");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Messages",
                newName: "IdDeleted");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
