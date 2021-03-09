using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class newMigration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Insurance_Info_claim_info_id",
                table: "Insurance_Info",
                column: "claim_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_Injuredparty_Rep_Info_claim_info_id",
                table: "Injuredparty_Rep_Info",
                column: "claim_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_Injuredparty_Info_claim_info_id",
                table: "Injuredparty_Info",
                column: "claim_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_Claimant_Info_claim_Info_id",
                table: "Claimant_Info",
                column: "claim_Info_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Claimant_Info_Claim_Info_claim_Info_id",
                table: "Claimant_Info",
                column: "claim_Info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Injuredparty_Info_Claim_Info_claim_info_id",
                table: "Injuredparty_Info",
                column: "claim_info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Injuredparty_Rep_Info_Claim_Info_claim_info_id",
                table: "Injuredparty_Rep_Info",
                column: "claim_info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Insurance_Info_Claim_Info_claim_info_id",
                table: "Insurance_Info",
                column: "claim_info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claimant_Info_Claim_Info_claim_Info_id",
                table: "Claimant_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Injuredparty_Info_Claim_Info_claim_info_id",
                table: "Injuredparty_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Injuredparty_Rep_Info_Claim_Info_claim_info_id",
                table: "Injuredparty_Rep_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Insurance_Info_Claim_Info_claim_info_id",
                table: "Insurance_Info");

            migrationBuilder.DropIndex(
                name: "IX_Insurance_Info_claim_info_id",
                table: "Insurance_Info");

            migrationBuilder.DropIndex(
                name: "IX_Injuredparty_Rep_Info_claim_info_id",
                table: "Injuredparty_Rep_Info");

            migrationBuilder.DropIndex(
                name: "IX_Injuredparty_Info_claim_info_id",
                table: "Injuredparty_Info");

            migrationBuilder.DropIndex(
                name: "IX_Claimant_Info_claim_Info_id",
                table: "Claimant_Info");
        }
    }
}
