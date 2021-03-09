using DataParser.Repository.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DataParser
{
    //[CheckLengthType()]
    public class CustomClassValidation
    {
        [AttributeUsage(AttributeTargets.Class, Inherited = false)]
        //there are default Validation Attributes (Required) provided by the DataAnnotations
        //But, we are creating a CheckLengthType validationAttribute by implementing the ValidationAttribute
        //and overriding the IsValid method.
        public class CheckLengthType : ValidationAttribute 
        {
            private JObject mapperJObject { get; set; }
            private SettingConfig settingConfig { get; set; }
            private string seq_id { get; set; }
            public CheckLengthType()
            {
                var configuration = new ConfigurationBuilder()
                      .AddJsonFile("appsettings.json").Build();
                settingConfig = new SettingConfig();
                configuration.GetSection("ApplicationSettings").Bind(settingConfig);

            }
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                string mapperPath = string.Empty;
                Object _Staging = null;
                //claim_staging _Staging = new claim_staging();
                //tin_staging tin_Staging = new tin_staging();
                foreach (var v in validationContext.Items)
                {
                    if (v.Key.ToString() == "MapperType")
                    {
                        mapperPath = v.Value.ToString();
                    }
                    else if (v.Key.ToString() == "ClaimObj")
                    {
                        _Staging = (claim_staging)v.Value;
                        mapperPath=mapperPath=="csv"?settingConfig.CSVMapperFilepath : settingConfig.XMLMapperFilepath ;
                    }
                    else if (v.Key.ToString() == "TinObj")
                    {
                        _Staging = (tin_staging)v.Value;
                        mapperPath = mapperPath == "csv" ?settingConfig.TINCSVMapperFilepath : settingConfig.TINXMLMapperFilepath;
                    }
                }


                var mapperJsonString = File.ReadAllText(mapperPath);
                mapperJObject = JObject.Parse(mapperJsonString);
                ValidationResult validationResult;
                List<string> errorMessages = new List<string>();

                foreach (PropertyInfo property in value.GetType().GetProperties())
                {
                    string fieldName = property.Name;

                    if (mapperJObject.ContainsKey(fieldName))
                    {
                        try
                        {
                            string fieldLength = ((JArray)mapperJObject.GetValue(fieldName))[0].ToString();
                            string fieldDataType = ((JArray)mapperJObject.GetValue(fieldName))[1].ToString();
                            string fieldValue = Convert.ToString(value.GetType().GetProperty(fieldName).GetValue(value));
                            if (fieldName == "seq_id")
                                seq_id = fieldValue;
                            {
                                string errMsg = checkDataType(fieldDataType, fieldLength, fieldName, fieldValue, out string replaceValue);
                                if (fieldDataType == "N")
                                {
                                    if (string.IsNullOrEmpty(replaceValue))
                                    {
                                        _Staging.GetType().GetProperty(fieldName).SetValue(_Staging, null);
                                    }
                                    else
                                    {
                                        _Staging.GetType().GetProperty(fieldName).SetValue(_Staging, Convert.ToInt32(replaceValue));
                                    }
                                }
                                else if (fieldDataType == "B")
                                {
                                    if (string.IsNullOrEmpty(replaceValue))
                                    {
                                        _Staging.GetType().GetProperty(fieldName).SetValue(_Staging, null);
                                    }
                                    else
                                    {
                                        _Staging.GetType().GetProperty(fieldName).SetValue(_Staging, Convert.ToBoolean(Convert.ToInt32(replaceValue)));
                                    }
                                }
                                else if (fieldDataType == "M")
                                {
                                    if (string.IsNullOrEmpty(replaceValue))
                                    {
                                        _Staging.GetType().GetProperty(fieldName).SetValue(_Staging, null);
                                    }
                                    else
                                    {
                                        _Staging.GetType().GetProperty(fieldName).SetValue(_Staging, Convert.ToDouble(replaceValue));
                                    }
                                }
                                else if (fieldDataType == "D")
                                 {
                                    if (string.IsNullOrEmpty(replaceValue))
                                    {
                                        _Staging.GetType().GetProperty(fieldName).SetValue(_Staging, null);
                                    }
                                    else
                                    {
                                        _Staging.GetType().GetProperty(fieldName).SetValue(_Staging, Convert.ToDateTime(replaceValue));
                                    }
                                }
                                else
                                {
                                    _Staging.GetType().GetProperty(fieldName).SetValue(_Staging, replaceValue);
                                }

                                if (errMsg != "")
                                    errorMessages.Add(fieldName + ":" + errMsg);
                            }
                        }
                        catch (Exception ex)
                        {
                          errorMessages.Add($"Sequence Id {seq_id}, field name {fieldName} is a required field, it was assigned an empty value.| ");
                            LogWrapper.Error(ex, "Error occured while validating the claim file properties: ");
                        }
                    }
                }

                if (errorMessages.Count > 0)
                    validationResult = new ValidationResult("Error List Included ", errorMessages);
                else
                    validationResult = null;
                return validationResult;
            }
            private string checkDataType(string fieldDataType, string fieldLength, string fieldName, string fieldValue, out string replaceValue)
            {
                string msg = "";
                int length = Convert.ToInt32(fieldLength);
                replaceValue = fieldValue;
                if (fieldDataType == "D" && fieldValue != "")
                {
                    if (fieldValue.Length != length)
                    {
                        replaceValue = null;
                        msg = $"Sequence Id {seq_id}, field name {fieldName}, value {fieldValue} is saved empty to database due to length size violation, has length {fieldValue.Length} instead of {length}.| ";
                        LogWrapper.Information(msg.Split('|')[0]);
                    }
                    else
                    {
                        if (DateTime.TryParseExact(fieldValue, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                        {
                            if (date < ((DateTime)System.Data.SqlTypes.SqlDateTime.MinValue))
                            {
                                replaceValue = null;
                            }
                            else
                            {
                                replaceValue = date.ToShortDateString();
                            }
                        }
                        else
                        {
                            replaceValue = null;
                            msg = $"Sequence Id {seq_id}, field name {fieldName}, value {fieldValue} is saved empty to database due to format violation.| ";
                            LogWrapper.Information(msg.Split('|')[0]);
                        }
                    }
                }
                else if ((fieldDataType == "N" || fieldDataType == "B") && fieldValue != "")
                {

                    if (fieldValue.All(Char.IsDigit))
                    {
                        if (Convert.ToInt64(fieldValue) > int.MaxValue)
                        {
                            replaceValue = null;
                            msg = $"Sequence Id {seq_id}, field name {fieldName}, value {fieldValue} is saved empty to database due to format violation.|{fieldValue}";
                            LogWrapper.Information(msg.Split('|')[0]);

                        }
                        else
                        {
                            if (fieldValue.Length > length)
                            {
                                msg = $"Sequence Id {seq_id}, field name {fieldName}, due to length constraint of {length}, value changed from {fieldValue}";
                                replaceValue = fieldValue.Substring(0, Convert.ToInt32(length));
                                msg += $" to {replaceValue}.|{fieldValue}";
                                LogWrapper.Information(msg.Split('|')[0]);
                            }
                            else
                            replaceValue = fieldValue;
                        }
                    }
                    else
                    {
                        replaceValue = null;
                        msg = $"Sequence Id {seq_id}, field name {fieldName}, value {fieldValue} is saved empty to database due to format violation.|{fieldValue}";
                        LogWrapper.Information(msg.Split('|')[0]);
                    }
                }
                else if (fieldDataType == "M" && fieldValue != "")
                {
                    if (fieldValue.Replace(".", "").All(Char.IsDigit))
                    {
                        if (fieldValue.Length > Convert.ToInt32(fieldLength))
                        {
                            msg = $"Sequence Id {seq_id}, field name {fieldName}, due to length constraint of {length}, value changed from {fieldValue}";
                            replaceValue = fieldValue.Substring(0, Convert.ToInt32(length));
                            msg += $" to {replaceValue}.|{fieldValue}";

                            replaceValue = null;
                            LogWrapper.Information(msg.Split('|')[0]);
                        }
                        else
                        {
                            try
                            {
                                replaceValue = Convert.ToDouble(fieldValue).ToString();
                            }
                            catch (Exception)
                            {
                                replaceValue = null;
                                msg = $"Sequence Id {seq_id}, field name {fieldName}, value {fieldValue} is saved empty to database due to format violation.|{fieldValue}";
                                LogWrapper.Information(msg.Split('|')[0]);

                            }
                        }
                    }
                    else
                    {
                        replaceValue = null;
                        msg = $"Sequence Id {seq_id}, field name {fieldName}, value {fieldValue} is saved empty to database due to format violation.|{fieldValue}";
                        LogWrapper.Information(msg.Split('|')[0]);
                    }
                }
                else if (fieldDataType == "A" && fieldValue != "")
                {
                    bool result = fieldValue.All(Char.IsLetter);
                    if (!result)
                    {
                        replaceValue = null;
                        msg = $"Sequence Id {seq_id}, field name {fieldName}, value {fieldValue} is saved empty to database due to format violation.|{fieldValue}";
                        LogWrapper.Information(msg.Split('|')[0]);
                    }
                    else
                    {
                        if (fieldValue.Length > Convert.ToInt32(length))
                        {
                            msg = $"Sequence Id {seq_id}, field name {fieldName}, due to length constraint of {length}, value changed from {fieldValue}";
                            replaceValue = fieldValue.Substring(0, Convert.ToInt32(length));
                            msg += $" to {replaceValue}.|{fieldValue}";
                            LogWrapper.Information(msg.Split('|')[0]);
                        }
                    }
                }
                else if ((fieldDataType == "AN" || fieldDataType == "ANP") && fieldValue != "")
                {
                    if (fieldValue.Length > Convert.ToInt32(length))
                    {
                        msg = $"Sequence Id {seq_id}, field name {fieldName}, due to length constraint of {length}, value changed from {fieldValue}";
                        replaceValue = fieldValue.Substring(0, Convert.ToInt32(length));
                        msg += $" to {replaceValue}.|{fieldValue}";
                        LogWrapper.Information(msg.Split('|')[0]);
                    }
                    else
                    {
                        for (int i = 0; i < fieldValue.Length; i++)
                        {
                            char ch = fieldValue[i];
                            if (fieldDataType == "AN" && ((ch >= 65 && ch <= 90) || (ch >= 97 && ch <= 122) || (ch >= 48 && ch <= 57) || (ch >= 44 && ch <= 47) || ch == 38 || ch == 32 || ch == 39 || ch == 58 || ch == 59 || ch == 35 || ch == 64))
                            {
                            }
                            else if (fieldDataType == "ANP" && ((ch >= 65 && ch <= 90) || (ch >= 97 && ch <= 122) || (ch >= 48 && ch <= 57) || (ch >= 44 && ch <= 47) || ch == 38 || ch == 32 || ch == 39 || ch == 58 || ch == 59 || ch == 35 || ch == 64 || ch == 40 || ch == 41))
                            {
                            }
                            else
                            {
                                replaceValue = null;
                                msg = $"Sequence Id {seq_id}, field name {fieldName}, value {fieldValue} is saved empty to database due to format violation.|{fieldValue}";
                                LogWrapper.Information(msg.Split('|')[0]);
                            }
                        }
                    }
                }
                return msg;
            }
        }

    }
}
