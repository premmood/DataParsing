using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class GetNextSubmissionDateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE function [dbo].[GetNextSubmissionDateTable] (
	 @reporting_period int 
) 

RETURNs  TABLE  as 

RETURN

	with cte as (

	select 

	Reporting_period,

	start_day,

	case when end_day=28 then 31 else end_day end as end_day,

	month_for_reporting_period,

	ROW_NUMBER()OVER(ORDER BY CAST(MONTH_FOR_REPORTING_PERIOD AS INT),CAST(START_DAY AS INT)) AS SEQUENCE

	from dbo.reporting_period_use where Reporting_period=@reporting_period ),

	ct as (



	select 

	reporting_period,

	start_day,

	case when end_day = 31 then 28 else end_day end as end_day,

	month_for_reporting_period,

	Case when SEQUENCE = 1 then year(DATEADD(yy,1,GETDATE())) else Year(Getdate()) end as [year],

	sequence

	from cte

	--where SEQUENCE = (

	--select (SEQUENCE % 48)+1 from cte

	--where min(month_for_reporting_period) > MONTH(@currentDate) and DAY(@currentDate) between start_day and end_day

	),

	c as (

	select *,

	cast(cast(year as varchar(4))+'/'+cast(month_for_reporting_period as varchar(2))+'/'+cast(start_day as varchar(2)) as date) as next_date_from , 
	cast(cast(year as varchar(4)) + '/' + cast(month_for_reporting_period as varchar(2))+'/'+ cast(end_day as varchar(2)) as date) as next_date_to 
	   

	from ct)



	select *,DATEADD(mm,-3,next_date_from) as submission_date from c 

	where next_date_from  = (select min(next_date_from ) from c where next_date_from  > getdate())
";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
