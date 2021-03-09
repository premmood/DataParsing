using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class ValidateCI02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE FUNCTION [dbo].[ValidateCI02]
(
	@IndustryDOI as char(30),
	@next_date_from as datetime
)
RETURNS int
AS
BEGIN
if(isDate(@IndustryDOI)=1 and isDate(@next_date_from)=1 and @IndustryDOI>@next_date_from)
return 0;
if @IndustryDOI is null
  return 1;
	if ISDATE(@IndustryDOI)=0
		return 0; 
	if (isDate(@IndustryDOI)=1) and ((@IndustryDOI) >CURRENT_TIMESTAMP) 
		return 0;
	return 1;
END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
