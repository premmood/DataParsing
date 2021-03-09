using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class initialMigration19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claim_Error",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    error_code = table.Column<string>(type: "char(6)", nullable: true),
                    field_name = table.Column<string>(type: " varchar(50)", nullable: true),
                    value = table.Column<string>(type: "varchar(200)", nullable: true),
                    error_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    corrected = table.Column<string>(type: "char(1)", nullable: true),
                    corrected_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<int>(nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_by = table.Column<int>(nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    error_type = table.Column<string>(type: "char(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim_Error", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claim_Error");
        }
    }
}
