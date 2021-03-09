using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class newMigration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Injury_Info_claim_info_id",
                table: "Injury_Info",
                column: "claim_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_Info_rre_info_id",
                table: "Claim_Info",
                column: "rre_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_Adjuster_Info_claim_info_id",
                table: "Adjuster_Info",
                column: "claim_info_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adjuster_Info_Claim_Info_claim_info_id",
                table: "Adjuster_Info",
                column: "claim_info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Claim_Info_RRE_Info_rre_info_id",
                table: "Claim_Info",
                column: "rre_info_id",
                principalTable: "RRE_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Injury_Info_Claim_Info_claim_info_id",
                table: "Injury_Info",
                column: "claim_info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adjuster_Info_Claim_Info_claim_info_id",
                table: "Adjuster_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Claim_Info_RRE_Info_rre_info_id",
                table: "Claim_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Injury_Info_Claim_Info_claim_info_id",
                table: "Injury_Info");

            migrationBuilder.DropIndex(
                name: "IX_Injury_Info_claim_info_id",
                table: "Injury_Info");

            migrationBuilder.DropIndex(
                name: "IX_Claim_Info_rre_info_id",
                table: "Claim_Info");

            migrationBuilder.DropIndex(
                name: "IX_Adjuster_Info_claim_info_id",
                table: "Adjuster_Info");
        }
    }
}
