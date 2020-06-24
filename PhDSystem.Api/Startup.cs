using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PhDSystem.Api.Managers;
using PhDSystem.Api.Services;
using PhDSystem.Core.Constants;
using PhDSystem.Core.Managers.Interfaces;
using PhDSystem.Core.Models;
using PhDSystem.Core.Services;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data;
using PhDSystem.Data.Repositories;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.IO;
using System.Text;

namespace PhDSystem.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddDbContextPool<PhdSystemDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("PhdSystemDb"));
            });

            JwtSettings settings = GetJwtSettings();
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

            services.AddAuthorization(config =>
            {
                config.AddPolicy("RequireAdminRole", p => p.RequireRole("Admin"));
                config.AddPolicy("RequireStudentRole", p => p.RequireRole("Student"));
                config.AddPolicy("RequireRequireTeacherRole", p => p.RequireRole("Teacher"));
            });

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IStudentFileRepository, StudentFileRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IProfessionalFieldRepository, ProfessionalFieldRepository>();
            services.AddScoped<IPhdProgramRepository, PhdProgramRepository>();
            services.AddScoped<IPhdFileDataRepository, PhdFileDataRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IStudentFileService, StudentFileService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IFileManager, FileManager>();
            services.AddScoped<IPhdFileService, PhdFileService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(options => options.WithOrigins("http://localhost:4200")
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Environment.CurrentDirectory, FileConstants.RootFolder)),
                RequestPath = new PathString($"/{FileConstants.RootFolder}")
            }); ;

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private JwtSettings GetJwtSettings()
        {
            JwtSettings settings = new JwtSettings();
            settings.Key = Configuration["JwtSettings:key"];
            settings.Audience = Configuration["JwtSettings:audience"];
            settings.Issuer = Configuration["JwtSettings:issuer"];
            settings.MinutesToExpiration = Convert.ToInt32(Configuration["JwtSettings:minutesToExpiration"]);

            return settings;
        }
    }
}
