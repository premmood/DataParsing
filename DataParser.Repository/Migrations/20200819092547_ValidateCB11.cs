using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class ValidateCB11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE FUNCTION[dbo].[ValidateCB11]
(
   @date as varchar(max)
)
RETURNS int
AS
BEGIN

    if ISDATE(@date) = 1

    begin

        if @date <= CURRENT_TIMESTAMP

            return 1;
            end

    return 0;

            END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
