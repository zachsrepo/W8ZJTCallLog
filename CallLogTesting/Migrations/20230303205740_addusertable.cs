using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallLogTesting.Migrations
{
    /// <inheritdoc />
    public partial class addusertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "band",
                table: "Hams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "frequency",
                table: "Hams",
                type: "decimal(10,3)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsersAndSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NumberOfCallsToShow = table.Column<int>(type: "int", nullable: false),
                    database = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAndSettings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersAndSettings");

            migrationBuilder.DropColumn(
                name: "band",
                table: "Hams");

            migrationBuilder.DropColumn(
                name: "frequency",
                table: "Hams");
        }
    }
}
