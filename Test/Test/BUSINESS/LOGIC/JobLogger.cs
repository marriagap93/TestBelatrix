using System;
using Test.BUSINESS.INTERFACES;

namespace Test.BUSINESS.LOGIC
{
    public class JobLogger
    {
        public void MakeLogger(IJobLogger iLogger, bool logError, bool logMessage, bool logWarning)
        {
            if (logError)
                iLogger.LogError();
            if (logMessage)
                iLogger.LogMessage();
            if (logWarning)
                iLogger.LogWarning();
            if (!logError && !logMessage && !logWarning)
                throw new Exception("Error or Warning or Message must be specified");
        }
    }
}