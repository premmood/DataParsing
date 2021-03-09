using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class RunBulkValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[RunBulkValidation]
(
	@file_id AS INT, 
	@error_code AS char(6),
	@field_name AS varchar(50),
	@validation_rule AS varchar(500)
)
AS
BEGIN
	DECLARE @strqry as nvarchar(2000)
	

	SET @strqry = N'
		WITH temp_claim_error AS (
			SELECT claim_info_id, 
			'''+ @error_code + ''' AS error_code, 
			'''+ @field_name + ''' AS field_name,
			CAST('+@field_name+' AS VARCHAR(200)) AS value, 
			CURRENT_TIMESTAMP AS error_date,
			CASE WHEN ' + @validation_rule + ' THEN ''N'' ELSE ''Y'' END AS corrected	
		FROM validation_staging 
		) 
		
		MERGE claim_error AS ce 
			USING temp_claim_error AS T
				ON (ce.claim_info_id = T.claim_info_id and ce.field_name = T.field_name 
					and ce.error_code= T.error_code and (ce.corrected!=T.corrected 
					OR (ce.corrected=''N'' AND T.corrected= ''N'') )  )
		WHEN MATCHED
			THEN update SET ce.updated_date= T.error_date, ce.value =t.value, 
					ce.corrected=T.corrected,ce.updated_by=''1007'',
					ce.corrected_date = (CASE WHEN T.corrected =''Y'' THEN 
								T.error_date ELSE null END)
		WHEN NOT MATCHED And T.corrected=''N'' 
		THEN INSERT (claim_info_id,error_code,field_name,value,error_date,created_Date, corrected,created_by)
			VALUES (T.claim_info_id,T.error_code,T.field_name,T.value,T.error_date,T.error_date, ''N'',''1007'') ;';

	

	execute sp_executesql @strqry
	--print @strqry
END";

            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
