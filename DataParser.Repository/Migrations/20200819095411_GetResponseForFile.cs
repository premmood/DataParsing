using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class GetResponseForFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetResponseForFile]
(
	@file_id as int
)
AS
BEGIN

	WITH error AS
	(
		select ci.file_id,ci.claim_control_num,ci.seq_id,error_code,field_name,description 
		from claim_info ci
		inner join claim_error ce on ci.id = ce.claim_info_id
		inner join error_code e on ce.error_code=e.code
		where ci.file_id=@file_id and ce.corrected='N'

		UNION ALL

		SELECT file_id,claim_control_number,seq_id,error_code,field_name,'' as description
		FROM file_error cd 
		inner join error_code ON cd.error_code = error_code.code 
		where file_id=@file_id
	)

	SELECT c.seq_id,c.claim_control_num,COALESCE(e.error_code,'') as error_code,COALESCE(e.field_name,'')
	as fieldName,c.account_id,c.rre_info_id from Claim_info c
	left join error e on c.seq_id=e.seq_id and c.file_id =e.file_id
	where c.file_id=@file_id
	order by c.seq_id,e.seq_id


END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
