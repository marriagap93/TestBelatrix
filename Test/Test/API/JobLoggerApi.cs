using System;
using Test.BUSINESS.IMPLEMENTATIONS;
using Test.BUSINESS.LOGIC;

namespace Test.API
{
    public static class JobLoggerApi
    {
        public static void MakeLog(string message, bool logToFile, bool logToConsole, bool logToDatabase,
            bool logMessage, bool logWarning,bool logError)
        {
            var logger = new JobLogger();
            if (logToFile)
            {
                var toFile = new ImpJobLoggerToFile(message);
                logger.MakeLogger(toFile, logError, logMessage, logWarning);
            }
            if (logToConsole)
            {
                var toConsole = new ImpJobLoggerToConsole(message);
                logger.MakeLogger(toConsole, logError, logMessage, logWarning);
            }
            if (logToDatabase)
            {
                var toDb = new ImpJobLoggerToDb(message);
                logger.MakeLogger(toDb, logError, logMessage, logWarning);
            }            
            if (!logToFile && !logToConsole && !logToDatabase)
                throw new Exception("Invalid configuration");
        }
        
    }
}