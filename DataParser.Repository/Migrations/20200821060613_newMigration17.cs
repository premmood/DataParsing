using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class newMigration17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Response_File");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Response_File",
                columns: table => new
                {
                    seq_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_id = table.Column<int>(type: "int", nullable: true),
                    claim_control_num = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    error_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    field_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rre_info_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response_File", x => x.seq_id);
                });
        }
    }
}
