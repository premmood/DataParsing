using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class newMigration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claim_Info_RRE_Info_rre_info_id",
                table: "Claim_Info");

            migrationBuilder.DropIndex(
                name: "IX_Claim_Info_rre_info_id",
                table: "Claim_Info");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Claim_Info_rre_info_id",
                table: "Claim_Info",
                column: "rre_info_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Claim_Info_RRE_Info_rre_info_id",
                table: "Claim_Info",
                column: "rre_info_id",
                principalTable: "RRE_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
