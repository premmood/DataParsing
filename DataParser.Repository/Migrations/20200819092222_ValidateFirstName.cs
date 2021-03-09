using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class ValidateFirstName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE FUNCTION  [dbo].[ValidateFirstName]
(
	@field_value as varchar(30)
)
RETURNS int
AS
BEGIN
	
	if  PATINDEX('%[^a-z ]%',@field_value)!=0 or dbo.ValidateRequired(@field_value)=0
	begin
		return 0;
	end
	if PATINDEX('%[^a-z]%',@field_value)=1
		return 0;
		
	 Return 1;

END";

            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


        }
    }
}
