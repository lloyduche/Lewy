using Lewy.Core;
using Lewy.Core.Interfaces;
using Lewy.Core.Services;
using Lewy.Infrastructure;
using LewyApi.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LewyApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config )
        {
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<ITokenService, TokenServices>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(AutoMappersProfiles).Assembly);
            services.AddDbContext<LewyContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("LewyConnection"));
            });

            return services;
        }
    }
}
