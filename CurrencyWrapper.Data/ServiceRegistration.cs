using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWrapper.Data
{
    public static class ServiceRegistration
    {
        public static void AddCurrencyContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CurrencyContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CurrencyDbConnection"));
            });
        }
    }
}
