using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class newMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Product_Info_claim_info_id",
                table: "Product_Info",
                column: "claim_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_Info_claim_info_id",
                table: "Plan_Info",
                column: "claim_info_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_Info_Claim_Info_claim_info_id",
                table: "Plan_Info",
                column: "claim_info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Info_Claim_Info_claim_info_id",
                table: "Product_Info",
                column: "claim_info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_Info_Claim_Info_claim_info_id",
                table: "Plan_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Info_Claim_Info_claim_info_id",
                table: "Product_Info");

            migrationBuilder.DropIndex(
                name: "IX_Product_Info_claim_info_id",
                table: "Product_Info");

            migrationBuilder.DropIndex(
                name: "IX_Plan_Info_claim_info_id",
                table: "Plan_Info");
        }
    }
}
