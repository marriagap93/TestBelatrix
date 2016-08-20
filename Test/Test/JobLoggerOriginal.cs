using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Test
{
    public class JobLoggerOriginal
    {
        private static bool _logToFile;
        private static bool _logToConsole;
        private static bool _logMessage;
        private static bool _logWarning;
        private static bool _logError;
        private static bool LogToDatabase;
        private bool _initialized;

        public JobLoggerOriginal(bool logToFile, bool logToConsole, bool logToDatabase, bool logMessage, bool logWarning,
            bool logError)
        {
            _logToFile = logToFile;
            _logToConsole = logToConsole;
            _logMessage = logMessage;
            _logWarning = logWarning;
            _logError = logError;
            LogToDatabase = logToDatabase;

        }

        public static void LogMessage(string smessage, bool bmessage, bool warning, bool error)
        {
            smessage.Trim();
            if (smessage == null || smessage.Length == 0)
            {
                return;
            }
            if (!_logToConsole && !_logToFile && !LogToDatabase)
            {
                throw new Exception("Invalid configuration");
            }
            if ((!_logError && !_logMessage && !_logWarning) || (!bmessage && !warning && !error))
            {
                throw new Exception("Error or Warning or Message must be specified");
            }
            #region TO DB
            SqlConnection connection = new
                SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            connection.Open();
            int t = -1;
            if (bmessage && _logMessage)
            {
                t = 1;
            }
            if (error && _logError)
            {
                t = 2;
            }
            if (warning && _logWarning)
            {
                t = 3;
            }
            SqlCommand command = new
                SqlCommand("Insert into Log Values('" + smessage + "', " + t + ")");
            command.ExecuteNonQuery();
            #endregion
            #region TO FILE
            string l = "";
            if
                (
                !System.IO.File.Exists(ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" +
                                       DateTime.Now.ToShortDateString() + ".txt"))
            {
                l =
                    System.IO.File.ReadAllText(ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" +
                                               DateTime.Now.ToShortDateString() + ".txt");
            }
            if (error && _logError)
            {
                l += DateTime.Now.ToShortDateString() + smessage;
            }
            if (warning && _logWarning)
            {
                l += DateTime.Now.ToShortDateString() + smessage;
            }
            if (bmessage && _logMessage)
            {
                l += DateTime.Now.ToShortDateString() + smessage;
            }

            System.IO.File.WriteAllText(
                ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() +
                ".txt", l);

            #endregion
            #region TO CONSOLE
            if (error && _logError)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (warning && _logWarning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (bmessage && _logMessage)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine(DateTime.Now.ToShortDateString() + smessage);
            #endregion
        }
    }
}