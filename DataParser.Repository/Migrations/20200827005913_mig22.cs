using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class mig22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponseFile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResponseFile",
                columns: table => new
                {
                    seq_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_id = table.Column<int>(type: "int", nullable: true),
                    claim_control_num = table.Column<string>(type: "varchar(50)", nullable: true),
                    error_code = table.Column<string>(type: "char(6)", nullable: true),
                    fieldName = table.Column<string>(type: "varchar(50)", nullable: true),
                    rre_info_id = table.Column<string>(type: "char(9)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseFile", x => x.seq_id);
                });
        }
    }
}
