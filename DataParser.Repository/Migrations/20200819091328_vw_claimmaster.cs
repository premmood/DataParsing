using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class vw_claimmaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE VIEW [dbo].[vw_claimmaster]
 
AS
SELECT ci.id AS claim_info_id,ci.[file_id],CAST(ci.action_type AS VARCHAR(1)) + '-' + act_type.code_description AS action_type_desc, 
ci.rre_info_id,ri.reporting_period AS next_period, ri.name+'-'+ RTRIM(LTRIM(ri.id)) AS rre_name,ri.name AS RRENAME,ri.rre_status, 
--ci.ip_key,ci.incident_key,
ci.cms_doi,ci.industry_doi,
ci.orm_term_date AS orm_term_date,ci.venue_state,
ci.office_code,ci.claim_no,CASE WHEN ri.tpra_id IN (2,3,5,6,8,9)
	 THEN CAST(ci.id AS VARCHAR)  ELSE ''  END AS icn,
--Case when ci.rre_info_id in (select rre_info.id from rre_info inner join tpra_info on rre_info.tpra_id= tpra_info.id where tpra_info.active=1 and tpra_info.layout='uff') 
--	 then convert(varchar(30),ci.id)  else ''  end as icn,--ci.dcn,
status AS status_id,cstatus.code_description AS status,
ci.claim_status,ci.orm_indicator,ci.tin,ci.created_date AS claim_received_date,
 ci.updated_date AS claim_date,
ip.hicn AS ip_hicn, ip.ssn AS ip_ssn, ip.first_name AS ip_first_name,ip.middle_initial AS ip_middle_initial,ip.last_name AS ip_last_name ,
--ip.first_name + (case when isnull(ip.middle_initial,'')='' then  ' ' else ' '+ip.middle_initial +' ' end ) + ip.last_name as injured_party_name,
COALESCE(ip.last_name,'') +(CASE WHEN ISNULL(ip.first_name,'')='' THEN '' ELSE ', '+ip.first_name END) + (CASE WHEN ISNULL(ip.middle_initial,'')='' THEN  '' ELSE ', '+ip.middle_initial END ) AS injured_party_name,
gen.code_description AS ip_gender, ip.dob AS ip_dob,ip.dod AS ip_dod, ip.address1 AS ip_address1, 
ip.address2 AS ip_address2, ip.city AS ip_city,ip.state AS ip_state,ip.phone AS ip_phone, 
ip.phone_ext AS ip_phone_ext, ip.zip_code AS ip_zip_code, ip.zip_ext AS ip_zip_ext,
CASE WHEN COALESCE(ipr.firm_name ,'')!='' THEN ipr.firm_name 
	WHEN (COALESCE(ipr.firm_name,'')='' OR LTRIM(RTRIM(ipr.firm_name))='' ) AND 
			(COALESCE(ipr.last_name,'')!='' AND COALESCE(ipr.first_name,'')!='') AND ci.action_type= 'SUBMIT'
			THEN SUBSTRING(LTRIM(RTRIM(ipr.first_name)),1,20)+' '+SUBSTRING(LTRIM(RTRIM(ipr.last_name)),1,20)
	 WHEN (COALESCE(ipr.firm_name,'')='' OR LTRIM(RTRIM(ipr.firm_name))='' ) AND 
			(COALESCE(ipr.last_name,'')!='' AND COALESCE(ipr.first_name,'')='') AND action_type= 'SUBMIT'
			THEN LTRIM(RTRIM(ipr.last_name))
	 WHEN (COALESCE(ipr.firm_name,'')='' OR LTRIM(RTRIM(ipr.firm_name))='' ) AND 
			(COALESCE(ipr.last_name,'')='' AND COALESCE(ipr.first_name,'')!='') AND action_type= 'SUBMIT'
			THEN LTRIM(RTRIM(ipr.first_name))
			END
	 AS ip_rep_firm_name, 
