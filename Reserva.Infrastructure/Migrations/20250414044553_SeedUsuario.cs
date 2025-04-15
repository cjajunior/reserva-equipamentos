using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reserva.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nome", "Role" },
                values: new object[] { 1, "", "Administrador", "Professor" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
