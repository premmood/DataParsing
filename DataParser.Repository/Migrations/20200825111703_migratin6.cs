using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class migratin6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimInfo_RREInfo_rre_info_id",
                table: "ClaimInfo");

            migrationBuilder.DropIndex(
                name: "IX_ClaimInfo_rre_info_id",
                table: "ClaimInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ClaimInfo_rre_info_id",
                table: "ClaimInfo",
                column: "rre_info_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimInfo_RREInfo_rre_info_id",
                table: "ClaimInfo",
                column: "rre_info_id",
                principalTable: "RREInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
