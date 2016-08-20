using System;
using System.Collections.Generic;
using System.Configuration;
using Test.BUSINESS.INTERFACES;
using Test.BUSINESS.UTIL;
using System.IO;

namespace Test.BUSINESS.IMPLEMENTATIONS
{
    public class ImpJobLoggerToFile : IJobLogger
    {
        private readonly string _message;

        public ImpJobLoggerToFile(string message)
        {
            _message = message;
        }

        public void LogMessage()
        {
            Validation();
            LogToFile(LogType.Message);
        }

        public void LogWarning()
        {
            Validation();
            LogToFile(LogType.Warning);
        }

        public void LogError()
        {
            Validation();
            LogToFile(LogType.Error);
        }

        private void LogToFile(LogType logType)
        {
            var logFileDirectory = ConfigurationManager.AppSettings["LogFileDirectory"];
            var todayDate = DateTime.Now.ToShortDateString();
            var logFileName = logFileDirectory + "LogFile_" + todayDate.Replace("/", "_") + ".txt";
            var l = "";
            if (File.Exists(logFileName))
            {
                l = File.ReadAllText(logFileName);
            }
            switch (logType)
            {
                case LogType.Error:
                    l += "Error - " + todayDate + ": " + _message + Environment.NewLine;
                    break;
                case LogType.Message:
                    l += "Message - " + todayDate + ": " + _message + Environment.NewLine;
                    break;
                case LogType.Warning:
                    l += "Warning - " + todayDate + ": " + _message + Environment.NewLine;
                    break;
            }
            File.WriteAllText(logFileName, l);
        }

        public void Validation()
        {
            _message.Trim();

            if (string.IsNullOrEmpty(_message))
                return;
        }
    }
}