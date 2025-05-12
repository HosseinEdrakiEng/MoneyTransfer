using Application.Abstraction;
using Application.Abstraction.IService;
using Application.Common;
using Infrastructure.Persistence;
using Infrastructure.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureOption(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JibitConfig>(configuration.GetSection("JibitConfig"));
            services.Configure<SsoConfig>(configuration.GetSection("SsoConfig"));
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
            return services;
        }

        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IJibitService, JibitService>();
            return services;
        }

        public static IServiceCollection AddProviderHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            var jibitConfig = configuration.GetSection("JibitConfig").Get<JibitConfig>();
            services.AddHttpClient("Notification", o =>
            {
                o.BaseAddress = new Uri(jibitConfig.BaseUrl);
                o.Timeout = jibitConfig.Timeout;
            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                }
            }).SetHandlerLifetime(TimeSpan.FromMinutes(10));

            return services;
        }

        public static IServiceCollection AddSsoConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var ssoConfig = configuration.GetSection("SsoConfig").Get<SsoConfig>();

            var publicKeyBytes = Convert.FromBase64String(ssoConfig.PublicKey);
            var rsa = RSA.Create();
            rsa.ImportSubjectPublicKeyInfo(publicKeyBytes, out int _);
            var rsaSecurityKey = new RsaSecurityKey(rsa);

            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
                {
                    o.MetadataAddress = ssoConfig.MetadataAddress;
                    o.Authority = ssoConfig.Authority;
                    o.RequireHttpsMetadata = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidIssuer = ssoConfig.ValidIssuer,
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        IssuerSigningKey = rsaSecurityKey,
                        ValidateLifetime = true,
                    };
                });

            return services;
        }
    }
}
