using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class MergeCascadingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[MergeCascadingTables]
AS
BEGIN


DECLARE @ErrorMessage NVARCHAR(4000);
DECLARE @ErrorSeverity INT;
DECLARE @ErrorState INT;
DECLARE @ErrorLine INT;
DECLARE @ErrorNumber INT;
DECLARE @table_name varchar(100);
DECLARE @mssg nvarchar(max);
DECLARE @file_id int;





SET XACT_ABORT, NOCOUNT ON

BEGIN TRY
	BEGIN TRANSACTION masterTransaction
				----------CLAIM_DETAIL------------
				
				DECLARE @FinalMetadata TABLE
				(
					data_id INT,
					claim_control_num varchar(50),
					rre_info_id varchar(5),
					account_id int
				);
					WITH main_claim_staging as 
				(
  					SELECT [seq_id],[claim_control_num],[file_id],[rre_info_id],[cms_doi],[industry_doi],
  					[orm_term_date],[venue_state],[office_code],
					[claim_no] ,[action_type] ,[orm_indicator],[account_id],
					[tin],[created_date] from claim_staging 
					where 
					COALESCE(status,0)!=1 --and COALESCE(status,0)!=2	and client_action_type not in ('DELETE','STOP')
				)
				MERGE  claim_info AS T USING  main_claim_staging AS S 
								ON (S.claim_control_num = T.claim_control_num AND S.rre_info_id = T.rre_info_id and s.account_id= T.account_id)
                
						WHEN Matched 
						THEN UPDATE  
									SET                   	
                  					T.[file_id] = S.[file_id],														
                  					T.[seq_id] = S.[seq_id] ,
									T.[claim_control_num] = S.[claim_control_num] ,
									T.[rre_info_id] = S.[rre_info_id],	
									T.[action_type] =S.[action_type] ,														
									T.[account_id]= S.[account_id]  ,
									T.[cms_doi] = S.[cms_doi] ,
									T.[industry_doi] = S.[industry_doi] ,														
									T.[orm_term_date] = S.[orm_term_date] ,
									T.[venue_state] = S.[venue_state] ,
									T.[office_code] = S.[office_code] ,
									T.[claim_no] = S.[claim_no] ,
									T.[orm_indicator]=S.[orm_indicator],
									T.[tin] = S.[tin],														
									T.[updated_by]=1007,														
									T.[updated_date]=S.[created_date]
						WHEN Not Matched     
						THEN INSERT ([seq_id],[claim_control_num],[file_id],[rre_info_id],[cms_doi],[industry_doi],
  					[orm_term_date],[venue_state],[office_code],
					[claim_no] ,[action_type] ,[orm_indicator],[account_id],
					[tin],[created_date],[created_by])   
						VALUES ( S.[seq_id],S.[claim_control_num],S.[file_id],S.[rre_info_id],S.[cms_doi],S.[industry_doi],
  					S.[orm_term_date],S.[venue_state],S.[office_code],
					S.[claim_no] ,S.[action_type] ,S.[orm_indicator],S.[account_id],
					S.[tin],S.[created_date],1007)  
										
				OUTPUT inserted.id,inserted.[claim_control_num],inserted.[rre_info_id],inserted.[account_id] into @FinalMetadata;

				--- For Updating claim_info_id on staging table for inserted rows

				UPDATE c SET c.claim_info_id=s.data_id
				from claim_staging c inner join @FinalMetadata s ON
				c.claim_control_num =  s.claim_control_num and c.rre_info_id = s.rre_info_id and c.account_id = s.account_id

				--- New changes for prod 0180

				--UPDATE c SET c.client_action_type = s.client_action_type,
				--				c.[file_id] = s.[file_id],
				--				c.[updated_by]=1007,
				--				c.[updated_date]=s.[created_date],
				--				c.[record_num]=s.[record_num]
				--from claim_detail c INNER JOIN claim_staging s ON 
				--(c.incident_key = s.incident_key AND c.ip_key = s.ip_key)
				--where s.client_action_type='DELETE' and COALESCE(s.status,0)!=1 --and COALESCE(s.status,0)!=2

									

				--UPDATE c SET c.client_action_type = s.client_action_type,
				--				c.[file_id] = s.[file_id],
				--				c.[action_reason]=s.[action_reason],
				--				c.[updated_by]=1007,
				--				c.[updated_date]=s.[created_date],
				--				c.[record_num]=s.[record_num]
				--from claim_detail c INNER JOIN claim_staging s ON 
				--(c.incident_key = s.incident_key AND c.ip_key = s.ip_key)
				--where s.client_action_type='STOP' and COALESCE(s.status,0)!=1 ---and COALESCE(s.status,0)!=2

				--- For Updating claim_detail_id on staging table for updated rows

				UPDATE c SET c.claim_info_id = d.id
				FROM claim_staging c INNER JOIN claim_info d 
				ON ( c.claim_control_num = d.claim_control_num AND c.rre_info_id = d.rre_info_id AND c.account_id = d.account_id )
									
					
				----------
				----------InjuredParty_info-----
				
					
				;WITH ip_claim_staging as 
				(
  					SELECT claim_info_id,ip_mbi,ip_hicn,ip_ssn,ip_last_name,
  					ip_first_name,ip_middle_initial,ip_gender,ip_dob,
  					ip_dod,ip_address1,ip_address2,ip_city,ip_state,
  					ip_zip_code,ip_zip_ext,ip_phone ,ip_phone_ext  
					from claim_staging S
					where 
					COALESCE(S.status,0)!=1 AND  --COALESCE(status,0)!=2	AND  client_action_type not in ('DELETE','STOP') AND
					(COALESCE(S.[ip_mbi],'')!='' OR COALESCE(S.[ip_hicn],'')!='' OR COALESCE(S.[ip_ssn],'')!='' OR
					COALESCE(S.[ip_last_name],'')!='' OR COALESCE(S.[ip_first_name],'')!='' OR
					COALESCE(S.[ip_middle_initial],'')!='' OR COALESCE(S.[ip_gender],'')!='' OR
					COALESCE(S.[ip_dob],'')!=''  OR COALESCE(S.[ip_dod],'')!='' OR 
					COALESCE(S.[ip_address1],'')!='' OR COALESCE(S.[ip_address2],'')!='' OR
					COALESCE(S.[ip_city],'')!='' OR COALESCE(S.[ip_state],'')!='' OR
					COALESCE(S.[ip_zip_code],'')!='' OR COALESCE(S.[ip_zip_ext],'')!=''  OR
					COALESCE(S.[ip_phone],'')!='' OR COALESCE(S.[ip_phone_ext],'')!=''	OR 
					S.claim_info_id in (select claim_info_id from InjuredParty_info))
					)
						MERGE  InjuredParty_info AS T USING  ip_claim_staging AS S 
								ON (S.claim_info_id = T.claim_info_id) 			
						WHEN Matched      
						THEN      
						UPDATE  
									SET        
									T.[mbi] = S.[ip_mbi] ,													  
                  					T.[hicn] = S.[ip_hicn] ,
									T.[ssn] = S.[ip_ssn] ,
									T.[last_name]= S.[ip_last_name]  ,					
									T.[first_name] = S.[ip_first_name],
									T.[middle_initial] = S.[ip_middle_initial] ,
									T.[gender]= S.[ip_gender]  ,
									T.[dob]= S.[ip_dob]  ,
									T.[dod] = S.[ip_dod],					
									T.[address1] = S.[ip_address1] ,
									T.[address2] = S.[ip_address2] ,
									T.[city]= S.[ip_city]  ,					
									T.[state] = S.[ip_state],
									T.[zip_code] = S.[ip_zip_code] ,
									T.[zip_ext]= S.[ip_zip_ext]  ,
									T.[phone]= S.[ip_phone]  ,
									T.[phone_ext] = S.[ip_phone_ext]
					
						WHEN Not Matched     
						THEN INSERT ([claim_info_id],[ssn],[mbi],[hicn],[last_name],[first_name],[middle_initial] ,
									[gender],[dob],[dod],[address1],[address2]  ,[city]  ,[state],[zip_code],
									[zip_ext] ,[phone],[phone_ext])  										
						VALUES ( S.[claim_info_id], S.[ip_ssn],S.[ip_mbi],S.[ip_hicn],S.[ip_last_name],S.[ip_first_name],S.[ip_middle_initial],  
							S.[ip_gender], S.[ip_dob], S.[ip_dod],S.[ip_address1], S.[ip_address2] ,S.[ip_city],S.[ip_state],S.[ip_zip_code],
							S.[ip_zip_ext], S.[ip_phone], S.[ip_phone_ext]); 
					
				----------
				----------INJUREDPARTY_REP_DETAIL-
			
		;WITH ip_rep_claim_staging as 
		(
  			SELECT claim_info_id,ip_rep_indicator,ip_rep_last_name,ip_rep_first_name,
  			ip_rep_firm_name,ip_rep_tin,ip_rep_address1,ip_rep_address2,
  			ip_rep_city,ip_rep_state,ip_rep_zip_code,ip_rep_zip_ext,ip_rep_phone,
  			ip_rep_phone_ext
			from claim_staging S
			where 
			COALESCE(S.status,0)!=1  and --COALESCE(status,0)!=2	AND client_action_type not in ('DELETE','STOP') AND
			(COALESCE(S.[ip_rep_indicator],'')!='' OR COALESCE(S.[ip_rep_last_name],'')!='' OR
			COALESCE(S.[ip_rep_first_name],'')!='' OR COALESCE(S.[ip_rep_firm_name],'')!='' OR
			COALESCE(S.[ip_rep_tin],'')!='' OR COALESCE(S.[ip_rep_address1],'')!='' OR
			COALESCE(S.[ip_rep_address2],'')!=''  OR
			COALESCE(S.[ip_rep_city],'')!='' OR COALESCE(S.[ip_rep_state],'')!='' OR
			COALESCE(S.[ip_rep_zip_code],'')!='' OR COALESCE(S.[ip_rep_zip_ext],'')!='' OR
			COALESCE(S.[ip_rep_phone],'')!='' OR COALESCE(S.[ip_rep_phone_ext],'')!='' OR 
			S.claim_info_id in (select claim_info_id from Injuredparty_rep_Info))
			)

				MERGE  Injuredparty_rep_Info AS T USING  ip_rep_claim_staging AS S 
						ON (S.claim_info_id = T.claim_info_id) 
				WHEN Matched 
				THEN UPDATE  
							SET                   	
                  			T.[rep_indicator] = S.[ip_rep_indicator] ,					
							T.[last_name]= S.[ip_rep_last_name]  ,					
							T.[first_name] = S.[ip_rep_first_name],
							T.[firm_name] = S.[ip_rep_firm_name] ,					
							T.[tin]= S.[ip_rep_tin]  ,				
							T.[address1] = S.[ip_rep_address1] ,
							T.[address2] = S.[ip_rep_address2] ,
							T.[city]= S.[ip_rep_city]  ,					
							T.[state] = S.[ip_rep_state],
							T.[zip_code] = S.[ip_rep_zip_code] ,
							T.[zip_ext]= S.[ip_rep_zip_ext]  ,
							T.[phone]= S.[ip_rep_phone]  ,
							T.[phone_ext] = S.[ip_rep_phone_ext]
				WHEN Not Matched     
				THEN INSERT ([claim_info_id],[rep_indicator],[last_name],[first_name],[firm_name],[tin] ,
							[address1],[address2],[city],[state],[zip_code],[zip_ext],[phone],[phone_ext])									
				VALUES ( S.[claim_info_id], S.[ip_rep_indicator] ,S.[ip_rep_last_name],S.[ip_rep_first_name],S.[ip_rep_firm_name],S.[ip_rep_tin],  
					S.[ip_rep_address1], S.[ip_rep_address2], S.[ip_rep_city],S.[ip_rep_state], S.[ip_rep_zip_code] ,S.[ip_rep_zip_ext],
					S.[ip_rep_phone],S.[ip_rep_phone_ext]); 
					
				----------
				----------CLAIM_INJURY_DESC-------
				
								
					;WITH claim_injury_staging as 
					(
  						SELECT claim_info_id,injury_cause,
  						icd_indicator,icd_code1,icd_code2,icd_code3,icd_code4,icd_code5,icd_code6,
  						icd_code7,icd_code8,icd_code9,icd_code10,icd_code11,icd_code12,icd_code13,
  						icd_code14,icd_code15,icd_code16,icd_code17,icd_code18,icd_code19
  	
						from claim_staging S
						where 
						COALESCE(S.status,0)!=1  and --COALESCE(status,0)!=2	AND client_action_type not in ('DELETE','STOP') AND 
						--(COALESCE(S.[illness_desc],'')!='' OR COALESCE(S.[injury_nature],'')!='' OR
						COALESCE(S.[injury_cause],'')!='' OR --COALESCE(S.[body_part],'')!='' OR
						--COALESCE(S.[disability_severity_cd],'')!='' OR
						COALESCE(S.[icd_indicator],'')!='' OR
						COALESCE(S.[icd_code1],'')!=''  OR COALESCE(S.[icd_code2],'')!='' OR COALESCE(S.[icd_code3],'')!=''
						OR COALESCE(S.[icd_code4],'')!=''  OR COALESCE(S.[icd_code5],'')!='' OR COALESCE(S.[icd_code6],'')!=''
						OR COALESCE(S.[icd_code7],'')!=''  OR COALESCE(S.[icd_code8],'')!='' OR COALESCE(S.[icd_code9],'')!=''
						OR COALESCE(S.[icd_code10],'')!='' OR COALESCE(S.[icd_code11],'')!='' OR COALESCE(S.[icd_code12],'')!='' 
						OR COALESCE(S.[icd_code13],'')!=''
						OR COALESCE(S.[icd_code14],'')!=''  OR COALESCE(S.[icd_code15],'')!='' OR COALESCE(S.[icd_code16],'')!=''
						OR COALESCE(S.[icd_code17],'')!=''  OR COALESCE(S.[icd_code18],'')!='' OR COALESCE(S.[icd_code19],'')!=''
						OR 
						S.claim_info_id in (select claim_info_id from Injury_Info)
						)
							MERGE  Injury_Info AS T USING claim_injury_staging AS S 
									ON (S.claim_info_id = T.claim_info_id) 
							WHEN Matched 
							THEN UPDATE  
										SET                   	
                  						--T.[illness_desc] = S.[Illness_Desc] ,T.[injury_nature] = S.[injury_nature],
										T.[injury_cause] = S.[injury_cause] ,
										--T.[body_part]= S.[body_part]  ,
										--T.[disability_severity_cd]= S.[disability_severity_cd]  ,
										T.[icd_indicator] = S.[icd_indicator] ,		
										T.[icd_code1] = S.[icd_code1] ,
										T.[icd_code2] = S.[icd_code2] ,
										T.[icd_code3] = S.[icd_code3] ,
										T.[icd_code4] = S.[icd_code4] ,
										T.[icd_code5] = S.[icd_code5] ,
										T.[icd_code6] = S.[icd_code6] ,
										T.[icd_code7] = S.[icd_code7] ,
										T.[icd_code8] = S.[icd_code8] ,
										T.[icd_code9] = S.[icd_code9] ,
										T.[icd_code10] = S.[icd_code10] ,
										T.[icd_code11] = S.[icd_code11] ,
										T.[icd_code12] = S.[icd_code12] ,
										T.[icd_code13] = S.[icd_code13] ,
										T.[icd_code14] = S.[icd_code14] ,
										T.[icd_code15] = S.[icd_code15] ,
										T.[icd_code16] = S.[icd_code16] ,
										T.[icd_code17] = S.[icd_code17] ,
										T.[icd_code18] = S.[icd_code18] ,
										T.[icd_code19] = S.[icd_code19] 
							WHEN Not Matched     
							THEN INSERT ([claim_info_id], --[illness_desc] ,[injury_nature],
									[injury_cause],
										--[body_part],[disability_severity_cd],
										[icd_indicator],
										[icd_code1],[icd_code2],[icd_code3],[icd_code4],
										[icd_code5],[icd_code6],[icd_code7],[icd_code8],
										[icd_code9],[icd_code10],[icd_code11],[icd_code12],
										[icd_code13],[icd_code14],[icd_code15] ,[icd_code16], 
										[icd_code17] ,[icd_code18],[icd_code19] )   
							VALUES ( S.[claim_info_id], --S.[Illness_Desc] ,S.[injury_nature],
									S.[injury_cause] ,
										--S.[body_part]  ,S.[disability_severity_cd]  ,
										S.[icd_indicator] ,S.[icd_code1],
										S.[icd_code2], S.[icd_code3], S.[icd_code4] ,S.[icd_code5],
										S.[icd_code6],S.[icd_code7], S.[icd_code8] ,S.[icd_code9],
										S.[icd_code10],S.[icd_code11] ,S.[icd_code12] ,S.[icd_code13],
										S.[icd_code14] ,S.[icd_code15],S.[icd_code16],S.[icd_code17],
										S.[icd_code18] ,S.[icd_code19]);
					
	
					
				----------
				----------CLAIM_INSURANCE_DETAIL--
				
			;WITH claim_insurance_detail_staging as 
			(
  				SELECT claim_info_id,self_ins_indicator,self_ins_type,
				policy_holder_last_name,policy_holder_first_name,dba_name,
  				legal_name,policy_no  	
				from claim_staging S
				where 
				COALESCE(S.status,0)!=1  and --COALESCE(status,0)!=2	AND client_action_type not in ('DELETE','STOP') AND
				(COALESCE(S.[self_ins_indicator],'')!='' OR COALESCE(S.[self_ins_type],'')!='' OR
				COALESCE(S.[policy_holder_last_name],'')!='' OR COALESCE(S.[policy_holder_first_name],'')!='' OR
				COALESCE(S.[dba_name],'')!='' OR COALESCE(S.[legal_name],'')!='' OR
				COALESCE(S.[policy_no],'')!=''  OR 
				S.claim_info_id in (select claim_info_id from Insurance_Info))
				)


				MERGE  Insurance_Info AS T USING  claim_insurance_detail_staging AS S 
							ON (S.claim_info_id = T.claim_info_id) 
					WHEN Matched 
					THEN UPDATE  
								SET                   	
                  				T.[self_ins_indicator] = S.[self_ins_indicator] ,
								T.[self_ins_type] = S.[self_ins_type] ,
								T.[policy_holder_last_name]= S.[policy_holder_last_name]  ,
								T.[policy_holder_first_name]= S.[policy_holder_first_name]  ,
								T.[dba_name] = S.[dba_name] ,
								T.[legal_name] = S.[legal_name] ,
								T.[policy_no] = S.[policy_no] 
					WHEN Not Matched  --and S.[claim_info_id] is not null
					THEN INSERT ([claim_info_id],[self_ins_indicator],[self_ins_type],[policy_holder_last_name],
								[policy_holder_first_name],[dba_name] ,[legal_name] ,[policy_no])   
					VALUES (S.[claim_info_id],  S.[self_ins_indicator] ,S.[self_ins_type] ,S.[policy_holder_last_name]  ,
						S.[policy_holder_first_name]  , S.[dba_name] , S.[legal_name] ,S.[policy_no] );
					
		
				----------
				----------CLAIM_PRODUCT_DETAIL----
				
						
		;WITH claim_product_detail_staging as 
		(
  			SELECT claim_info_id,prd_liability_indicator,prd_name,
			prd_brand_name,prd_manufacturer,prd_alleged_harm	
			from claim_staging S
			where 
			COALESCE(S.status,0)!=1 and --COALESCE(status,0)!=2	 AND client_action_type not in ('DELETE','STOP') AND 
			(COALESCE(S.[prd_liability_indicator],'')!='' OR COALESCE(S.[prd_name],'')!='' OR
			COALESCE(S.[prd_brand_name],'')!='' OR COALESCE(S.[prd_manufacturer],'')!='' OR
			COALESCE(S.[prd_alleged_harm],'')!='' OR 
			S.claim_info_id in (select claim_info_id from Product_Info))
			)

			MERGE  Product_Info AS T USING  claim_product_detail_staging AS S 
						ON (S.claim_info_id = T.claim_info_id) 				
				WHEN Matched 
				THEN UPDATE  
							SET                   	
                  			T.[prd_liability_indicator] = S.[prd_liability_indicator] ,
							T.[prd_name] = S.[prd_name] ,
							T.[prd_brand_name]= S.[prd_brand_name]  ,
							T.[prd_manufacturer]= S.[prd_manufacturer]  ,
							T.[prd_alleged_harm] = S.[prd_alleged_harm]
				WHEN Not Matched     
				THEN INSERT ([claim_info_id],[prd_liability_indicator] ,[prd_name] ,
							[prd_brand_name],[prd_manufacturer],[prd_alleged_harm])   
				VALUES ( S.[claim_info_id], S.[prd_liability_indicator] ,S.[prd_name] ,
								S.[prd_brand_name]  ,S.[prd_manufacturer]  ,
							S.[prd_alleged_harm]);
					
				----------
				----------CLAIM_ADJUSTER_DETAIL---
				
		;WITH claim_adj_detail_staging as 
		(
  			SELECT claim_info_id,
			adj_first_name,adj_last_name,adj_phone,adj_phone_ext,
			adj_email
			from claim_staging S
			where 
			COALESCE(S.status,0)!=1  and --COALESCE(status,0)!=2	AND client_action_type not in ('DELETE','STOP') AND 
			--(COALESCE(S.[adj_code],'')!='' OR 
			COALESCE(S.[adj_last_name],'')!='' OR
			COALESCE(S.[adj_first_name],'')!='' OR COALESCE(S.[adj_phone],'')!='' OR
			COALESCE(S.[adj_phone_ext],'')!='' OR COALESCE(S.[adj_email],'')!='' OR
			--COALESCE(S.[adj_branch],'')!='' OR COALESCE(S.[adj_service_center],'')!='' OR 
			S.claim_info_id in (select claim_info_id from Adjuster_Info))
										  

				MERGE  Adjuster_Info AS T USING  claim_adj_detail_staging AS S 
						ON (S.claim_info_id = T.claim_info_id) 				
				WHEN Matched 
				THEN UPDATE  
							SET                   	
                  			--T.[adj_code] = S.[adj_code] ,
							T.[last_name] = S.[adj_last_name] ,
							T.[first_name]= S.[adj_first_name]  ,					
							T.[phone] = S.[adj_phone],
							T.[phone_ext] = S.[adj_phone_ext] ,
							T.[email]= S.[adj_email]  
				WHEN Not Matched     
				THEN INSERT ([claim_info_id],[last_name]  ,[first_name],[phone],
							[phone_ext] ,[email])  										 
				VALUES ( S.[claim_info_id], S.[adj_last_name] ,S.[adj_first_name]  
					,S.[adj_phone],S.[adj_phone_ext] ,S.[adj_email]  );
					
				----------
				----------CLAIM_CLAIMANT_DETAIL---
				
		;WITH claimant_infos as 
		(
		SELECT claim_info_id as detailid,claimant1_relation as relation,claimant1_tin as tin,claimant1_last_name as lname,
		claimant1_first_name as fname,claimant1_middle_initial as minit,claimant1_org_name as entorgname,claimant1_address1 as addr1,
		claimant1_address2 as addr2,claimant1_city as city,claimant1_state as state,claimant1_zip_code as zip,claimant1_zip_ext as zipExt,
		claimant1_phone as phone,claimant1_phone_ext as phoneext,claimant1_rep_indicator as repindicator,claimant1_rep_last_name as replname,
		claimant1_rep_first_name as repfname,claimant1_rep_firm_name as repfirmname,claimant1_rep_tin as reptin,claimant1_rep_address1 as repaddr1,
		claimant1_rep_address2 as repaddr2,claimant1_rep_city as repcity,claimant1_rep_state as repstate, claimant1_rep_zip_code as repzip,
		claimant1_rep_zip_ext as repzipext,claimant1_rep_phone as repphone,claimant1_rep_phone_ext as repphoneext,
		claimant1_seq_no as seqno from claim_staging where claimant1_seq_no = 1 AND claimant1_seq_no <> 0 
		AND Coalesce(status,0)!=1  --and COALESCE(status,0)!=2 and
		--client_action_type not in ('DELETE','STOP')  
		UNION ALL
      
		SELECT claim_info_id as detailid,claimant2_relation as relation,claimant2_tin as tin,claimant2_last_name as lname,
		claimant2_first_name as fname,claimant2_middle_initial as minit,claimant2_org_name as entorgname,claimant2_address1 as addr1,
		claimant2_address2 as addr2,claimant2_city as city,claimant2_state as state,claimant2_zip_code as zip,claimant2_zip_ext as zipExt,
		claimant2_phone as phone,claimant2_phone_ext as phoneext,claimant2_rep_indicator as repindicator,claimant2_rep_last_name as replname,
		claimant2_rep_first_name as repfname,claimant2_rep_firm_name as repfirmname,claimant2_rep_tin as reptin,claimant2_rep_address1 as repaddr1,
		claimant2_rep_address2 as repaddr2,claimant2_rep_city as repcity,claimant2_rep_state as repstate,claimant2_rep_zip_code as repzip,
		claimant2_rep_zip_ext as repzipext,claimant2_rep_phone as repphone,claimant2_rep_phone_ext as repphoneext,
		claimant2_seq_no as seqno from claim_staging where claimant2_seq_no = 2 AND claimant2_seq_no <> 0 
		AND Coalesce(status,0)!=1  --and COALESCE(status,0)!=2 and
		--client_action_type not in ('DELETE','STOP')     
		UNION ALL

		SELECT claim_info_id as detailid,claimant3_relation as relation,claimant3_tin as tin,claimant3_last_name as lname,
		claimant3_first_name as fname,claimant3_middle_initial as minit,claimant3_org_name as entorgname,claimant3_address1 as addr1,
		claimant3_address2 as addr2,claimant3_city as city,claimant3_state as state,claimant3_zip_code as zip,claimant3_zip_ext as zipExt,
		claimant3_phone as phone,claimant3_phone_ext as phoneext,claimant3_rep_indicator as repindicator,claimant3_rep_last_name as replname,
		claimant3_rep_first_name as repfname,claimant3_rep_firm_name as repfirmname,claimant3_rep_tin as reptin,claimant3_rep_address1 as repaddr1,
		claimant3_rep_address2 as repaddr2,claimant3_rep_city as repcity,claimant3_rep_state as repstate,claimant3_rep_zip_code as repzip,
		claimant3_rep_zip_ext as repzipext,claimant3_rep_phone as repphone,claimant3_rep_phone_ext as repphoneext,
		claimant3_seq_no as seqno from claim_staging where claimant3_seq_no = 3 AND claimant3_seq_no <> 0 
		AND Coalesce(status,0)!=1  --and COALESCE(status,0)!=2	and
		--client_action_type not in ('DELETE','STOP') 
		UNION ALL

		SELECT claim_info_id as detailid,claimant4_relation as relation,claimant4_tin as tin,claimant4_last_name as lname,
		claimant4_first_name as fname,claimant4_middle_initial as minit,claimant4_org_name as entorgname,claimant4_address1 as addr1,
		claimant4_address2 as addr2,claimant4_city as city,claimant4_state as state,claimant4_zip_code as zip,claimant4_zip_ext as zipext,
		claimant4_phone as phone,claimant4_phone_ext as phoneext,claimant4_rep_indicator as repindicator,claimant4_rep_last_name as replname,
		claimant4_rep_first_name as repfname,claimant4_rep_firm_name as repfirmname,claimant4_rep_tin as reptin,claimant4_rep_address1 as repaddr1,
		claimant4_rep_address2 as repaddr2,claimant4_rep_city as repcity,claimant4_rep_state as repstate,claimant4_rep_zip_code as repzip,
		claimant4_rep_zip_ext as repzipext,claimant4_rep_phone as repphone,claimant4_rep_phone_ext as repphoneext,
		claimant4_seq_no as seqno from claim_staging where claimant4_seq_no = 4 AND claimant4_seq_no <> 0  AND Coalesce(status,0)!=1 --and COALESCE(status,0)!=2	and
		--client_action_type not in ('DELETE','STOP')  
		)
 
		MERGE  Claimant_Info AS T USING  claimant_infos AS S 
			ON (S.detailid = T.claim_info_id and S.seqno= T.sequence) 
			WHEN Matched 
			THEN UPDATE  
						SET                   	
                  		T.[relation] = S.[relation] ,
						T.[tin] = S.[tin] ,
						T.[last_name]= S.[lname] ,					
						T.[first_name] = S.[fname],
						T.[middle_initial] = S.[minit] ,
						T.[entity_org_name]= S.[entorgname]  ,
						T.[address1]= S.[addr1]  ,
						T.[address2] = S.[addr2],
						T.[city] = S.[city] ,
						T.[state] = S.[state] ,
						T.[zip_code]= S.[zip]  ,					
						T.[zip_ext] = S.[zipext],
						T.[phone] = S.[phone] ,
						T.[phone_ext]= S.[phoneext]  ,
						T.[rep_indicator]= S.[repindicator]  ,
						T.[rep_last_name] = S.[replname],
						T.[rep_first_name] = S.[repfname] ,
						T.[rep_firm_name] = S.[repfirmname] ,
						T.[rep_tin]= S.[reptin]  ,					
						T.[rep_address1] = S.[repaddr1],
						T.[rep_address2] = S.[repaddr2],
						T.[rep_city] = S.[repcity] ,
						T.[rep_state] = S.[repstate] ,
						T.[rep_zip_code]= S.[repzip]  ,					
						T.[rep_zip_ext] = S.[repzipext],
						T.[rep_phone] = S.[repphone] ,
						T.[rep_phone_ext]= S.[repphoneext] ,
						T.[Sequence]= S.[seqno]
			WHEN Not Matched     
			THEN INSERT ([claim_info_id],[relation]  ,[tin]  ,[last_name],[first_name],[middle_initial] ,[entity_org_name],
						[address1],[address2],[city],[state]  ,[zip_code]  ,[zip_ext],[phone],[phone_ext],[rep_indicator] ,
						[rep_last_name],[rep_first_name],[rep_firm_name],[rep_tin],[rep_address1],[rep_address2],[rep_city] ,
						[rep_state],[rep_zip_code],[rep_zip_ext],[rep_phone],[rep_phone_ext],[Sequence]) 
					 		
			VALUES ( S.[detailid],S.[relation] ,S.[tin] ,S.[lname] ,S.[fname] ,S.[minit],S.[entorgname],S.[addr1],S.[addr2],
					S.[city] ,S.[state] ,S.[zip],S.[zipext],S.[phone],S.[phoneext], S.[repindicator],  
    			S.[replname], S.[repfname] ,S.[repfirmname] ,S.[reptin],S.[repaddr1],S.[repaddr2],S.[repcity],
				S.[repstate], S.[repzip], S.[repzipext], S.[repphone], S.[repphoneext], S.[seqno]);

	-----------------------------------claimant with no data------------------------------
		;WITH XClaimant_Info as
		(
		SELECT a.claim_info_id as infoid,a.claimant1_relation as relation,a.claimant1_tin as tin,claimant1_last_name as lname,
			claimant1_first_name as fname,claimant1_middle_initial as minit,claimant1_org_name as entorgname,claimant1_address1 as addr1,
			claimant1_address2 as addr2,claimant1_city as city,claimant1_state as state,claimant1_zip_code as zip,claimant1_zip_ext as zipExt,
			claimant1_phone as phone,claimant1_phone_ext as phoneext,claimant1_rep_indicator as repindicator,claimant1_rep_last_name as replname,
			claimant1_rep_first_name as repfname,claimant1_rep_firm_name as repfirmname,claimant1_rep_tin as reptin,claimant1_rep_address1 as repaddr1,
			claimant1_rep_address2 as repaddr2,claimant1_rep_city as repcity,claimant1_rep_state as repstate, claimant1_rep_zip_code as repzip,
			claimant1_rep_zip_ext as repzipext,claimant1_rep_phone as repphone,claimant1_rep_phone_ext as repphoneext,
			1 as seqno from claim_staging a join Claimant_Info b on a.claim_info_id=b.claim_Info_id and b.sequence =1
			where a.claimant1_seq_no = 0 AND Coalesce(a.status,0)!=1  --and COALESCE(a.status,0)!=2 and
			--a.client_action_type not in ('DELETE','STOP')    
			UNION ALL
      
			SELECT a.claim_info_id as infoid,claimant2_relation as relation,claimant2_tin as tin,claimant2_last_name as lname,
			claimant2_first_name as fname,claimant2_middle_initial as minit,claimant2_org_name as entorgname,claimant2_address1 as addr1,
			claimant2_address2 as addr2,claimant2_city as city,claimant2_state as state,claimant2_zip_code as zip,claimant2_zip_ext as zipExt,
			claimant2_phone as phone,claimant2_phone_ext as phoneext,claimant2_rep_indicator as repindicator,claimant2_rep_last_name as replname,
			claimant2_rep_first_name as repfname,claimant2_rep_firm_name as repfirmname,claimant2_rep_tin as reptin,claimant2_rep_address1 as repaddr1,
			claimant2_rep_address2 as repaddr2,claimant2_rep_city as repcity,claimant2_rep_state as repstate,claimant2_rep_zip_code as repzip,
			claimant2_rep_zip_ext as repzipext,claimant2_rep_phone as repphone,claimant2_rep_phone_ext as repphoneext,
			2 as seqno from claim_staging a join Claimant_Info b on a.claim_info_id=b.claim_Info_id and b.sequence =2
			where a.claimant2_seq_no = 0 AND Coalesce(status,0)!=1  --and COALESCE(a.status,0)!=2 and
		-- a.client_action_type not in ('DELETE','STOP')     
		UNION ALL

			SELECT a.claim_info_id as infoid,claimant3_relation as relation,claimant3_tin as tin,claimant3_last_name as lname,
			claimant3_first_name as fname,claimant3_middle_initial as minit,claimant3_org_name as entorgname,claimant3_address1 as addr1,
			claimant3_address2 as addr2,claimant3_city as city,claimant3_state as state,claimant3_zip_code as zip,claimant3_zip_ext as zipExt,
			claimant3_phone as phone,claimant3_phone_ext as phoneext,claimant3_rep_indicator as repindicator,claimant3_rep_last_name as replname,
			claimant3_rep_first_name as repfname,claimant3_rep_firm_name as repfirmname,claimant3_rep_tin as reptin,claimant3_rep_address1 as repaddr1,
			claimant3_rep_address2 as repaddr2,claimant3_rep_city as repcity,claimant3_rep_state as repstate,claimant3_rep_zip_code as repzip,
			claimant3_rep_zip_ext as repzipext,claimant3_rep_phone as repphone,claimant3_rep_phone_ext as repphoneext,
			3 as seqno from claim_staging a join Claimant_Info b on a.claim_info_id=b.claim_Info_id and b.sequence =3
			where a.claimant3_seq_no = 0 AND Coalesce(a.status,0)!=1  --and COALESCE(a.status,0)!=2	and
		-- a.client_action_type not in ('DELETE','STOP') 
		UNION ALL

			SELECT a.claim_info_id as infoid,claimant4_relation as relation,claimant4_tin as tin,claimant4_last_name as lname,
			claimant4_first_name as fname,claimant4_middle_initial as minit,claimant4_org_name as entorgname,claimant4_address1 as addr1,
			claimant4_address2 as addr2,claimant4_city as city,claimant4_state as state,claimant4_zip_code as zip,claimant4_zip_ext as zipext,
			claimant4_phone as phone,claimant4_phone_ext as phoneext,claimant4_rep_indicator as repindicator,claimant4_rep_last_name as replname,
			claimant4_rep_first_name as repfname,claimant4_rep_firm_name as repfirmname,claimant4_rep_tin as reptin,claimant4_rep_address1 as repaddr1,
			claimant4_rep_address2 as repaddr2,claimant4_rep_city as repcity,claimant4_rep_state as repstate,claimant4_rep_zip_code as repzip,
			claimant4_rep_zip_ext as repzipext,claimant4_rep_phone as repphone,claimant4_rep_phone_ext as repphoneext,
			4 as seqno from claim_staging a join Claimant_Info b on a.claim_info_id=b.claim_Info_id and b.sequence =4
			where a.claimant4_seq_no = 0 AND Coalesce(a.status,0)!=1 --and COALESCE(a.status,0)!=2	and
			--a.client_action_type not in ('DELETE','STOP')  

		)
		MERGE  Claimant_Info AS T USING  XClaimant_Info AS S 
				ON (S.infoid = T.claim_Info_id and S.seqno= T.sequence) 
				WHEN Matched 
				THEN UPDATE  
							SET                   	
                  			T.[relation] = S.[relation] ,
							T.[tin] = S.[tin] ,
							T.[last_name]= S.[lname] ,					
							T.[first_name] = S.[fname],
							T.[middle_initial] = S.[minit] ,
							T.[entity_org_name]= S.[entorgname]  ,
							T.[address1]= S.[addr1]  ,
							T.[address2] = S.[addr2],
							T.[city] = S.[city] ,
							T.[state] = S.[state] ,
							T.[zip_code]= S.[zip]  ,					
							T.[zip_ext] = S.[zipext],
							T.[phone] = S.[phone] ,
							T.[phone_ext]= S.[phoneext]  ,
							T.[rep_indicator]= S.[repindicator]  ,
							T.[rep_last_name] = S.[replname],
							T.[rep_first_name] = S.[repfname] ,
							T.[rep_firm_name] = S.[repfirmname] ,
							T.[rep_tin]= S.[reptin]  ,					
							T.[rep_address1] = S.[repaddr1],
							T.[rep_address2] = S.[repaddr2],
							T.[rep_city] = S.[repcity] ,
							T.[rep_state] = S.[repstate] ,
							T.[rep_zip_code]= S.[repzip]  ,					
							T.[rep_zip_ext] = S.[repzipext],
							T.[rep_phone] = S.[repphone] ,
							T.[rep_phone_ext]= S.[repphoneext] ,
							T.[Sequence]= S.[seqno];

					

				
			-----------TPOC Information table---------------------

			;WITH Claim_tpoc_info as 
			(
			SELECT claim_info_id as infoId,tpoc1_date as tpocdate,tpoc1_amount as tpocamount,
			tpoc1_fund_delayed_date as funddelayeddate,
			tpoc1_seq_no as seqno from claim_staging where tpoc1_seq_no = 1 AND Coalesce(status,0)!=1 --and COALESCE(status,0)!=2 and
			--client_action_type not in ('DELETE','STOP')	  
			UNION ALL      
			SELECT claim_info_id as infoId,tpoc2_date as tpocdate,tpoc2_amount as tpocamount,
			tpoc2_fund_delayed_date as funddelayeddate, 
			tpoc2_seq_no as seqno from claim_staging where tpoc2_seq_no = 2 AND Coalesce(status,0)!=1 --and COALESCE(status,0)!=2 and
			--client_action_type not in ('DELETE','STOP')	 
			UNION ALL
			SELECT claim_info_id as infoId,tpoc3_date as tpocdate,tpoc3_amount as tpocamount,
			tpoc3_fund_delayed_date as funddelayeddate, 
			tpoc3_seq_no as seqno from claim_staging where tpoc3_seq_no = 3 AND Coalesce(status,0)!=1 --and COALESCE(status,0)!=2	and
			--client_action_type not in ('DELETE','STOP') 
			UNION ALL
			SELECT claim_info_id as infoId,tpoc4_date as tpocdate,tpoc4_amount as tpocamount,
			tpoc4_fund_delayed_date as funddelayeddate,
			tpoc4_seq_no as seqno from claim_staging where tpoc4_seq_no = 4 AND Coalesce(status,0)!=1 --and COALESCE(status,0)!=2 and
			--client_action_type not in ('DELETE','STOP')	 
			UNION ALL
			SELECT claim_info_id as infoId,tpoc5_date as tpocdate,tpoc5_amount as tpocamount,
			tpoc5_fund_delayed_date as funddelayeddate,
			tpoc5_seq_no as seqno from claim_staging where tpoc5_seq_no = 5 AND Coalesce(status,0)!=1  --and COALESCE(status,0)!=2	 and
			--client_action_type not in ('DELETE','STOP')
			)
 
			MERGE  TPOC_info AS T USING  Claim_tpoc_info AS S 
						ON (S.infoId = T.claim_info_id and S.seqno= T.sequence) 
				WHEN Matched 
				THEN UPDATE  
							SET                   	
                  			T.[tpoc_date] = S.[tpocdate] ,
							T.[tpoc_amount] = S.[tpocamount] ,
							T.[fund_delayed_date]= S.[funddelayeddate] ,					
							T.[sequence] = S.[seqno]
										
				WHEN Not Matched     
				THEN INSERT ([claim_info_id],[tpoc_date]  ,[tpoc_amount]  ,[fund_delayed_date],
						[Sequence]) 					 		
				VALUES ( S.[infoId],S.[tpocdate] ,S.[tpocamount] ,S.[funddelayeddate],											
						S.[seqno]);


			-----------XTPOC Information table---------------------
				;with xtpoc_info as(
				SELECT a.claim_info_id as detailid,a.tpoc1_date as tpocdate,a.tpoc1_amount as tpocamount,
				a.tpoc1_fund_delayed_date as funddelayeddate,
				1 as seqno from claim_staging a join tpoc_info b on a.claim_info_id=b.claim_info_id and b.sequence=1
				where a.tpoc1_seq_no = 0 AND Coalesce(a.status,0)!=1 --and COALESCE(a.status,0)!=2 and
				--a.client_action_type not in ('DELETE','STOP')
				UNION ALL
				SELECT a.claim_info_id as detailid,a.tpoc2_date as tpocdate,a.tpoc2_amount as tpocamount,
				a.tpoc2_fund_delayed_date as funddelayeddate,
				2 as seqno from claim_staging a join tpoc_info b on a.claim_info_id=b.claim_info_id and b.sequence=2
				where a.tpoc2_seq_no = 0 AND Coalesce(a.status,0)!=1 --and COALESCE(a.status,0)!=2 and
				--a.client_action_type not in ('DELETE','STOP')
				UNION ALL
				SELECT a.claim_info_id as detailid,a.tpoc3_date as tpocdate,a.tpoc3_amount as tpocamount,
				a.tpoc3_fund_delayed_date as funddelayeddate,
				3 as seqno from claim_staging a join tpoc_info b on a.claim_info_id=b.claim_info_id and b.sequence=3
				where a.tpoc3_seq_no = 0 AND Coalesce(a.status,0)!=1 --and COALESCE(a.status,0)!=2  and
				--a.client_action_type not in ('DELETE','STOP')
				UNION ALL
				SELECT a.claim_info_id as detailid,a.tpoc4_date as tpocdate,a.tpoc4_amount as tpocamount,
				a.tpoc4_fund_delayed_date as funddelayeddate,
				4 as seqno from claim_staging a join tpoc_info b on a.claim_info_id=b.claim_info_id and b.sequence=4
				where a.tpoc4_seq_no = 0 AND Coalesce(a.status,0)!=1 --and COALESCE(a.status,0)!=2  and
				--a.client_action_type not in ('DELETE','STOP')
				UNION ALL
				SELECT a.claim_info_id as detailid,a.tpoc5_date as tpocdate,a.tpoc5_amount as tpocamount,
				a.tpoc5_fund_delayed_date as funddelayeddate,
				5 as seqno from claim_staging a join tpoc_info b on a.claim_info_id=b.claim_info_id and b.sequence=5
				where a.tpoc5_seq_no = 0 AND Coalesce(a.status,0)!=1 --and COALESCE(a.status,0)!=2  and
				--a.client_action_type not in ('DELETE','STOP')
				)
				MERGE  TPOC_Info AS T USING  xtpoc_info AS S 
								ON (S.detailid = T.claim_info_id and S.seqno= T.sequence) 
						WHEN Matched 
						THEN UPDATE  
									SET                   	
                  					T.[tpoc_date] = S.[tpocdate] ,
									T.[tpoc_amount] = S.[tpocamount] ,
									T.[fund_delayed_date]= S.[funddelayeddate] ,					
									T.[sequence] = S.[seqno]
										
						WHEN Not Matched     
						THEN INSERT ([claim_info_id],[tpoc_date]  ,[tpoc_amount]  ,[fund_delayed_date]
								,[Sequence]) 					 		
						VALUES ( S.[detailid],S.[tpocdate] ,S.[tpocamount] ,S.[funddelayeddate],						
						S.[seqno]);
					
			
					
COMMIT TRANSACTION masterTransaction
END TRY
BEGIN CATCH
	
	IF @@trancount > 0
	ROLLBACK TRANSACTION masterTransaction
	--PRINT @mssg
	SELECT top 1 @file_id=file_id from claim_staging WITH (NOLOCK) 
	SET @mssg='ERROR NUMBER: '+CAST(ERROR_NUMBER() AS VARCHAR(10))+char(13)+
								'ERROR LINE: '+CAST(ERROR_LINE() AS VARCHAR(10))+char(13)+
								--'TABLE NAME: '+@table_name+char(13)+
								'ERROR MESSAGE:'+ERROR_MESSAGE()
	INSERT INTO [dbo].[transaction_error_info](file_id,description,created_date) VALUES (@file_id,@mssg,getdate())

	 RAISERROR (@mssg, -- Message text.  
               16, -- Severity.  
               1 -- State.  
               );  
	--EXECUTE  [dbo].[Transaction_GetErrorInfo] @file_ID = @file_id,@errorMssg=@mssg; 
END CATCH




END











";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