(CASE WHEN ((COALESCE(ipr.firm_name,'')='' OR LTRIM(RTRIM(ipr.firm_name))='' ) AND COALESCE(ipr.first_name,'')!='') AND action_type= 'SUBMIT' THEN '' ELSE ipr.first_name END) AS ip_rep_first_name,
(CASE WHEN ((COALESCE(ipr.firm_name,'')='' OR LTRIM(RTRIM(ipr.firm_name))='' ) AND COALESCE(ipr.last_name,'')!='') AND action_type= 'SUBMIT' THEN '' ELSE ipr.last_name END) AS ip_rep_last_name,
ipr.last_name + ', ' + ipr.first_name AS injured_party_rep_name, ipr.address1 AS ip_rep_address1,
ipr.address2 AS ip_rep_address2, ipr.city AS ip_rep_city, ipr.state AS ip_rep_state,ipr.tin AS ip_rep_tin,
ipr.zip_code AS ip_rep_zip_code, ipr.zip_ext AS ip_rep_zip_ext, ipr.phone AS ip_rep_phone, 
ipr.phone_ext AS ip_rep_phone_ext,ipr.rep_indicator,
ISNULL(pln.plan_ins_type,'') AS ins_type,ins_status.code_description AS ins_type_desc , pln.contact_dept, pln.contact_first_name, pln.contact_last_name, pln.contact_phone, pln.contact_phone_ext,
pln.exhaust_date, no_fault_limit,pln.lost_time,
--adj., ISNULL(adj.branch,'') AS adj_branch, 
adj.first_name AS adj_first_name,adj.last_name AS adj_last_name, 
--(adj.branch + '-' +adj.last_name + ' ' +adj.first_name) as adjuster_name,adj.supervisor_name,adj.branch +'-' +adj.last_name+ ', ' +adj.first_name AS adjuster_name,
(ISNULL(adj.last_name,'') + ', ' +ISNULL(adj.first_name,'')) AS adjuster_full_name,
adj.phone AS adj_phone,adj.phone_ext AS adj_phone_ext,adj.email AS adj_email,
self_ins_indicator ,ins.self_ins_type ,ins.legal_name, ins.dba_name, ins.policy_holder_first_name, ins.policy_holder_last_name,ins.policy_no,
prod.prd_name, prod.prd_brand_name, prod.prd_manufacturer, prod.prd_liability_indicator, prod.prd_alleged_harm,

inj.icd_code2, inj.icd_code3, inj.icd_code4 ,inj.icd_code5, inj.icd_code6, inj.icd_code7, inj.icd_code8, inj.icd_code9,inj.icd_code10,inj.icd_code11,
inj.icd_code12,inj.icd_code13,inj.icd_code14,inj.icd_code15,inj.icd_code16,inj.icd_code17,inj.icd_code18,icd_code19,
coalesce(( select next_date_from from dbo.GetNextSubmissionDateTable(ri.reporting_period) ),'') as next_date_from 


FROM dbo.Claim_Info  AS ci WITH (NOLOCK)
LEFT JOIN dbo.Injuredparty_info AS ip WITH (NOLOCK) ON ip.claim_info_id=ci.id
LEFT JOIN dbo.Injuredparty_rep_Info AS ipr WITH (NOLOCK) ON ipr.claim_info_id=ci.id 
LEFT JOIN dbo.Plan_info AS pln WITH (NOLOCK) ON   pln.claim_info_id=ci.id
LEFT JOIN dbo.Adjuster_Info AS adj WITH (NOLOCK) ON adj.claim_info_id=ci.id
LEFT JOIN dbo.insurance_Info AS ins WITH (NOLOCK) ON ins.claim_info_id=ci.id
LEFT JOIN dbo.Product_info AS prod WITH (NOLOCK) ON prod.claim_info_id=ci.id
LEFT JOIN dbo.Injury_Info AS inj WITH (NOLOCK)	ON inj.claim_info_id=ci.id
--LEFT JOIN dbo.Claim_future_field AS cff WITH (NOLOCK) ON cff.claim_info_id=ci.id
LEFT JOIN (SELECT code_id, code_description FROM dbo.Company_code_value WITH (NOLOCK) WHERE code_type='Action-type')  AS act_type ON act_type.code_id=ci.action_type
LEFT JOIN (SELECT code_id, code_description FROM dbo.Company_code_value WITH (NOLOCK)  WHERE code_type='Gender')  AS gen ON gen.code_id=ip.gender
LEFT JOIN (SELECT code_id, code_description FROM dbo.Company_code_value WITH (NOLOCK) WHERE code_type='Claim-status')  AS cstatus ON cstatus.code_id=ci.status
LEFT JOIN (SELECT code_value, code_description FROM dbo.Company_code_value WITH (NOLOCK) WHERE code_type='Plan-Ins-Type') AS ins_status ON ins_status.code_value= pln.plan_ins_type
INNER JOIN dbo.Rre_info AS ri WITH (NOLOCK) ON ri.id=ci.rre_info_id

GO";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
