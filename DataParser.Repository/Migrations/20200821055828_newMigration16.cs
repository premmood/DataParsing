using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class newMigration16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Response_File",
                columns: table => new
                {
                    seq_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_control_num = table.Column<string>(nullable: true),
                    error_code = table.Column<string>(nullable: true),
                    field_name = table.Column<string>(nullable: true),
                    account_id = table.Column<int>(nullable: true),
                    rre_info_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response_File", x => x.seq_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Response_File");
        }
    }
}
