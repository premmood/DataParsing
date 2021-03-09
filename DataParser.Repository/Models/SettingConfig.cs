using System;
using System.Collections.Generic;
using System.Text;

namespace DataParser
{
    public class SettingConfig
    {
        public string ClientHomePath { get; set; }
        public string InternalProcessingPath { get; set; }
        public string ClientPath { get; set; }
        public string ArchivedPath { get; set; }
        public string Filename { get; set; }
        public string CSVMapperFilepath { get; set; }
        public string TINCSVMapperFilepath { get; set; }
        public string TINXMLMapperFilepath { get; set; }
        public string XMLMapperFilepath { get; set; }
        public string MapperType { get; set; }        
        public string XMLSchemaFilepath { get; set; }
        public string TINXMLSchemaFilepath { get; set; }
        public string ValidationLogFilename { get; set; }
        public string ApplicationLog { get; set; }
        public string ConnectionString { get; set; }
        public string Environment { get; set; }
        public string SendMailTo { get; set; }
        public string SendMailCC { get; set; }
        public string subject { get; set; }
        public string from { get; set; }
        public string body { get; set; }
        public string HTMLTemplatePath { get; set; }
        public string PathsToAttachments { get; set; }
        public string EnableMailing { get; set; }
        public string CreatedBy { get; set; }

    }
}
