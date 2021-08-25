using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWrapper.Common.Logger
{
    public class LoggerService : ILoggerService
    {
        public void Log(string message, LogLevel logLevel = LogLevel.Normal, bool withConsoleOutput = true)
        {
            Logger.LogToFile(message, logLevel);
            if (withConsoleOutput) Logger.LogToConsole(message, logLevel);
        }
    }
}
