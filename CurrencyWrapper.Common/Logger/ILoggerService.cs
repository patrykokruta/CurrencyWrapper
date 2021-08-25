using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWrapper.Common.Logger
{
    public interface ILoggerService
    {
        void Log(string message, LogLevel logLevel = LogLevel.Normal, bool withConsoleOutput = true);
    }
}
