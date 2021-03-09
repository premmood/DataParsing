using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class ValidateMidName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE FUNCTION  [dbo].[ValidateMidName]
(
	@field_value as char
)
RETURNS int
AS
BEGIN
	
	if @field_value not like '[a-z ]' or len(@field_value)>0
	begin
		return 0;
	end

	Return 1;

END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
