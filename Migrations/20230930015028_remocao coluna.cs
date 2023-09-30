using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CamposDealerWebProject.Migrations
{
    /// <inheritdoc />
    public partial class remocaocoluna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VlrUnitarioVenda",
                table: "Vendas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "VlrUnitarioVenda",
                table: "Vendas",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
