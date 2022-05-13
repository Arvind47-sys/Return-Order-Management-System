using api.Mapper;
using api.Repository;
using api.Repository.IRepository;
using Api.BLOs;
using Api.Data;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IIntegralPartProcessingBLO, IntegralPartProcessingBLO>();
            services.AddScoped<IAccessoryPartProcessingBLO, AccessoryPartProcessingBLO>();
            services.AddScoped<ICompleteProcessingBLO, CompleteProcessingBLO>();
            services.AddAutoMapper(typeof(Mappings));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProcessRequestAndResponseRepository, ProcessRequestAndResponseRepository>();

            return services;
        }
    }
}