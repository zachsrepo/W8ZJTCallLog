using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallLogTesting.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_681 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FccId",
                table: "Hams",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FccId",
                table: "Hams");
        }
    }
}
