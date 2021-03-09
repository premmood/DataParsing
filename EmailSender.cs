using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Serilog;
using Spiralogics.EmailHelper;
using System;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.MemoryStorage;
using System.Threading;
using System.Collections.Generic;

namespace DataParser
{
    public class SmtpAPI
    {
        public string apiurl { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
    public class TokenObj
    {
        public string success;
        public Payload payload;

    }
    public class Payload
    {
        public string token;
        public string role;
        public string username;
        public int expiresIn;
    }
    public class EmailSender
    {
        private readonly SmtpAPI _apiSettings;
        private EMailMessage message;
        public EmailSender(SmtpAPI smtpAPI)
        {
           _apiSettings = smtpAPI;
        }

        public string GetConstructorParameter()
        {
            throw new NotImplementedException();
        }

        public async void SendMailAsync(Object obj, CustomEventArgs args)
        {
            try
            {   //CALLING EMAILSENDER COMPONENT
                message = args.Message;
                LogWrapper.Information($"Sending mail to {message.To.Aggregate((x, y) => x + ", " + y)} regarding {message.Subject}");
                if (_apiSettings == null)
                {
                    SendEmail sendEmail = new SendEmail();
                    await Task.Run(() => sendEmail.Send(message.To, message.CC, message.Subject, message.Content, message.Attachments));
                }
                else
                {
                    string v = await Task.Run(() => SmtpSendEmail(_apiSettings));
                    LogWrapper.Information(v);
                }
                LogWrapper.Information($"Email successfully sent!");
            }
            catch (System.Exception ex)
            {
                LogWrapper.Error(ex, "Error sending email");
                throw new System.Exception(ex.Message);
            }
        }



        public void SendEMail(Object obj, CustomEventArgs args)
        {
            try
            {   //CALLING EMAILSENDER COMPONENT
                message = args.Message;

                if (_apiSettings == null)
                {
                    SendEmail sendEmail = new SendEmail();
                    BackgroundJob.Enqueue(() => sendEmail.Send(message.To, message.CC, message.Subject, message.Content, message.Attachments));
                }

                else
                {
                        string v = BackgroundJob.Enqueue(() => SmtpSendEmail(_apiSettings));
                        LogWrapper.Information("API Smtp Email:" + v);
                }

                LogWrapper.Information($"Email successfully sent!");
            }
            catch (System.Exception ex)
            {
                LogWrapper.Error(ex, "Error sending email");
                throw new System.Exception(ex.Message);
            }
        }

        public void SendMail(Object obj, CustomEventArgs args)
        {
            try
            {   //CALLING EMAILSENDER COMPONENT
                message = args.Message;
                LogWrapper.Information($"Sending mail to {message.To.Aggregate((x, y) => x + ", " + y)} regarding {message.Subject}");             
                if (_apiSettings == null)
                {
                    SendEmail sendEmail = new SendEmail();
                    sendEmail.Send(message.To, message.CC, message.Subject, message.Content, message.Attachments);
                }
                else
                {
                    string v = SmtpSendEmail(_apiSettings);
                    LogWrapper.Information(v);
                }
                LogWrapper.Information($"Email successfully sent!");
            }
            catch (System.Exception ex)
            {
                LogWrapper.Error(ex, "Error sending email");
                throw new System.Exception(ex.Message);
            }  
        }

        public string SmtpSendEmail(SmtpAPI smtpAPI)// string toEmail, string emailSubject, string htmlContent)
        {
            string SmtpApiUrl = smtpAPI.apiurl;
            string SmtpUserName = smtpAPI.username;
            string SmtpPassword = smtpAPI.password;


            if (string.IsNullOrWhiteSpace(SmtpApiUrl) || string.IsNullOrWhiteSpace(SmtpUserName) || string.IsNullOrWhiteSpace(SmtpPassword))
            {
                return "Email delivery failed";
            }

            RestClient restClient = new RestClient(SmtpApiUrl);

            #region gettoken
            JObject jObjectbody = new JObject();
            jObjectbody.Add("username", SmtpUserName);
            jObjectbody.Add("password", SmtpPassword);
            RestRequest restRequest = new RestRequest("/user/authtoken", Method.POST);

            restRequest.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

            IRestResponse restResponse = restClient.Execute(restRequest);
            var receivedtoken = (JsonConvert.DeserializeObject<TokenObj>(restResponse.Content)).payload.token ?? "";
            #endregion

            if (receivedtoken != "")
            {
                JObject emailjObjectbody = new JObject();
                emailjObjectbody.Add("to", message.To.Aggregate((x, y) => x + ", " + y));
                emailjObjectbody.Add("subject", message.Subject);
                emailjObjectbody.Add("type", "html");
                emailjObjectbody.Add("body", message.Content);
                RestRequest emailrestRequest = new RestRequest("/email/sendEmail", Method.POST);
                emailrestRequest.AddParameter("application/json", emailjObjectbody, ParameterType.RequestBody);
                emailrestRequest.AddHeader("authorization", receivedtoken);
                IRestResponse emailrestResponse = restClient.Execute(emailrestRequest);

                return "Email delivery success";
            }

            return "Email delivery failed";
        }
    }
}
