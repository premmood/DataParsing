using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class RunValidationOnClaimStaging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[RunValidationOnClaimStaging]
(
	@file_id AS INT
)
AS
BEGIN	
 
	
	--Validate ERROR-2 Claim Control Number blank  ------
	
	insert into file_error (seq_id,error_code,field_name,value,file_id,error_date,account_id,rre_info_id)
	select seq_id,'ERROR-2','Claim Control Number',claim_control_num,file_id,getdate(),account_id,rre_info_id
	from claim_staging where
	(file_id=@file_id and coalesce(claim_control_num,'') ='')
	

	---Validate ERROR-3 Duplicate Claim Control Number ---
	

	insert into file_error (seq_id,error_code,field_name,value,file_id,error_date,account_id,rre_info_id)
	select seq_id,'ERROR-3','Claim Control Number',claim_control_num,file_id,getdate(),account_id,rre_info_id
	from claim_staging where
	file_id=@file_id and seq_id in
	(select seq_id from (SELECT seq_id,row_number() over(partition by claim_control_num order by seq_id asc) as rnk FROM claim_staging ) as t
		   where t.rnk>1)
	

	---Validate ERROR-4 Invalid STOP Action Type -----------	
	insert into file_error (seq_id,error_code,field_name,value,file_id,error_date,account_id,rre_info_id)
	select seq_id,'ERROR-4','Action Type',action_type,file_id,getdate(),account_id,rre_info_id
	from claim_staging where
	file_id=@file_id and action_type ='STOP' and NOT exists
	 (SELECT * FROM claim_info WHERE  claim_staging.claim_control_num=Claim_info.claim_control_num)


	 ---Validate ERROR-5 Invalid DELETE Action Type -----------	
	insert into file_error (seq_id,error_code,field_name,value,file_id,error_date,account_id,rre_info_id)
	select seq_id,'ERROR-5','Invalid DELETE Action Type',action_type,file_id,getdate(),account_id,rre_info_id
	from claim_staging where
	file_id=@file_id and action_type ='DELETE' and NOT exists
	 (SELECT * FROM claim_info WHERE  claim_staging.claim_control_num=Claim_info.claim_control_num)	 

	-- Validate ERROR-6 RREID--

	insert into file_error (seq_id,error_code,field_name,value,file_id,error_date,account_id,rre_info_id)
	select seq_id,'ERROR-6','RREID',rre_info_id,file_id,getdate(),account_id,rre_info_id
	from claim_staging where
	file_id=@file_id and  (coalesce(rre_info_id,'') not in (select id FROM  dbo.rre_info ))

	
	
	 update claim_staging set status=1 where seq_id in 
	 (select seq_id from file_error where file_id=@file_id)

	 	 	
END


";

            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
