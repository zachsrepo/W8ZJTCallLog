using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallLogTesting.Migrations.FccAmateur
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_137 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "fcc_amateur");

            migrationBuilder.CreateTable(
                name: "am",
                schema: "fcc_amateur",
                columns: table => new
                {
                    fccid = table.Column<int>(type: "int", nullable: false),
                    callsign = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    @class = table.Column<string>(name: "class", type: "nvarchar(1)", maxLength: 1, nullable: true),
                    col4 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    col5 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    col6 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    former_call = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    former_class = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_fccid", x => x.fccid);
                });

            migrationBuilder.CreateTable(
                name: "en",
                schema: "fcc_amateur",
                columns: table => new
                {
                    fccid = table.Column<int>(type: "int", nullable: false),
                    callsign = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    first = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    middle = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    last = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    address1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    state = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    zip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_en_fccid", x => x.fccid);
                });

            migrationBuilder.CreateTable(
                name: "hd",
                schema: "fcc_amateur",
                columns: table => new
                {
                    fccid = table.Column<int>(type: "int", nullable: false),
                    callsign = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    status = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hd_fccid", x => x.fccid);
                });

            migrationBuilder.CreateIndex(
                name: "idx_callsign",
                schema: "fcc_amateur",
                table: "am",
                column: "callsign");

            migrationBuilder.CreateIndex(
                name: "idx_class",
                schema: "fcc_amateur",
                table: "am",
                column: "class");

            migrationBuilder.CreateIndex(
                name: "idx_callsign",
                schema: "fcc_amateur",
                table: "en",
                column: "callsign");

            migrationBuilder.CreateIndex(
                name: "idx_zip",
                schema: "fcc_amateur",
                table: "en",
                column: "zip");

            migrationBuilder.CreateIndex(
                name: "idx_callsign",
                schema: "fcc_amateur",
                table: "hd",
                column: "callsign");

            migrationBuilder.CreateIndex(
                name: "idx_status",
                schema: "fcc_amateur",
                table: "hd",
                column: "status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "am",
                schema: "fcc_amateur");

            migrationBuilder.DropTable(
                name: "en",
                schema: "fcc_amateur");

            migrationBuilder.DropTable(
                name: "hd",
                schema: "fcc_amateur");
        }
    }
}
