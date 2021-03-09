using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class newMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UDF_Info_claim_info_id",
                table: "UDF_Info",
                column: "claim_info_id");

            migrationBuilder.AddForeignKey(
                name: "FK_UDF_Info_Claim_Info_claim_info_id",
                table: "UDF_Info",
                column: "claim_info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UDF_Info_Claim_Info_claim_info_id",
                table: "UDF_Info");

            migrationBuilder.DropIndex(
                name: "IX_UDF_Info_claim_info_id",
                table: "UDF_Info");
        }
    }
}
