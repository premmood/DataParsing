using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class initialMigration16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plan_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    plan_ins_type = table.Column<string>(type: "char(1)", nullable: true),
                    contact_dept = table.Column<string>(type: "varchar(70)", nullable: true),
                    contact_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    contact_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    contact_phone = table.Column<string>(type: "varchar(10)", nullable: true),
                    contact_phone_ext = table.Column<string>(type: "char(5)", nullable: true),
                    no_fault_limit = table.Column<decimal>(type: "numeric(11, 2)", nullable: true),
                    exhaust_date = table.Column<DateTime>(type: "date", nullable: true),
                    lost_time = table.Column<string>(type: "varchar(20)", nullable: true),
                    total_medical_spent = table.Column<decimal>(type: "numeric(11, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan_Info", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plan_Info");
        }
    }
}
