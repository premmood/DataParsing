using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class migratin2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Claim_Staging",
                table: "Claim_Staging");

            migrationBuilder.RenameTable(
                name: "Claim_Staging",
                newName: "ClaimStaging");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClaimStaging",
                table: "ClaimStaging",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClaimStaging",
                table: "ClaimStaging");

            migrationBuilder.RenameTable(
                name: "ClaimStaging",
                newName: "Claim_Staging");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Claim_Staging",
                table: "Claim_Staging",
                column: "id");
        }
    }
}
