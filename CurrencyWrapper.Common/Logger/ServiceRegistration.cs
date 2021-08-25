using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWrapper.Common.Logger
{
    public static class ServiceRegistration
    {
        public static void AddLogger(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerService>();
        }
    }
}
