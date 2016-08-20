using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BUSINESS.INTERFACES;
using Test.BUSINESS.UTIL;

namespace Test.BUSINESS.IMPLEMENTATIONS
{
    public class ImpJobLoggerToConsole : IJobLogger
    {
        private readonly string _message;

        public ImpJobLoggerToConsole(string message)
        {
            _message = message;
        }

        public void LogMessage()
        {
            Validation();
            LogToConsole(LogType.Message);
        }

        public void LogWarning()
        {
            Validation();
            LogToConsole(LogType.Warning);
        }

        public void LogError()
        {
            Validation();
            LogToConsole(LogType.Error);
        }

        private void LogToConsole(LogType logType)
        {
            switch (logType)
            {
                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogType.Message:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
            Console.WriteLine(DateTime.Now.ToShortDateString() + _message);
        }

        private void Validation()
        {
            _message.Trim();

            if (string.IsNullOrEmpty(_message))
                return;
        }
    }
}
