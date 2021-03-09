using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class ValidateCI04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE FUNCTION [dbo].[ValidateCI04]
(
	@stateofVenue as varchar(7)

)
RETURNS int
AS
BEGIN
	if  ( UPPER(@stateofVenue) = 'FC' or UPPER(@stateofVenue)='US' )  or ((@stateofVenue) in (select code FROM  dbo.State ))
	return 1;

	return 0;
END
";

            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
