using DataParser.Repository;
using DataParser.Repository.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Spiralogics.CSVParser;
using Spiralogics.Logger;
using Spiralogics.XMLParser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace DataParser
{
    public class ReadClaim
    {
        private int lineNumberCounter = 0;
        private SettingConfig settingConfig;
        public event CustomEventHandler ParseHook;
        private readonly Dictionary<string, string> keyvalueError = new Dictionary<string, string>();
        private static Dictionary<string, List<string>> AccountRREsFromClient = new Dictionary<string, List<string>>();
        private static Dictionary<string, List<string>> RREFile = new Dictionary<string, List<string>>();
        private string logPath = string.Empty;
        private string filePath = string.Empty;
        private string responsePath = string.Empty;
        private string archivedPath = string.Empty;
        private string outgoingPath = string.Empty;
        private string clientHomePath = string.Empty;
        private string directoryPath = string.Empty;
        private int fileId = 0;
        private string rreid = string.Empty;
        private int accountid = 0;
        private string referenceValue = string.Empty;
        private string fileName = string.Empty;
        private DateTime fileReceived;
        private string mapperPath = string.Empty;
        private string csvmapperpath = string.Empty;
        private string tincsvmapperpath = string.Empty;
        private string xmlmapperPath = string.Empty;
        private string tinxmlmapperPath = string.Empty;
        private string xmlschemaPath = string.Empty;
        private string tinxmlschemaPath = string.Empty;
        private string inputtype = string.Empty;
        private DataTable dt;
        private bool IsParseSuccess = true;
        private bool IsClaimInput = true;
        private int totalSavingCount = 0;
        private int totalStagingCount = 0;
        private file_info file_;
        private claim_staging claim_Staging;
        private tin_staging tin_Staging;
        private string exceptionmessage = string.Empty;
        private string createdBy = String.Empty;
        private List<ValidationResult> ValMessages;
        private List<response_file> response_Files = new List<response_file>();
        private List<string> invalidFileNameList = new List<string>();
        private bool hasResponse = false;

        public void ReadClaimInputFiles(SettingConfig settingconfig)
        {
            settingConfig = settingconfig;
            directoryPath = settingConfig.InternalProcessingPath + "\\Processed";
            outgoingPath = settingConfig.InternalProcessingPath + "\\ResponseStaging";
            archivedPath = settingConfig.InternalProcessingPath + "\\Archived";
            clientHomePath = settingConfig.ClientHomePath;
            logPath = settingConfig.ValidationLogFilename;
            csvmapperpath = settingConfig.CSVMapperFilepath;
            tincsvmapperpath = settingconfig.TINCSVMapperFilepath;
            tinxmlmapperPath = settingconfig.TINXMLMapperFilepath;
            xmlmapperPath = settingConfig.XMLMapperFilepath;
            xmlschemaPath = settingconfig.XMLSchemaFilepath;
            tinxmlschemaPath = settingconfig.TINXMLSchemaFilepath;
            GetAccountRREs();
            if (DirectoryOK())
            {
                createdBy = settingconfig.CreatedBy;
                char env = settingConfig.Environment.ToLower().First();
                DirectoryInfo d = new DirectoryInfo(directoryPath);
                FileInfo[] Files = d.GetFiles().Where(f => (f.Extension == ".csv" || f.Extension == ".xml") && (f.Name.Split('.').Length == 7)).ToArray();
                if (Files.Count() == 0)
                { LogWrapper.Information("No file present with .csv or .xml file extention. File parsing aborted.");
                    SendEmailMessage(MessageTypes.NotificationOfAllParsingCompleted);
                }
                else
                {
                    Files = Files.Where(f => env == Convert.ToChar(f.Name.ToLower().Split('.')[1])).ToArray();
                    if (Files.Count() == 0)
                    { LogWrapper.Information($"No file present for parsing in {settingConfig.Environment} environment. File parsing aborted."); }
                    else
                    {
                        foreach (FileInfo file in Files)
                        {
                            fileName = file.Name;
                            settingConfig.Filename = fileName;
                            filePath = file.FullName;
                            inputtype = "";
                            if (FileOK())
                            {
                                if (inputtype == InputType.Claim.ToString())
                                    this.ReadClaimInputFileDetailRecord<ClaimInput, claim_staging>();
                                else if (inputtype == InputType.Tin.ToString())
                                    this.ReadClaimInputFileDetailRecord<TinInput, tin_staging>();
                            }
                        }
                        MoveFileToArchieveOutFolder();
                    }
                }
            }
         
        }
        public void ReadClaimInputFileDetailRecord<DomainClass, DbEntityClass>()
        {
            dt = new DataTable();
            IsParseSuccess = true;
            IsClaimInput = typeof(DbEntityClass).Equals(typeof(claim_staging));
            if (IsClaimInput)
                claim_Staging = new claim_staging();
            else
                tin_Staging = new tin_staging();
            LogWrapper.Information($"****************Parsing started-{fileName}****************");
            PropertyInfo[] basepropertyInfos = typeof(DbEntityClass).BaseType.GetProperties();
            PropertyInfo[] propertyInfos = typeof(DbEntityClass).GetProperties();
            //for each property add a column to datatable 
            foreach (PropertyInfo propertyInfo in basepropertyInfos)
            {
                if (propertyInfo.Name.ToLower() == "created_by")
                { dt.Columns.Add(new DataColumn(propertyInfo.Name, typeof(Guid))); }
                else
                    dt.Columns.Add(new DataColumn(propertyInfo.Name));
            }
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {   //for tin_staging
                if (!IsClaimInput && propertyInfo.Name.ToLower() == "created_by" || propertyInfo.Name.ToLower() == "updated_by")
                { dt.Columns.Add(new DataColumn(propertyInfo.Name, typeof(Guid))); }


                else if (!dt.Columns.Contains(propertyInfo.Name))
                {
                    dt.Columns.Add(new DataColumn(propertyInfo.Name));
                }
            }

            try
            {
                List<string> parselist = new List<string>();

                {   //CALLING CSVParser COMPONENT
                    if (Path.GetExtension(filePath).ToLower() == ".csv")
                    {
                        mapperPath = IsClaimInput ? csvmapperpath : tincsvmapperpath;
                        settingConfig.MapperType = "csv";
                        Parser p = new Parser(filePath, mapperPath);
                        parselist = p.ParseFile();
                    }
                    else if (Path.GetExtension(filePath).ToLower() == ".xml")
                    {
                        mapperPath = xmlmapperPath;
                        settingConfig.MapperType = "xml";
                        XMLParser p = new XMLParser(filePath, IsClaimInput ? xmlmapperPath : tinxmlmapperPath, IsClaimInput ? xmlschemaPath : tinxmlschemaPath);
                        parselist = p.ParseFile();
                    }
                    totalSavingCount = parselist.Count();
                    SaveFileInfo();
                    TruncateTable();
                    response_Files.Clear();
                    foreach (var serialized in parselist)
                    {
                        keyvalueError.Clear();
                        response_Files.Clear();
                        lineNumberCounter++;
                        try
                        {
                            bool IsValid = false;

                            ValMessages = new List<ValidationResult>();
                            Dictionary<object, object> dMapperType = new Dictionary<object, object>() { };
                            dMapperType.Add("MapperType", settingConfig.MapperType);
                            DomainClass domainClass = JsonConvert.DeserializeObject<DomainClass>(serialized);

                            if (IsClaimInput)
                            {
                                claim_Staging.file_id = fileId;
                                dMapperType.Add("ClaimObj", claim_Staging);
                            }
                            else
                            {
                                tin_Staging.file_id = fileId;
                                dMapperType.Add("TinObj", tin_Staging);
                            }

                            var context = new ValidationContext(domainClass, null, dMapperType);
                            IsValid = Validator.TryValidateObject(domainClass, context, ValMessages, true);

                            if (IsClaimInput)
                            {
                                ErrorCode InputErrorCode = SetRecordLevelError(claim_Staging, IsValid);
                                claim_Staging.created_date = DateTime.Now;
                                claim_Staging.created_by = createdBy == "" ? null : (Guid?)new Guid(createdBy);
                                if (InputErrorCode == ErrorCode.None)
                                {
                                    AddRowToDataTable<claim_staging>(claim_Staging);
                                }
                                else
                                {
                                    List<response_file> lstRespFile = new List<response_file>();
                                    foreach (var message in ValMessages[0].MemberNames)
                                    {
                                        var keyString = message.ToString().Substring(0, message.ToString().IndexOf(":"));
                                        response_file RespFile = new response_file { account_id = claim_Staging.account_id, claim_control_num = claim_Staging.claim_control_num, error_code = InputErrorCode.ToString(), field_name = keyString, rre_id = claim_Staging.rre_info_id, seq_id = Convert.ToInt32(claim_Staging.seq_id) };
                                        rreid = RespFile.rre_id;
                                        if(RespFile.field_name!="")
                                        lstRespFile.Add(RespFile);
                                    }
                                    response_Files.AddRange(lstRespFile);
                                }
                                referenceValue = claim_Staging.claim_control_num.ToString();
                            }
                            else
                            {
                                ErrorCode InputErrorCode = SetRecordLevelError(tin_Staging, IsValid);
                                tin_Staging.created_date = DateTime.Now;
                                tin_Staging.created_by = createdBy == "" ? null : (Guid?)new Guid(createdBy);
                                referenceValue = tin_Staging.tin;
                                if (InputErrorCode == ErrorCode.None)
                                    AddRowToDataTable<tin_staging>(tin_Staging);

                                else
                                {
                                    List<response_file> lstRespFile = new List<response_file>();
                                    foreach (var message in ValMessages[0].MemberNames)
                                    {
                                        var keyString = message.ToString().Substring(0, message.ToString().IndexOf(":"));
                                        response_file RespFile = new response_file { rectype = "", seq_id = Convert.ToInt32(tin_Staging.seq_id), error_code = InputErrorCode.ToString(), field_name = keyString, description = "", tin = tin_Staging.tin };
                                        if(RespFile.field_name!="")
                                        lstRespFile.Add(RespFile);
                                    }
                                    response_Files.AddRange(lstRespFile);

                                }


                            }

                            if (!IsValid)
                            {   //generate the error message  
                                keyvalueError.Add("File_Name",fileName);
                                keyvalueError.Add("Line_Number", lineNumberCounter.ToString());
                                foreach (var message in ValMessages[0].MemberNames)
                                {
                                    var keyString = message.ToString().Substring(0, message.ToString().IndexOf(":"));
                                    var valueString = message.ToString().Substring(message.ToString().IndexOf(":") + 1);
                                    keyvalueError.Add(keyString, valueString);
                                }

                                LogWrapper.Information($"Logging parsing error message for {(IsClaimInput ? "claim control number" : "tin")}: {referenceValue}");
                                //CALLING LOGGER COMPONENT
                                LogValidationError.LogError(
                                   keyvalueError.ToDictionary(p => p.Key, p => fileName+"-"+ p.Value.Split('|')[0])
                                   , logPath);
                                LogWrapper.Information("Check parsing error log file for detail error message.");
                                //INDIVIDUAL ROW-PARSING-VALIDATION MESSAGE HANDLING
                                //SendEmailMessage(MessageTypes.ValidationErrorOfIndividualRowParsing);
                            }
                        }
                        catch (Exception ex)
                        {
                            //INDIVIDUAL ROW-PARSE APPLICATION-EXCEPTION  HANDLING
                            throw new Exception($"Current Parsing Line number: {lineNumberCounter}  " + ex.Message);
                        }
                        if (response_Files.Count > 0)
                        {//format error response 
                            hasResponse = true;
                            SaveResponseFile(response_Files);
                            SaveErrorFile(response_Files);
                        }
                    }
                    ClaimBulkSaving(IsClaimInput ? "ClaimStaging" : "TinStaging");
                    if (totalStagingCount > 0)
                    {
                        CallProcs();
                        if (response_Files.Count > 0)
                        {//validation error response generated by proc
                            hasResponse = true;
                            SaveResponseFile(response_Files);
                            SaveErrorFile(response_Files);
                        }
                        IsParseSuccess = true;
                    }
                    else
                    {
                        IsParseSuccess = false;
                        updateFileInfo();
                    }
                    CopyResponseToClientFolder();
                }

            }
            catch (Exception ex)
            {
                IsParseSuccess = false;
                //OVERALL APPLICATION-EXCEPTION  HANDLING
                //log the application exception
                LogWrapper.Error(ex.Message, "Error message :");
                //mail the application exception
                SendEmailMessage(MessageTypes.ErrorOfApplicationLevel);
            }

            SendEmailMessage(MessageTypes.NotificationOfAllParsingCompleted);
            LogWrapper.Information($"****************Parsing completed - {(IsParseSuccess ? $"successfully  for {fileName}" : $"unsuccessfully for {fileName}") } {((hasResponse) ? $", Response file is at {responsePath.Replace(".xml", "").Replace(".csv", "")}" : "")}  ****************{System.Environment.NewLine + System.Environment.NewLine}");
            hasResponse = false;
        }
        private ErrorCode SetRecordLevelError<T>(T InputStaging, bool IsValid)
        {
            ErrorCode InputErrorCode = ErrorCode.None;
            if (IsClaimInput && !IsValid)
            {
                InputErrorCode = ErrorCode.FrmtErr;
            }

            //ErrorCode for TinInput
            else if (!IsValid) { InputErrorCode = ErrorCode.FrmtErr; }

            if (InputErrorCode != ErrorCode.None)
            {
                if (IsClaimInput)
                    LogWrapper.Information($"Input with claim control number: {InputStaging.GetType().GetProperty("claim_control_num").GetValue(InputStaging).ToString()} is set with error code :{InputErrorCode.ToString()}");
                else
                    LogWrapper.Information($"Input with tin: {InputStaging.GetType().GetProperty("tin").GetValue(InputStaging).ToString()} is set with error code :{InputErrorCode.ToString()}");

            }


            return InputErrorCode;
        }
        private void CallProcs()
        {
            keyvalueError.Clear();
            response_Files.Clear();
            if (IsClaimInput)
            {
                LogWrapper.Information("Calling usp_RunValidationOnClaimStaging stored procedure");
                claim_Staging.CallRunValidationOnClaimStagingProcs(fileId);
                LogWrapper.Information("Calling usp_MergeCascadingTables stored procedure");
                claim_Staging.CallMergeCascadingTablesProcs();
                LogWrapper.Information("Calling usp_RunValidationOnClaimFile stored procedure");
                claim_Staging.CallRunValidationOnClaimFileProcs(fileId);
                LogWrapper.Information("Calling usp_SetStatusOnClaimFile stored procedure");
                claim_Staging.CallSetStatusOnClaimFileProcs(fileId);
                LogWrapper.Information("Calling usp_GetResponseForFile stored procedure");
                response_Files.AddRange(claim_Staging.CallGetResponseForFileProcs(fileId));
            }
            else
            {
                //For tin there is no ValidationOnTinStaging proc
                //tinStaging.CallRunValidationOnTinStagingProcs(tin, office_code);
                LogWrapper.Information("Calling usp_MergeTINCascadingTables stored procedure");
                tin_Staging.CallMergeTINCascadingTablesProcs();
                LogWrapper.Information("Calling usp_RunValidationOnTINFile stored procedure");
                tin_Staging.CallRunValidationOnTINFileProcs(fileId);
                LogWrapper.Information("Calling GetTINResponse stored procedure");
                response_Files.AddRange(tin_Staging.CallGetTINResponseProcs(fileId));
            }

            updateFileInfo();
        }
        private void AddRowToDataTable<T>(T InputStaging)
        {
            DataRow row = dt.NewRow();
            List<object> objArr = new List<object>();
            foreach (PropertyInfo propertyInfo in InputStaging.GetType().BaseType.GetProperties())
            {
                string fieldName = propertyInfo.Name;
                object fieldValue = InputStaging.GetType().BaseType.GetProperty(fieldName).GetValue(InputStaging);
                if (IsClaimInput)
                {
                    if (Enum.IsDefined(typeof(SequenceNumber), fieldName))
                    {
                        if (fieldValue != null && fieldValue.ToString() != "")
                            InputStaging.GetType().GetProperty(fieldName.Split('_')[0] + "_seq_no").SetValue(InputStaging, Convert.ToInt32((fieldName.Split('_')[0].Last()).ToString()));
                    }
                }
                objArr.Add(fieldValue);

                if (propertyInfo.Name.ToLower() == "rre_info_id")
                { rreid = (string)fieldValue; }

                if (propertyInfo.Name.ToLower() == "account_id")
                { accountid = (int)fieldValue; }
            }

            foreach (PropertyInfo property in InputStaging.GetType().GetProperties())
            {
                if (property.DeclaringType == InputStaging.GetType())
                {
                    string fieldName = property.Name;
                    object fieldValue = InputStaging.GetType().GetProperty(fieldName).GetValue(InputStaging);

                    objArr.Add(fieldValue);
                }
            }

            row.ItemArray = objArr.ToArray();
            dt.Rows.Add(row);
        }
        private void ClaimBulkSaving(string tableName)
        {

            totalStagingCount = dt.Rows.Count;          
            if (totalStagingCount > 0)
            {
                LogWrapper.Information("Bulk saving started.");
                try
                {
                    using (SqlConnection cn = new SqlConnection(settingConfig.ConnectionString))
                    {
                        cn.Open();
                        using (SqlBulkCopy copy = new SqlBulkCopy(cn))
                        {
                            for (var i = 1; i <= dt.Columns.Count - 1; i++)
                            {
                                copy.ColumnMappings.Add(i, i);
                            }
                            copy.DestinationTableName = tableName;
                            copy.WriteToServer(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception occured while bulk saving " + ex.Message);
                }
                LogWrapper.Information($" {totalStagingCount} {(IsClaimInput ? " claim inputs" : " tin inputs")} out of {totalSavingCount} {(IsClaimInput ? " claim inputs" : " tin inputs")} are saved to {(IsClaimInput ? " Claim Staging" : " Tin Staging")} table.");
                LogWrapper.Information("Bulk saving completed.");
            }
            else
            {
                LogWrapper.Information($" No {(IsClaimInput ? " claim inputs" : " tin inputs")} out of {totalSavingCount} {(IsClaimInput ? " claim inputs" : " tin inputs")} are saved to {(IsClaimInput ? " Claim Staging" : " Tin Staging")} table.");
            }

        }
        private void SaveFileInfo()
        {
            LogWrapper.Information("Saving FileInfo started.");
            try
            {
                file_ = new file_info
                {
                    rre_id = null,
                    file_name = fileName,
                    file_type = Path.GetExtension(filePath).Replace(".", "").ToUpper(),
                    transaction_date = DateTime.Today,
                    rec_count = totalSavingCount,
                    claim_count = null,
                    file_status = null,
                    env = settingConfig.Environment.Substring(0, 4).ToLower(),
                    start_date = DateTime.Now,
                    end_date = null,
                    received_date = fileReceived
                };
                fileId = Convert.ToInt32(file_.Create());
                lineNumberCounter = 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while savinge FileInfo: " + ex.Message);
            }
            LogWrapper.Information("Saving FileInfo completed.");
        }
        private void updateFileInfo()
        {
            LogWrapper.Information("Updating FileInfo started.");
            try
            {
                string rreid = string.Empty;
                int distinctClaimCounts = 0;

                if (dt.Rows.Count > 0)
                {
                    if (IsClaimInput)
                    {
                        rreid = dt.AsEnumerable().Select(s => new { rre = s.Field<string>("rre_info_id") }).Distinct().Count() > 1 ? null : dt.AsEnumerable().Select(s => new { rre = s.Field<string>("rre_info_id") }).First().rre.ToString();
                        distinctClaimCounts = dt.AsEnumerable().Select(s => new { claimCount = s.Field<string>("claim_control_num") }).Distinct().Count();
                    }
                    else
                    {//for tin no rreid and claimcount info required   
                    }
                }
                else
                { LogWrapper.Information("No input row was added to the staging table."); }
                file_.claim_count = distinctClaimCounts;
                file_.rre_id = rreid;
                file_.end_date = DateTime.Now;
                file_.UpdateFileInfo();
                lineNumberCounter = 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while updating FileInfo: " + ex.Message);
            }
            LogWrapper.Information($"Updating FileInfo completed.{System.Environment.NewLine}");
        }
        private void TruncateTable()
        {
            LogWrapper.Information($"Truncating {(IsClaimInput ? "ClaimStaging" : "TinStaging")} started.");
            try
            {
                if (IsClaimInput)
                {
                    claim_Staging.Truncate();
                }
                else
                {
                    tin_Staging.Truncate();
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Exception while truncating ClaimStaging table: " + ex.Message);
            }
            LogWrapper.Information($"Truncating {(IsClaimInput ? "ClaimStaging" : "TinStaging")}  completed.");
        }
        private void SaveResponseFile(List<response_file> responseList)
        {
            responsePath = outgoingPath + "\\" + fileName;
            if (IsClaimInput)
            {
                responsePath = responsePath.Replace("CLAIM", "CLAIMRESPONSE");
                string claimResponsepath = string.Empty;
                if (settingConfig.MapperType == "csv")
                {
                    var groupBYRRE = responseList.GroupBy(s => s.rre_id.Trim());
                    bool rename = false;
                    foreach (var RRE in groupBYRRE)
                    {
                        if (!rename)
                        {
                            claimResponsepath = responsePath;
                            rename = true;
                        }
                        if (!File.Exists(claimResponsepath))
                        {

                            using (StreamWriter writer = File.CreateText(claimResponsepath))
                            {
                                WriteResponse(RRE, writer);
                                writer.Flush();
                                rename = false;
                            }
                        }
                        else
                        {
                            using (StreamWriter writer = File.AppendText(claimResponsepath))
                            {
                                WriteResponse(RRE, writer);
                                writer.Flush();
                                rename = false;
                            }
                        }
                    }
                }
                else if (settingConfig.MapperType == "xml")
                {
                    var groupBYRRE = responseList.GroupBy(s => s.rre_id.Trim());
                    foreach (var RRE in groupBYRRE)
                    {
                        SCHIPClaimResponseClaim[] claimArray = new SCHIPClaimResponseClaim[RRE.Count()];
                        claimResponsepath = responsePath;
                        int counter = 0;
                        foreach (response_file response in RRE)
                        {
                            SCHIPClaimResponseClaimError[] claimErrors = new SCHIPClaimResponseClaimError[] { new SCHIPClaimResponseClaimError { ErrorCode = response.error_code.Trim(), FieldName = response.field_name.Trim() } };
                            SCHIPClaimResponseClaim responseClaim = new SCHIPClaimResponseClaim { Account_Id = Convert.ToString(response.account_id).Trim(), Claim_Control_Number = response.claim_control_num.Trim(), RREID = response.rre_id.Trim(), Sequence_Id = Convert.ToString(response.seq_id).Trim(), Error = claimErrors };
                            claimArray[counter++] = responseClaim;

                            var ResponseData = new SCHIPClaimResponse { Claim = claimArray };
                            var serializer = new XmlSerializer(typeof(SCHIPClaimResponse));
                            using (var stream = new StreamWriter(claimResponsepath))
                                serializer.Serialize(stream, ResponseData);
                        }
                    }
                }
            }
            else
            {
                responsePath = responsePath.Replace("TIN", "TINRESPONSE");
                if (settingConfig.MapperType == "csv")
                {
                    responsePath = responsePath.Replace("xml", "csv");
                    if (!File.Exists(responsePath))
                    {
                        using (StreamWriter writer = File.CreateText(responsePath))
                        {
                            foreach (response_file response in responseList)
                            {if (response.field_name != "")
                                {
                                    writer.Write("\"" + response.seq_id.ToString().Trim() + "\"");
                                    writer.Write(",");
                                    writer.Write("\"" + response.error_code.ToString().Trim() + "\"");
                                    writer.Write(",");
                                    writer.Write("\"" + response.field_name.ToString().Trim() + "\"");
                                    writer.Write(",");
                                    writer.Write("\"" + response.rectype.ToString().Trim() + "\"");
                                    writer.Write(",");
                                    writer.Write("\"" + response.description.ToString().Trim() + "\"");
                                    writer.Write(",");
                                    writer.Write("\"" + response.tin.ToString().Trim() + "\"");
                                    writer.WriteLine();
                                }
                            }
                            writer.Flush();
                        }

                    }
                    else
                    {
                        using (StreamWriter writer = File.AppendText(responsePath))
                        {
                            foreach (response_file response in responseList)
                            {
                                if (response.field_name != "")
                                {
                                    writer.Write("\"" + response.seq_id.ToString().Trim() + "\"");
                                    writer.Write(",");
                                    writer.Write("\"" + response.error_code.ToString().Trim() + "\"");
                                    writer.Write(",");
                                    writer.Write("\"" + response.field_name.ToString().Trim() + "\"");
                                    writer.Write(",");
                                    writer.Write("\"" + response.rectype.ToString().Trim() + "\"");
                                    writer.Write(",");
                                    writer.Write("\"" + response.description.ToString().Trim() + "\"");
                                    writer.Write(",");
                                    writer.Write("\"" + response.tin.ToString().Trim() + "\"");
                                    writer.WriteLine();
                                }
                            }
                            writer.Flush();
                        }
                    }
                }
                else if (settingConfig.MapperType == "xml")
                {
                    SCHIPTINResponseTIN[] TinArray = new SCHIPTINResponseTIN[responseList.Count()];
                    int counter = 0;
                    foreach (response_file response in responseList)
                    { if (response.field_name != "")
                        {
                            SCHIPTINResponseTINError[] TinErrors = new SCHIPTINResponseTINError[] { new SCHIPTINResponseTINError { ErrorCode = response.error_code.Trim(), FieldName = response.field_name.Trim() } };
                            SCHIPTINResponseTIN Response = new SCHIPTINResponseTIN { description = response.description.ToString().Trim(), TIN = response.tin.Trim(), rectype = response.rectype.Trim(), Sequence_Id = response.seq_id.ToString().Trim(), Error = TinErrors };
                            TinArray[counter++] = Response;
                        }
                    }
                    var ResponseData = new SCHIPTINResponse { TIN = TinArray };
                    var serializer = new XmlSerializer(typeof(SCHIPTINResponse));
                    using (var stream = new StreamWriter(responsePath))
                        serializer.Serialize(stream, ResponseData);
                }
            }
        }
        private static void WriteResponse(IGrouping<string, response_file> RRE, StreamWriter writer)
        {
            foreach (response_file response in RRE)
            {
                writer.Write("\"" + response.seq_id.ToString().Trim() + "\"");
                writer.Write(",");
                writer.Write("\"" + response.claim_control_num.ToString().Trim() + "\"");
                writer.Write(",");
                writer.Write("\"" + response.error_code.ToString().Trim() + "\"");
                writer.Write(",");
                writer.Write("\"" + response.field_name.ToString().Trim() + "\"");
                writer.Write(",");
                writer.Write("\"" + response.account_id.ToString().Trim() + "\"");
                writer.Write(",");
                writer.Write("\"" + response.rre_id.ToString().Trim() + "\"");
                writer.WriteLine();
            }
        }
        private void SaveErrorFile(List<response_file> responseList)
        {
            foreach (response_file response in responseList)
            {
                file_error file_Error = new file_error();
                {
                    file_Error.file_id = IsClaimInput ? claim_Staging.file_id : tin_Staging.file_id;
                    file_Error.account_id = response.account_id == null ? "" : response.account_id.Value.ToString();
                    file_Error.claim_control_number = response.claim_control_num;
                    file_Error.seq_id = response.seq_id;
                    file_Error.rre_info_id = response.rre_id;
                    file_Error.field_name = response.field_name;
                    //error value of format errors
                    if (keyvalueError.Count() > 0 && keyvalueError.Keys.Contains(response.field_name))
                    {
                        file_Error.value = (keyvalueError[response.field_name]).Split('|')[1];
                    }
                    //error value of db validation errors
                    else if (IsClaimInput)
                    {
                        try
                        {
                            if (response.field_name == "ins_type")
                                file_Error.value = (string)claim_Staging.GetType().GetProperty("plan_ins_type").GetValue(claim_Staging, null);
                            else
                                file_Error.value = (string)claim_Staging.GetType().GetProperty(response.field_name).GetValue(claim_Staging, null);
                        }
                        catch
                        { //to handle field name not according to the StagingTable
                        }
                    }
                    else if (!IsClaimInput)
                    {
                        try
                        {
                            if (response.field_name != "")
                            {
                                if (response.field_name == "city")
                                    file_Error.value = (string)tin_Staging.GetType().GetProperty("office_code_city").GetValue(tin_Staging, null);
                                else if (response.field_name == "zip")
                                    file_Error.value = (string)tin_Staging.GetType().GetProperty("office_code_zip").GetValue(tin_Staging, null);
                                else if (response.field_name == "zip_ext")
                                    file_Error.value = (string)tin_Staging.GetType().GetProperty("office_code_zip_ext").GetValue(tin_Staging, null);
                                else
                                    file_Error.value = (string)tin_Staging.GetType().GetProperty(response.field_name).GetValue(tin_Staging, null);
                            }
                        }

                        catch
                        { //to handle field name not according to the StagingTable
                        }
                    }

                    file_Error.error_date = DateTime.Now;
                    file_Error.error_code = response.error_code;
                    file_Error.created_by = null;
                    file_Error.created_date = null;
                    file_Error.updated_by = null;
                    file_Error.updated_date = null;
                };
                if(response.field_name != "")
                    file_Error.Create();

            }
        }
        private bool DirectoryOK()
        {
            bool result = true;
            if (String.IsNullOrEmpty(settingConfig.CreatedBy))
            {
                LogWrapper.Information($"Created By information is not provided in appsetings file. File parsing aborted.{System.Environment.NewLine + System.Environment.NewLine}");
                string exceptionmessage = $"Created By information is not provided in appsetings file. File parsing aborted.{System.Environment.NewLine + System.Environment.NewLine}";
                IsParseSuccess = false;
                result = false;
            }
            if (!Directory.Exists(directoryPath))
            {
                LogWrapper.Information($"Directory: {directoryPath}, does not exit. File parsing aborted.{System.Environment.NewLine + System.Environment.NewLine}");
                string exceptionmessage = $"The provided directory: {directoryPath}, is not found. File parsing aborted.{System.Environment.NewLine + System.Environment.NewLine}";
                IsParseSuccess = false;
                result = false;
            }
            if (!result)
            {
                SendEmailMessage(MessageTypes.ErrorOfApplicationLevel);
            }
            return result;
        }
        private bool FileOK()
        {
            bool result = true;
            string[] paths = new[] { filePath, csvmapperpath, tincsvmapperpath, xmlmapperPath, xmlschemaPath, tinxmlmapperPath, tinxmlschemaPath };
            foreach (string str in paths)
            {
                if (!File.Exists(str))
                {
                    LogWrapper.Information($"File: {str}, is not found at location. File parsing aborted.{System.Environment.NewLine + System.Environment.NewLine}");
                    exceptionmessage = $"The provided file: {str}, is not found at location. File parsing aborted.{System.Environment.NewLine + System.Environment.NewLine}";
                    IsParseSuccess = false;
                    result = false;
                }
            }
            if (result)
            {
                if (Path.GetExtension(filePath) != ".csv" && Path.GetExtension(filePath) != ".xml")
                {
                    LogWrapper.Information($"File: {filePath}, is not of CSV/XML format. File parsing aborted.{System.Environment.NewLine + System.Environment.NewLine}");
                    exceptionmessage = $"The provided file: {filePath}, is not a CSV/XML format file. File parsing aborted.{System.Environment.NewLine + System.Environment.NewLine}";
                    IsParseSuccess = false;
                    result = false;
                }
                else
                {
                    string[] fileNameParts = fileName.Split('.');
                    if (fileNameParts.Length != 7)
                    {
                        LogWrapper.Information($"File: {fileName}, is not a of valid format. File parsing aborted.{System.Environment.NewLine + System.Environment.NewLine}");
                        exceptionmessage = $"The provided file: {fileName}, is not of a valid format. File parsing aborted.{System.Environment.NewLine + System.Environment.NewLine}";
                        IsParseSuccess = false;
                        result = false;
                    }
                    else
                    {    //SCHIP.P.CLAIM.DYYYYMMDD.THHMMSS.RREID.CSV
                        bool dateFormatOK = DateTime.TryParseExact(fileNameParts[3] + fileNameParts[4], "yyyyMMddHHmmss", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime outDate);
                        if (!(string.Equals(fileNameParts[0], "SCHIP", StringComparison.Ordinal) &&
                            new[] { "P", "T", "D" }.Contains(fileNameParts[1], StringComparer.Ordinal) &&
                            new[] { "CLAIM", "TIN" }.Contains(fileNameParts[2], StringComparer.Ordinal) &&
                            dateFormatOK)
                           )
                        {
                            LogWrapper.Information($"File:{filePath}, does not have a valid naming convention. File parsing aborted.{System.Environment.NewLine + System.Environment.NewLine}");
                            exceptionmessage = $"The provided file: {filePath}, does not have a valid naming convention. File parsing aborted.{System.Environment.NewLine + System.Environment.NewLine}";
                            IsParseSuccess = false;
                            result = false;
                        }
                        else
                        {
                            if (fileNameParts[2].ToLower() == "claim")
                                inputtype = InputType.Claim.ToString();
                            else if (fileNameParts[2].ToLower() == "tin")
                                inputtype = InputType.Tin.ToString();
                            fileReceived = outDate;
                            rreid = fileNameParts[5];
                        }
                    }
                }
            }

            if (!result)
            {
                invalidFileNameList.Add(fileName);
                SendEmailMessage(MessageTypes.ErrorOfApplicationLevel);
            }
            return result;
        }
        protected virtual void SendEmailMessage(MessageTypes notificationType)
        {
            if (ParseHook != null && !String.IsNullOrEmpty(settingConfig.EnableMailing))
            {
                if (notificationType == MessageTypes.ValidationErrorOfIndividualRowParsing)
                {
                    string subj = $"Error message logged for {(IsClaimInput ? "claim control number" : "tin")}: {referenceValue}.";
                    settingConfig.subject += subj;
                    settingConfig.body = GenerateErrorMailBody();
                    EMailMessage mailMessage = new EMailMessage(settingConfig);
                    ParseHook(this, new CustomEventArgs() { Message = mailMessage });
                    settingConfig.subject = settingConfig.subject.Replace(subj, "");
                    settingConfig.body = "";
                }
                else if (notificationType == MessageTypes.ErrorOfApplicationLevel)
                {
                    string subj = "Execption occured";
                    settingConfig.subject += subj;
                    settingConfig.body = $"Exception occured while running the DataParser application using file {fileName} and map file {Path.GetFileName(mapperPath)}. {exceptionmessage}";
                    EMailMessage mailMessage = new EMailMessage(settingConfig);
                    ParseHook(this, new CustomEventArgs() { Message = mailMessage });
                    settingConfig.subject = settingConfig.subject.Replace(subj, "");
                    settingConfig.body = "";
                    exceptionmessage = "";
                }
                else if (notificationType == MessageTypes.NotificationOfAllParsingCompleted)
                {
                    string subj = "CSV file parsing completed.";
                    settingConfig.subject += subj;
                    settingConfig.body = $"CSV file parsing completed {(IsParseSuccess ? "successfully." : "unsuccessfully")} using CSV file {fileName} and map file {Path.GetFileName(mapperPath)}.";
                    EMailMessage mailMessage = new EMailMessage(settingConfig);
                    ParseHook(this, new CustomEventArgs() { Message = mailMessage });
                    settingConfig.subject = settingConfig.subject.Replace(subj, "");
                    settingConfig.body = "";
                }
            }
        }
        private string GenerateErrorMailBody()
        {
            string textBody = $"<table border=" + 1 + " width=" + 800 + ">";
            textBody += @"<tr><td bgcolor='#C39BD3 '><b>Field Name</b></td> <td bgcolor='#C39BD3'><b> Error Description</b></td></tr>";
            foreach (KeyValuePair<string, string> kvp in keyvalueError)
            {
                textBody += $"<tr><td><b>{kvp.Key}</b></td> <td><b> {kvp.Value}</b></td></tr>";
            }
            textBody += "</table>";
            return textBody;
        }
        private void MoveFileToArchieveOutFolder()
        {
            string ArchieveDirPath = string.Empty;
            FileInfo mFile = null;
            //move response files
            try
            {
                DirectoryInfo d = new DirectoryInfo(outgoingPath);
                if (d.GetFiles().Count() > 0)
                {
                    FileInfo[] respFiles = d.GetFiles();
                    foreach (FileInfo file in respFiles)
                    {
                        if (file.Extension.ToLower().Equals(".xml") || file.Extension.ToLower().Equals(".csv"))
                        {
                            fileName = file.Name;
                            //get account folder name, from the child (as it is not decided yet)
                            rreid = RREFile.Where(kvp => kvp.Value.Contains(fileName)).Select(kvp => kvp.Key).FirstOrDefault();
                            if (rreid != null)
                            {
                                string accountName = AccountRREsFromClient.Where(kvp => kvp.Value.Contains(rreid)).Select(kvp => kvp.Key).FirstOrDefault();
                                ArchieveDirPath = archivedPath + "\\" + accountName + "\\" + rreid + "\\Outgoing";
                                FileMoveCopy(ArchieveDirPath, outgoingPath, ref mFile, true);//move response file
                            }
                            else
                            {   if (invalidFileNameList.Contains(fileName))
                                {
                                    LogWrapper.Information($"Moving file {fileName} to {archivedPath} aborted, because the file with invalid name was not parsed. {System.Environment.NewLine}");
                                }
                                else
                                {
                                    LogWrapper.Information($"Moving file {fileName} to {archivedPath} aborted, because a file with similar name already exists in the destination folder. {System.Environment.NewLine}");
                                }
                            }
                        }
                    }
                }

                d = new DirectoryInfo(directoryPath);
                if (d.GetFiles().Count() > 0)
                {
                    FileInfo[] inputFiles = d.GetFiles();

                    foreach (FileInfo file in inputFiles)
                    {
                        if (file.Extension.ToLower().Equals(".xml") || file.Extension.ToLower().Equals(".csv"))
                        {
                            fileName = file.Name;
                            //get account folder name, from the child (as it is not decided yet)
                            rreid = RREFile.Where(kvp => kvp.Value.Contains(fileName)).Select(kvp => kvp.Key).FirstOrDefault();
                            if (rreid != null)
                            {
                                string accountName = AccountRREsFromClient.Where(kvp => kvp.Value.Contains(rreid)).Select(kvp => kvp.Key).FirstOrDefault();
                                ArchieveDirPath = archivedPath + "\\" + accountName + "\\" + rreid + "\\Incoming";
                                FileMoveCopy(ArchieveDirPath, directoryPath, ref mFile, true);//move inputfiles file
                            }
                            else
                            {
                                if (invalidFileNameList.Contains(fileName))
                                {
                                    LogWrapper.Information($"Moving file {fileName} to {archivedPath} aborted, because the file with invalid name was not parsed. {System.Environment.NewLine}");
                                }
                                else
                                {
                                    LogWrapper.Information($"Moving file {fileName} to {archivedPath} aborted, because a file with similar name already exists in the destination folder. {System.Environment.NewLine}");
                                }
                            }
                        }
                    }
                }

            }
            catch (System.Exception excpt)
            {
                LogWrapper.Error(excpt, $"Error Occured while moving file - {mFile.FullName},  to {ArchieveDirPath}");
            }

        }
        private void CopyResponseToClientFolder()
        {
            string clientDirPath = string.Empty;
            FileInfo mFile = null;
            try
            {   //get account folder name, from the client (as it is not decided yet)
                string accountName = AccountRREsFromClient.Where(kvp => kvp.Value.Contains(rreid)).Select(kvp => kvp.Key).FirstOrDefault();
                //A.save claimfile name
                if (!RREFile.Keys.Contains(rreid))
                {
                    RREFile.Add(rreid, new List<string> { fileName });
                }
                else
                {
                    List<string> rrefiles = RREFile[rreid];
                    rrefiles.Add(fileName);
                }

                clientDirPath = clientHomePath + "\\" + accountName + "\\" + rreid + "\\Outgoing";
                FileMoveCopy(clientDirPath, outgoingPath, ref mFile, false);//copy file not move
            }
            catch (System.Exception excpt)
            {
                LogWrapper.Error(excpt, $"Error Occured while moving file - {mFile.FullName}, to  {clientDirPath}");
            }
        }

        private FileInfo FileMoveCopy(string DestinationDirPath, string SourceDirPath, ref FileInfo mFile, bool MoveFile)
        {
            DirectoryInfo DestinationDirInfo = new DirectoryInfo(DestinationDirPath);
            if (DestinationDirInfo.Exists)
            {
                //handle name collisions
                if (MoveFile)
                {
                    if (IsClaimInput)
                        mFile = new FileInfo(SourceDirPath + "\\" + fileName);
                    else
                        mFile = new FileInfo(SourceDirPath + "\\" + fileName);
                    //check if the file already exists in the destination folder
                    if (new FileInfo(DestinationDirInfo + "\\" + fileName).Exists == false)
                    {   //confirm that the file exists in the source folder
                        if (mFile.Exists)
                        {
                            LogWrapper.Information($"{(MoveFile ? "Moving" : "Copying")} file {mFile.FullName}, to {DestinationDirInfo.FullName} {System.Environment.NewLine}");
                            mFile.MoveTo(DestinationDirInfo + "\\" + mFile.Name);                            
                        }
                        else
                        { LogWrapper.Information($"{mFile.Name} does not exist. {System.Environment.NewLine}"); }
                    }
                    else
                    {
                        if (invalidFileNameList.Contains(fileName))
                        {
                            LogWrapper.Information($"Moving file {fileName} to {archivedPath} aborted, because the file with invalid name was not parsed. {System.Environment.NewLine}");
                        }
                        else
                        {
                            LogWrapper.Information($"Moving file {fileName + " to " + DestinationDirInfo} aborted, because a file with similar name already exists in the destination folder. {System.Environment.NewLine}");
                        }
                    }
                }
                else
                {
                    if (IsClaimInput)
                        mFile = new FileInfo(SourceDirPath + "\\" + fileName.Replace("CLAIM", "CLAIMRESPONSE"));
                    else
                        mFile = new FileInfo(SourceDirPath + "\\" + fileName.Replace("TIN", "TINRESPONSE"));
                    //check if the file already exists in the destination folder
                    if (new FileInfo(DestinationDirInfo + "\\" + mFile.Name).Exists == false)
                    {   //confirm that the file exists in the source folder

                        if (mFile.Exists)
                        {
                            File.Copy(mFile.FullName, DestinationDirInfo + "\\" + mFile.Name);
                            LogWrapper.Information($"{(MoveFile ? "Moving" : "Copying")} file {mFile.FullName}, to {DestinationDirInfo.FullName} {System.Environment.NewLine}");
                            //B. save response file name
                            if (!RREFile.Keys.Contains(rreid))
                            {
                                RREFile.Add(rreid, new List<string> { mFile.Name });
                            }
                            else
                            {
                                List<string> rrefiles = RREFile[rreid];
                                rrefiles.Add(mFile.Name);
                            }

                        }
                        else
                        { LogWrapper.Information($"There is no response file for the {fileName}.The file has no error. {System.Environment.NewLine}"); }

                    }
                    else
                    {
                        if (invalidFileNameList.Contains(fileName))
                        {
                            LogWrapper.Information($"Moving file {fileName} to {archivedPath} aborted, because the file with invalid name was not parsed. {System.Environment.NewLine}");
                        }
                        else
                        {
                            LogWrapper.Information($"Moving file {mFile.Name + " to " + DestinationDirInfo} aborted, because a file with similar name already exists in the destination folder. {System.Environment.NewLine}");
                        }
                    }
                }               
            }
            else
            {
                LogWrapper.Information($"Folder structure {DestinationDirInfo}, does not exist. {System.Environment.NewLine}");
            }

            return mFile;
        }

        private void GetAccountRREs()
        {
            string[] accountsDirectory = Directory.GetDirectories(clientHomePath);
            foreach (string accDir in accountsDirectory)
            {
                string[] rresDirectory = Directory.GetDirectories(accDir);
                List<string> RREs = new List<string>();
                foreach (string dir in Directory.GetDirectories(accDir))
                {
                    RREs.Add(new DirectoryInfo(dir).Name);
                }

                AccountRREsFromClient.Add(new DirectoryInfo(accDir).Name, RREs);
            }
        }

    }
}
