using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class newMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TIN_Info_rre_info_id",
                table: "TIN_Info",
                column: "rre_info_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TIN_Info_RRE_Info_rre_info_id",
                table: "TIN_Info",
                column: "rre_info_id",
                principalTable: "RRE_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TIN_Info_RRE_Info_rre_info_id",
                table: "TIN_Info");

            migrationBuilder.DropIndex(
                name: "IX_TIN_Info_rre_info_id",
                table: "TIN_Info");
        }
    }
}
