using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class initialMigration13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TPOC_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    tpoc_date = table.Column<DateTime>(type: "date", nullable: true),
                    tpoc_amount = table.Column<decimal>(type: "numeric(11, 2)", nullable: true),
                    fund_delayed_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    sequence = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPOC_Info", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TPOC_Info");
        }
    }
}
