using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class newMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TIN_Info",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tin = table.Column<string>(type: "char(9)", nullable: true),
                    mailing_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    rre_info_id = table.Column<string>(type: "char(9)", nullable: true),
                    authorized_rep_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    mail_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    mail_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    city = table.Column<string>(type: "varchar(30)", nullable: true),
                    state = table.Column<string>(type: "char(2)", nullable: true),
                    zip = table.Column<string>(type: "char(5)", nullable: true),
                    zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    foreign_rre_address1 = table.Column<string>(type: "varchar(32)", nullable: true),
                    foreign_rre_address2 = table.Column<string>(type: "varchar(32)", nullable: true),
                    foreign_rre_address3 = table.Column<string>(type: "varchar(32)", nullable: true),
                    foreign_rre_address4 = table.Column<string>(type: "varchar(32)", nullable: true),
                    status = table.Column<int>(nullable: true),
                    submission_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<int>(nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_by = table.Column<int>(nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    site_id = table.Column<string>(type: "varchar(9)", nullable: true),
                    agent_mailing_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    agent_mail_address1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    agent_mail_address2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    agent_city = table.Column<string>(type: "varchar(30)", nullable: true),
                    agent_state = table.Column<string>(type: "char(2)", nullable: true),
                    agent_zip = table.Column<string>(type: "char(5)", nullable: true),
                    agent_zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    file_id = table.Column<int>(nullable: true),
                    seq_num = table.Column<int>(nullable: true),
                    account_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIN_Info", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UDF_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    future_field1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field3 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field4 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field5 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field6 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field7 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field8 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field9 = table.Column<string>(type: "varchar(50)", nullable: true),
                    future_field10 = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UDF_Info", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TIN_Info");

            migrationBuilder.DropTable(
                name: "UDF_Info");
        }
    }
}
