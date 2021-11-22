using Lewy.Core.Interfaces;
using Lewy.Core.Services;
using Lewy.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LewyApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config )
        {
            services.AddScoped<ITokenService, TokenServices>();
            services.AddDbContext<LewyContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("LewyConnection"));
            });

            return services;
        }
    }
}
