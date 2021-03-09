using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class initialMigration8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "injury_cause",
                table: "Injury_Info",
                type: "char(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[char](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_indicator",
                table: "Injury_Info",
                type: "char(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[char](1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code9",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code8",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code7",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code6",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code5",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code4",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code3",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code2",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code19",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code18",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code17",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code16",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code15",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code14",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code13",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code12",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code11",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code10",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code1",
                table: "Injury_Info",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "[varchar](8)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Insurance_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    self_ins_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    self_ins_type = table.Column<string>(type: "char(1)", nullable: true),
                    policy_holder_last_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    policy_holder_first_name = table.Column<string>(type: "varchar(30)", nullable: true),
                    dba_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    legal_name = table.Column<string>(type: "varchar(70)", nullable: true),
                    policy_no = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance_Info", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insurance_Info");

            migrationBuilder.AlterColumn<string>(
                name: "injury_cause",
                table: "Injury_Info",
                type: "[char](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_indicator",
                table: "Injury_Info",
                type: "[char](1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code9",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code8",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code7",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code6",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code5",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code4",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code3",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code2",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code19",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code18",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code17",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code16",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code15",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code14",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code13",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code12",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code11",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code10",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "icd_code1",
                table: "Injury_Info",
                type: "[varchar](8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);
        }
    }
}
