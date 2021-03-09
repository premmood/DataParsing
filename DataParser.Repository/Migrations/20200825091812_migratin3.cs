using Microsoft.EntityFrameworkCore.Migrations;

namespace DataParser.Repository.Migrations
{
    public partial class migratin3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adjuster_Info_Claim_Info_claim_info_id",
                table: "Adjuster_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Claim_Info_RRE_Info_rre_info_id",
                table: "Claim_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Claimant_Info_Claim_Info_claim_Info_id",
                table: "Claimant_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Injuredparty_Info_Claim_Info_claim_info_id",
                table: "Injuredparty_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Injuredparty_Rep_Info_Claim_Info_claim_info_id",
                table: "Injuredparty_Rep_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Injury_Info_Claim_Info_claim_info_id",
                table: "Injury_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Insurance_Info_Claim_Info_claim_info_id",
                table: "Insurance_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Plan_Info_Claim_Info_claim_info_id",
                table: "Plan_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Info_Claim_Info_claim_info_id",
                table: "Product_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_TIN_Info_RRE_Info_rre_info_id",
                table: "TIN_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_TPOC_Info_Claim_Info_claim_info_id",
                table: "TPOC_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_UDF_Info_Claim_Info_claim_info_id",
                table: "UDF_Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Validation_Staging",
                table: "Validation_Staging");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Validation_Lock",
                table: "Validation_Lock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UDF_Info",
                table: "UDF_Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction_Error_Info",
                table: "Transaction_Error_Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TPOC_Info",
                table: "TPOC_Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TIN_Info",
                table: "TIN_Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RRE_Info",
                table: "RRE_Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Response_File",
                table: "Response_File");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reporting_Period_Use",
                table: "Reporting_Period_Use");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product_Info",
                table: "Product_Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plan_Info",
                table: "Plan_Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Insurance_Info",
                table: "Insurance_Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Injury_Info",
                table: "Injury_Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Injuredparty_Rep_Info",
                table: "Injuredparty_Rep_Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Injuredparty_Info",
                table: "Injuredparty_Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_File_Info",
                table: "File_Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_File_Error",
                table: "File_Error");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Error_Code",
                table: "Error_Code");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company_Code_Value",
                table: "Company_Code_Value");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Claimant_Info",
                table: "Claimant_Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Claim_Info",
                table: "Claim_Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Claim_Error",
                table: "Claim_Error");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adjuster_Info",
                table: "Adjuster_Info");

            migrationBuilder.RenameTable(
                name: "Validation_Staging",
                newName: "ValidationStaging");

            migrationBuilder.RenameTable(
                name: "Validation_Lock",
                newName: "ValidationLock");

            migrationBuilder.RenameTable(
                name: "UDF_Info",
                newName: "UDFInfo");

            migrationBuilder.RenameTable(
                name: "Transaction_Error_Info",
                newName: "TransactionErrorInfo");

            migrationBuilder.RenameTable(
                name: "TPOC_Info",
                newName: "TPOCInfo");

            migrationBuilder.RenameTable(
                name: "TIN_Info",
                newName: "TINInfo");

            migrationBuilder.RenameTable(
                name: "RRE_Info",
                newName: "RREInfo");

            migrationBuilder.RenameTable(
                name: "Response_File",
                newName: "ResponseFile");

            migrationBuilder.RenameTable(
                name: "Reporting_Period_Use",
                newName: "ReportingPeriodUse");

            migrationBuilder.RenameTable(
                name: "Product_Info",
                newName: "ProductInfo");

            migrationBuilder.RenameTable(
                name: "Plan_Info",
                newName: "PlanInfo");

            migrationBuilder.RenameTable(
                name: "Insurance_Info",
                newName: "InsuranceInfo");

            migrationBuilder.RenameTable(
                name: "Injury_Info",
                newName: "InjuryInfo");

            migrationBuilder.RenameTable(
                name: "Injuredparty_Rep_Info",
                newName: "InjuredpartyRepInfo");

            migrationBuilder.RenameTable(
                name: "Injuredparty_Info",
                newName: "InjuredpartyInfo");

            migrationBuilder.RenameTable(
                name: "File_Info",
                newName: "FileInfo");

            migrationBuilder.RenameTable(
                name: "File_Error",
                newName: "FileError");

            migrationBuilder.RenameTable(
                name: "Error_Code",
                newName: "ErrorCode");

            migrationBuilder.RenameTable(
                name: "Company_Code_Value",
                newName: "CompanyCodeValue");

            migrationBuilder.RenameTable(
                name: "Claimant_Info",
                newName: "ClaimantInfo");

            migrationBuilder.RenameTable(
                name: "Claim_Info",
                newName: "ClaimInfo");

            migrationBuilder.RenameTable(
                name: "Claim_Error",
                newName: "ClaimError");

            migrationBuilder.RenameTable(
                name: "Adjuster_Info",
                newName: "AdjusterInfo");

            migrationBuilder.RenameIndex(
                name: "IX_UDF_Info_claim_info_id",
                table: "UDFInfo",
                newName: "IX_UDFInfo_claim_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_TPOC_Info_claim_info_id",
                table: "TPOCInfo",
                newName: "IX_TPOCInfo_claim_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_TIN_Info_rre_info_id",
                table: "TINInfo",
                newName: "IX_TINInfo_rre_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Info_claim_info_id",
                table: "ProductInfo",
                newName: "IX_ProductInfo_claim_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_Plan_Info_claim_info_id",
                table: "PlanInfo",
                newName: "IX_PlanInfo_claim_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_Insurance_Info_claim_info_id",
                table: "InsuranceInfo",
                newName: "IX_InsuranceInfo_claim_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_Injury_Info_claim_info_id",
                table: "InjuryInfo",
                newName: "IX_InjuryInfo_claim_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_Injuredparty_Rep_Info_claim_info_id",
                table: "InjuredpartyRepInfo",
                newName: "IX_InjuredpartyRepInfo_claim_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_Injuredparty_Info_claim_info_id",
                table: "InjuredpartyInfo",
                newName: "IX_InjuredpartyInfo_claim_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_Claimant_Info_claim_Info_id",
                table: "ClaimantInfo",
                newName: "IX_ClaimantInfo_claim_Info_id");

            migrationBuilder.RenameIndex(
                name: "IX_Claim_Info_rre_info_id",
                table: "ClaimInfo",
                newName: "IX_ClaimInfo_rre_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_Adjuster_Info_claim_info_id",
                table: "AdjusterInfo",
                newName: "IX_AdjusterInfo_claim_info_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValidationStaging",
                table: "ValidationStaging",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValidationLock",
                table: "ValidationLock",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UDFInfo",
                table: "UDFInfo",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionErrorInfo",
                table: "TransactionErrorInfo",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TPOCInfo",
                table: "TPOCInfo",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TINInfo",
                table: "TINInfo",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RREInfo",
                table: "RREInfo",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponseFile",
                table: "ResponseFile",
                column: "seq_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportingPeriodUse",
                table: "ReportingPeriodUse",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInfo",
                table: "ProductInfo",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanInfo",
                table: "PlanInfo",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsuranceInfo",
                table: "InsuranceInfo",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InjuryInfo",
                table: "InjuryInfo",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InjuredpartyRepInfo",
                table: "InjuredpartyRepInfo",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InjuredpartyInfo",
                table: "InjuredpartyInfo",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileInfo",
                table: "FileInfo",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileError",
                table: "FileError",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ErrorCode",
                table: "ErrorCode",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyCodeValue",
                table: "CompanyCodeValue",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClaimantInfo",
                table: "ClaimantInfo",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClaimInfo",
                table: "ClaimInfo",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClaimError",
                table: "ClaimError",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdjusterInfo",
                table: "AdjusterInfo",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdjusterInfo_ClaimInfo_claim_info_id",
                table: "AdjusterInfo",
                column: "claim_info_id",
                principalTable: "ClaimInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimantInfo_ClaimInfo_claim_Info_id",
                table: "ClaimantInfo",
                column: "claim_Info_id",
                principalTable: "ClaimInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimInfo_RREInfo_rre_info_id",
                table: "ClaimInfo",
                column: "rre_info_id",
                principalTable: "RREInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InjuredpartyInfo_ClaimInfo_claim_info_id",
                table: "InjuredpartyInfo",
                column: "claim_info_id",
                principalTable: "ClaimInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InjuredpartyRepInfo_ClaimInfo_claim_info_id",
                table: "InjuredpartyRepInfo",
                column: "claim_info_id",
                principalTable: "ClaimInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InjuryInfo_ClaimInfo_claim_info_id",
                table: "InjuryInfo",
                column: "claim_info_id",
                principalTable: "ClaimInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceInfo_ClaimInfo_claim_info_id",
                table: "InsuranceInfo",
                column: "claim_info_id",
                principalTable: "ClaimInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanInfo_ClaimInfo_claim_info_id",
                table: "PlanInfo",
                column: "claim_info_id",
                principalTable: "ClaimInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInfo_ClaimInfo_claim_info_id",
                table: "ProductInfo",
                column: "claim_info_id",
                principalTable: "ClaimInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TINInfo_RREInfo_rre_info_id",
                table: "TINInfo",
                column: "rre_info_id",
                principalTable: "RREInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TPOCInfo_ClaimInfo_claim_info_id",
                table: "TPOCInfo",
                column: "claim_info_id",
                principalTable: "ClaimInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UDFInfo_ClaimInfo_claim_info_id",
                table: "UDFInfo",
                column: "claim_info_id",
                principalTable: "ClaimInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdjusterInfo_ClaimInfo_claim_info_id",
                table: "AdjusterInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimantInfo_ClaimInfo_claim_Info_id",
                table: "ClaimantInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimInfo_RREInfo_rre_info_id",
                table: "ClaimInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_InjuredpartyInfo_ClaimInfo_claim_info_id",
                table: "InjuredpartyInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_InjuredpartyRepInfo_ClaimInfo_claim_info_id",
                table: "InjuredpartyRepInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_InjuryInfo_ClaimInfo_claim_info_id",
                table: "InjuryInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceInfo_ClaimInfo_claim_info_id",
                table: "InsuranceInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanInfo_ClaimInfo_claim_info_id",
                table: "PlanInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInfo_ClaimInfo_claim_info_id",
                table: "ProductInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_TINInfo_RREInfo_rre_info_id",
                table: "TINInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_TPOCInfo_ClaimInfo_claim_info_id",
                table: "TPOCInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_UDFInfo_ClaimInfo_claim_info_id",
                table: "UDFInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ValidationStaging",
                table: "ValidationStaging");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ValidationLock",
                table: "ValidationLock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UDFInfo",
                table: "UDFInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionErrorInfo",
                table: "TransactionErrorInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TPOCInfo",
                table: "TPOCInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TINInfo",
                table: "TINInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RREInfo",
                table: "RREInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponseFile",
                table: "ResponseFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportingPeriodUse",
                table: "ReportingPeriodUse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInfo",
                table: "ProductInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanInfo",
                table: "PlanInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsuranceInfo",
                table: "InsuranceInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InjuryInfo",
                table: "InjuryInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InjuredpartyRepInfo",
                table: "InjuredpartyRepInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InjuredpartyInfo",
                table: "InjuredpartyInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileInfo",
                table: "FileInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileError",
                table: "FileError");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ErrorCode",
                table: "ErrorCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyCodeValue",
                table: "CompanyCodeValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClaimInfo",
                table: "ClaimInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClaimError",
                table: "ClaimError");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClaimantInfo",
                table: "ClaimantInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdjusterInfo",
                table: "AdjusterInfo");

            migrationBuilder.RenameTable(
                name: "ValidationStaging",
                newName: "Validation_Staging");

            migrationBuilder.RenameTable(
                name: "ValidationLock",
                newName: "Validation_Lock");

            migrationBuilder.RenameTable(
                name: "UDFInfo",
                newName: "UDF_Info");

            migrationBuilder.RenameTable(
                name: "TransactionErrorInfo",
                newName: "Transaction_Error_Info");

            migrationBuilder.RenameTable(
                name: "TPOCInfo",
                newName: "TPOC_Info");

            migrationBuilder.RenameTable(
                name: "TINInfo",
                newName: "TIN_Info");

            migrationBuilder.RenameTable(
                name: "RREInfo",
                newName: "RRE_Info");

            migrationBuilder.RenameTable(
                name: "ResponseFile",
                newName: "Response_File");

            migrationBuilder.RenameTable(
                name: "ReportingPeriodUse",
                newName: "Reporting_Period_Use");

            migrationBuilder.RenameTable(
                name: "ProductInfo",
                newName: "Product_Info");

            migrationBuilder.RenameTable(
                name: "PlanInfo",
                newName: "Plan_Info");

            migrationBuilder.RenameTable(
                name: "InsuranceInfo",
                newName: "Insurance_Info");

            migrationBuilder.RenameTable(
                name: "InjuryInfo",
                newName: "Injury_Info");

            migrationBuilder.RenameTable(
                name: "InjuredpartyRepInfo",
                newName: "Injuredparty_Rep_Info");

            migrationBuilder.RenameTable(
                name: "InjuredpartyInfo",
                newName: "Injuredparty_Info");

            migrationBuilder.RenameTable(
                name: "FileInfo",
                newName: "File_Info");

            migrationBuilder.RenameTable(
                name: "FileError",
                newName: "File_Error");

            migrationBuilder.RenameTable(
                name: "ErrorCode",
                newName: "Error_Code");

            migrationBuilder.RenameTable(
                name: "CompanyCodeValue",
                newName: "Company_Code_Value");

            migrationBuilder.RenameTable(
                name: "ClaimInfo",
                newName: "Claim_Info");

            migrationBuilder.RenameTable(
                name: "ClaimError",
                newName: "Claim_Error");

            migrationBuilder.RenameTable(
                name: "ClaimantInfo",
                newName: "Claimant_Info");

            migrationBuilder.RenameTable(
                name: "AdjusterInfo",
                newName: "Adjuster_Info");

            migrationBuilder.RenameIndex(
                name: "IX_UDFInfo_claim_info_id",
                table: "UDF_Info",
                newName: "IX_UDF_Info_claim_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_TPOCInfo_claim_info_id",
                table: "TPOC_Info",
                newName: "IX_TPOC_Info_claim_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_TINInfo_rre_info_id",
                table: "TIN_Info",
                newName: "IX_TIN_Info_rre_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInfo_claim_info_id",
                table: "Product_Info",
                newName: "IX_Product_Info_claim_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_PlanInfo_claim_info_id",
                table: "Plan_Info",
                newName: "IX_Plan_Info_claim_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_InsuranceInfo_claim_info_id",
                table: "Insurance_Info",
                newName: "IX_Insurance_Info_claim_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_InjuryInfo_claim_info_id",
                table: "Injury_Info",
                newName: "IX_Injury_Info_claim_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_InjuredpartyRepInfo_claim_info_id",
                table: "Injuredparty_Rep_Info",
                newName: "IX_Injuredparty_Rep_Info_claim_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_InjuredpartyInfo_claim_info_id",
                table: "Injuredparty_Info",
                newName: "IX_Injuredparty_Info_claim_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_ClaimInfo_rre_info_id",
                table: "Claim_Info",
                newName: "IX_Claim_Info_rre_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_ClaimantInfo_claim_Info_id",
                table: "Claimant_Info",
                newName: "IX_Claimant_Info_claim_Info_id");

            migrationBuilder.RenameIndex(
                name: "IX_AdjusterInfo_claim_info_id",
                table: "Adjuster_Info",
                newName: "IX_Adjuster_Info_claim_info_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Validation_Staging",
                table: "Validation_Staging",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Validation_Lock",
                table: "Validation_Lock",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UDF_Info",
                table: "UDF_Info",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction_Error_Info",
                table: "Transaction_Error_Info",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TPOC_Info",
                table: "TPOC_Info",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TIN_Info",
                table: "TIN_Info",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RRE_Info",
                table: "RRE_Info",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Response_File",
                table: "Response_File",
                column: "seq_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reporting_Period_Use",
                table: "Reporting_Period_Use",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product_Info",
                table: "Product_Info",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plan_Info",
                table: "Plan_Info",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Insurance_Info",
                table: "Insurance_Info",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Injury_Info",
                table: "Injury_Info",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Injuredparty_Rep_Info",
                table: "Injuredparty_Rep_Info",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Injuredparty_Info",
                table: "Injuredparty_Info",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_File_Info",
                table: "File_Info",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_File_Error",
                table: "File_Error",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Error_Code",
                table: "Error_Code",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company_Code_Value",
                table: "Company_Code_Value",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Claim_Info",
                table: "Claim_Info",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Claim_Error",
                table: "Claim_Error",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Claimant_Info",
                table: "Claimant_Info",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adjuster_Info",
                table: "Adjuster_Info",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adjuster_Info_Claim_Info_claim_info_id",
                table: "Adjuster_Info",
                column: "claim_info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Claim_Info_RRE_Info_rre_info_id",
                table: "Claim_Info",
                column: "rre_info_id",
                principalTable: "RRE_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Claimant_Info_Claim_Info_claim_Info_id",
                table: "Claimant_Info",
                column: "claim_Info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Injuredparty_Info_Claim_Info_claim_info_id",
                table: "Injuredparty_Info",
                column: "claim_info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Injuredparty_Rep_Info_Claim_Info_claim_info_id",
                table: "Injuredparty_Rep_Info",
                column: "claim_info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Injury_Info_Claim_Info_claim_info_id",
                table: "Injury_Info",
                column: "claim_info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Insurance_Info_Claim_Info_claim_info_id",
                table: "Insurance_Info",
                column: "claim_info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_Info_Claim_Info_claim_info_id",
                table: "Plan_Info",
                column: "claim_info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Info_Claim_Info_claim_info_id",
                table: "Product_Info",
                column: "claim_info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TIN_Info_RRE_Info_rre_info_id",
                table: "TIN_Info",
                column: "rre_info_id",
                principalTable: "RRE_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TPOC_Info_Claim_Info_claim_info_id",
                table: "TPOC_Info",
                column: "claim_info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UDF_Info_Claim_Info_claim_info_id",
                table: "UDF_Info",
                column: "claim_info_id",
                principalTable: "Claim_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
