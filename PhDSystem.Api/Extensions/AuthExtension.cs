using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PhDSystem.Api.Models;
using PhDSystem.Api.Services;
using PhDSystem.Api.Services.Interfaces;
using System;
using System.Text;

namespace PhDSystem.Api.Extensions
{
    public static class AuthExtension
    {
        public static void AddAuthorizationConfig(this IServiceCollection services)
        {
            services.AddAuthorization(config =>
            {
                config.AddPolicy("RequireAdminRole", p => p.RequireRole("Admin"));
                config.AddPolicy("RequireStudentRole", p => p.RequireRole("Student"));
                config.AddPolicy("RequireRequireTeacherRole", p => p.RequireRole("Teacher"));
            });
        }

        public static void AddAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSettings settings = GetJwtSettings(configuration);
            services.AddSingleton<JwtSettings>(settings);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters =
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key)),
                    ValidateIssuer = true,
                    ValidIssuer = settings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = settings.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(settings.MinutesToExpiration)
                };
            });

            services.AddScoped<IAuthService, AuthService>();
        }

        private static JwtSettings GetJwtSettings(IConfiguration configuration)
        {
            JwtSettings settings = new JwtSettings
            {
                Key = configuration["JwtSettings:key"],
                Audience = configuration["JwtSettings:audience"],
                Issuer = configuration["JwtSettings:issuer"],
                MinutesToExpiration = Convert.ToInt32(configuration["JwtSettings:minutesToExpiration"])
            };

            return settings;
        }
    }
}
