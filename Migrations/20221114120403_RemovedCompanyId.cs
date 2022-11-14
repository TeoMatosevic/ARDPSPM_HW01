using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Span.Culturio.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemovedCompanyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "CultureObjects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "CultureObjects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
