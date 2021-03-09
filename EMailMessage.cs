using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataParser
{
    public class CustomEventArgs : EventArgs
    {
        public EMailMessage Message { get; set; }
    }

    public delegate void CustomEventHandler(object sender, CustomEventArgs customEventArgs);
    public class EMailMessage
    {
        public List<string> To { get; set; }
        public List<String> CC { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public List<string> Attachments { get; set; }

        public EMailMessage(SettingConfig settingConfig)
        {
            this.To = settingConfig.SendMailTo.Split(",").ToList<string>();
            this.CC = settingConfig.SendMailCC.Split(",").ToList<string>();
            this.Subject = settingConfig.subject;
            string filePath = Directory.GetCurrentDirectory() + settingConfig.HTMLTemplatePath;
            if (string.IsNullOrEmpty(settingConfig.body))
                this.Content = File.ReadAllText(filePath);
            else
             this.Content = settingConfig.body;
            this.Attachments = settingConfig.PathsToAttachments.Split(",").ToList<string>();
        }


    }
}
