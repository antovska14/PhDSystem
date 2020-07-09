using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using PhDSystem.Api.Extensions;
using PhDSystem.Core.Constants;
using PhDSystem.Core.Models;
using PhDSystem.Data;
using System;
using System.IO;

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
            services.AddLogging();
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddDbContextPool<PhdSystemDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("PhdSystemDb"));
            });

            services.AddAuthorizationConfig();
            services.AddAuthenticationConfig(Configuration);

            var smtp = Configuration.GetSection("Smtp").Get<SmtpConfig>();
            services.AddSingleton(smtp);

            services.AddDataConfig();
            services.AddCoreConfig();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseErrorHandlingMiddleware();

            app.UseRouting();
            app.UseCors(options => options.AllowAnyOrigin()
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Environment.CurrentDirectory, FileConstants.RootFolder)),
                RequestPath = new PathString($"/{FileConstants.RootFolder}")
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
