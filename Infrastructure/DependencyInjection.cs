using Application.Abstraction;
using Application.Abstraction.IRepository;
using Application.Abstraction.IService;
using Application.Common;
using Infrastructure.Persistence;
using Infrastructure.Repository;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureOption(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JibitConfig>(configuration.GetSection("JibitConfig"));
            services.Configure<SsoConfig>(configuration.GetSection("SsoConfig"));
            services.Configure<HangfireConfig>(configuration.GetSection("HangfireConfig"));
            return services;
        }

        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MoneyTransferDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MoneyTransferDbContext")));

            services.AddScoped<IMoneyTransferDbContext, MoneyTransferDbContext>();

            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ITransferDetailRepository, TransferDetailRepository>();
            services.AddScoped<ITransferRepository, TransferRepository>();
            return services;
        }

        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IJibitService, JibitService>();
            services.AddScoped<IHangfireService, HangfireService>();
            services.AddScoped<ITransferService, TransferService>();
            return services;
        }
    }
}
