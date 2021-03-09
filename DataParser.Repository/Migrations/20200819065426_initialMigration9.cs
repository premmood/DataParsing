using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class initialMigration9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_info_id = table.Column<int>(nullable: true),
                    prd_liability_indicator = table.Column<string>(type: "char(1)", nullable: true),
                    prd_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    prd_brand_name = table.Column<string>(type: "varchar(40)", nullable: true),
                    prd_manufacturer = table.Column<string>(type: "varchar(40)", nullable: true),
                    prd_alleged_harm = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Info", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Info");
        }
    }
}
