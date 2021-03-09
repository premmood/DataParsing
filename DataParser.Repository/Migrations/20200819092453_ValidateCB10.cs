using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class ValidateCB10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE FUNCTION  [dbo].[ValidateCB10]
(
	-- Add the parameters for the function here
	@Type as char(7)
	
)
RETURNS int
AS
BEGIN
	
	if @Type like '[012]' or Upper(@Type) = 'FEMALE' or Upper(@Type) = 'MALE' or UPPER(@Type) = 'UNKNOWN'
		return 1;

	Return 0;

END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
