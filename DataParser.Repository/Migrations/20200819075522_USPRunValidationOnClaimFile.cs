using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class USPRunValidationOnClaimFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE  [dbo].[USPRunValidationOnClaimFile]
(
	@file_id as int
)
AS
BEGIN
declare @result int ;

 set nocount on;
	declare @isLocked as char(1)
	set @isLocked=0
	select @isLocked=is_locked from dbo.validation_lock;

	if(@isLocked=1) 
	begin
		RAISERROR('Validation is locked', 16,1);
	END
	update validation_lock set is_locked=1;

	truncate table dbo.validation_staging
	
	--drop table validation_staging
	--select * into validation_staging from vw_claimmaster where 1=2


	insert  into dbo.validation_staging 
	select * from vw_claimmaster where [file_id]=@file_id and  action_type_Desc not in ('DELETE', 'STOP');

	--exec [RunBulkValidation] @file_id, 'CB04', 'ip_dob', 'dbo.ValidateCB04(ip_hicn,ip_ssn)=0'
	--exec [RunBulkValidation] @file_id, 'CB06', 'ip_dob', 'dbo.ValidateCB06(ip_ssn,ip_hicn)=0'

	exec [RunBulkValidation] @file_id, 'CB07', 'ip_last_name', 'dbo.ValidateLastName(ip_last_name)=0'
	exec [RunBulkValidation] @file_id, 'CB08', 'ip_first_name', 'dbo.ValidateFirstName(ip_first_name)=0'
	exec [RunBulkValidation] @file_id, 'CB09', 'ip_middle_initial', 'dbo.ValidateMidName(ip_middle_initial)=0'
	exec [RunBulkValidation] @file_id, 'CB10', 'ip_gender', 'dbo.ValidateCB10(ip_gender)=0'
	exec [RunBulkValidation] @file_id, 'CB11', 'ip_dob', 'dbo.ValidateCB11(ip_dob)=0'
	
	exec [RunBulkValidation] @file_id, 'CI01', 'venue_state', 'dbo.ValidateCI04(venue_state)=0'
	exec [RunBulkValidation] @file_id, 'CI02', 'venue_state', 'dbo.ValidateCI04(venue_state)=0'

	exec [RunBulkValidation] @file_id, 'CI04', 'venue_state', 'dbo.ValidateCI04(venue_state)=0'


	--insert into claim_error(claim_info_id, error_code, field_name, value, error_date, corrected, created_by, created_date)
	--select claim_detai_id, 'CI01', 'cms_doi', cms_doi, current_timestamp, 'N', 1007, current_timestamp 
	--from vw_claimmaster where dbo.ValidateCI01(cms_doi,ip_dob,applied_ip_dob,next_date_from)=0 and status not in ('Stopped','Deleted')
	--and rre_info_id not in (select id from rre_info where reporting_period=0);

	insert into claim_error(claim_info_id, error_code, field_name, value, error_date, corrected, created_by, created_date)
	select claim_info_id, 'CI02', 'industry_doi', industry_doi, current_timestamp, 'N', 1007, current_timestamp 
	from vw_claimmaster where dbo.ValidateCI02(industry_doi,next_date_from)=0 and status not in ('Stopped','Deleted')
	and rre_info_id not in (select id from rre_info where reporting_period=0);

	
	UPDATE validation_lock SET is_locked=0;


end ";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
