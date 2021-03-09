using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class ValidateLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE FUNCTION  [dbo].[ValidateLastName]
(
	@field_value as varchar(40)
)
RETURNS int
AS
BEGIN
	
	if PATINDEX('%[^a-z'' -]%',@field_value)!=0 or dbo.ValidateRequired(@field_value)=0
	begin
		return 0;
	end
	else if PATINDEX('%[^a-z]%',@field_value)=1
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
