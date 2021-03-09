using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class initiaMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RRE_Info",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(9)", nullable: false),
                    name = table.Column<string>(type: "varchar(200)", nullable: true),
                    address1 = table.Column<string>(type: "varchar(150)", nullable: true),
                    address2 = table.Column<string>(type: "varchar(150)", nullable: true),
                    address3 = table.Column<string>(type: "varchar(150)", nullable: true),
                    city = table.Column<string>(type: "varchar(150)", nullable: true),
                    state = table.Column<string>(type: "char(2)", nullable: true),
                    zip_code = table.Column<string>(type: "char(5)", nullable: true),
                    zip_ext = table.Column<string>(type: "char(4)", nullable: true),
                    phone1 = table.Column<string>(type: "varchar(10)", nullable: true),
                    phone2 = table.Column<string>(type: "varchar(10)", nullable: true),
                    email1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    email2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    reporting_period = table.Column<int>(type: "int", nullable: true),
                    tin = table.Column<string>(type: "char(9)", nullable: true),
                    authorized_rep = table.Column<string>(type: "varchar(50)", nullable: true),
                    authorized_rep_email = table.Column<string>(type: "varchar(50)", nullable: true),
                    account_manager = table.Column<string>(type: "varchar(50)", nullable: true),
                    account_id = table.Column<int>(type: "int", nullable: true),
                    subsidiary_name = table.Column<string>(type: "varchar(150)", nullable: true),
                    address4 = table.Column<string>(type: "varchar(150)", nullable: true),
                    country = table.Column<string>(type: "varchar(150)", nullable: true),
                    authorized_rep_phone = table.Column<string>(type: "varchar(150)", nullable: true),
                    data_specialist = table.Column<string>(type: "varchar(150)", nullable: true),
                    reporting_agent = table.Column<string>(type: "varchar(150)", nullable: true),
                    sir_indicator = table.Column<string>(type: "varchar(10)", nullable: true),
                    exclude_reporting = table.Column<bool>(type: "bit", nullable: true),
                    active_from = table.Column<DateTime>(type: "datetime", nullable: true),
                    active_to = table.Column<DateTime>(type: "datetime", nullable: true),
                    site_id_mailing_name = table.Column<string>(type: "varchar(150)", nullable: true),
                    rre_status = table.Column<byte>(type: "tinyint", nullable: true),
                    deactivated = table.Column<byte>(type: "tinyint", nullable: true),
                    mq_period = table.Column<int>(type: "int", nullable: true),
                    mq_day = table.Column<int>(type: "int", nullable: true),
                    received_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    rre_stat = table.Column<int>(type: "int", nullable: true),
                    tpra_id = table.Column<int>(type: "int", nullable: true),
                    edi_rep_name = table.Column<string>(type: "varchar(200)", nullable: true),
                    edi_rep_email = table.Column<string>(type: "varchar(200)", nullable: true),
                    edi_rep_phone = table.Column<string>(type: "varchar(200)", nullable: true),
                    agent_flag = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RRE_Info", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RRE_Info");
        }
    }
}
