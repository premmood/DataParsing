using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE proc test 
(@fileid int)
as
begin
create table #temp
(seq_id int not null, claim_control_num nvarchar(50),error_code char(10) null,field_name varchar(50) null,  account_id int null, rre_info_id char(9) null)
insert into #temp
values(  1, '209ABC445U','','', 12942, '20201'),(  2, '2ZZZZZC445U','','', 10042, '20299'),(  3, '20tttt45U','','', 17842, '30301'),(  2, '2eeeeee5U','','', 10042, '28009')

select * from #temp

end";

            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
