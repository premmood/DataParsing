using System;
using System.Collections.Generic;
using Serilog;
using Spiralogics.Logger;

namespace DataParser
{
    public static class LogWrapper
    {
        public static void LogParsingCompletionMessage(bool IsParseSuccess)
        {
            if (IsParseSuccess)
            {
                Information($"****************Parsing completed - successfully.****************");
            }
            else
            {
                Error($"****************Parsing is unsuccessfully****************");
            }

        }

        public static void LogClaimStaggingNotVallid(claim_staging claimclaimStagingObj, Dictionary<string, string> keyvalueError, string logPath)
        {
            Error(null, $"Logging parsing error message for claim info. id: {claimclaimStagingObj.claim_info_id}");
            LogValidationError.LogError(keyvalueError, logPath);

        }

        public static void Information(string message, params object[] args)
        {
            //Spiralogics.Logger.SpiralogicsLog.Information(message, args);
            Spiralogics.Logger.SpiralogicsLog.Information("{message}", message,args);
        }

        public static void Error(Exception excp, string message, params object[] args)
        {
            Spiralogics.Logger.SpiralogicsLog.Error(excp, message, args);
        }

        public static void Error(string message, params object[] args)
        {

            Spiralogics.Logger.SpiralogicsLog.Error(message, args);

        }
    }
}
