using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWrapper.Common.Logger
{
    public static class Logger
    {
        private readonly static ILogger _fileLogger;
        private readonly static ILogger _consoleLogger;

        static Logger()
        {
            _fileLogger = new LoggerConfiguration().WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day).CreateLogger();
            _consoleLogger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        public static void LogToFile(string message, LogLevel logLevel)
        {
            Log(message, logLevel, _fileLogger);
        }
        public static void LogToConsole(string message, LogLevel logLevel)
        {
            Log(message, logLevel, _consoleLogger);
        }
        private static void Log(string message, LogLevel logLevel, ILogger logger)
        {
            switch (logLevel)
            {
                case LogLevel.Normal:
                    logger.Information(message);
                    break;
                case LogLevel.Warning:
                    logger.Warning(message);
                    break;
                case LogLevel.Trace:
                    logger.Debug(message);
                    break;
                case LogLevel.Error:
                    logger.Error(message);
                    break;
                case LogLevel.FatalError:
                    logger.Fatal(message);
                    break;
                default:
                    break;
            }
        }
    }
}
