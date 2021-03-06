﻿using Microsoft.Extensions.DependencyInjection;
using PhDSystem.Api.Managers;
using PhDSystem.Core.Clients;
using PhDSystem.Core.Clients.Interfaces;
using PhDSystem.Core.Managers.Interfaces;
using PhDSystem.Core.Services;
using PhDSystem.Core.Services.Interfaces;

namespace PhDSystem.Api.Extensions
{
    public static class PhdSystemCoreExtension
    {
        public static void AddCoreConfig(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IPhdFileService, PhdFileService>();
            services.AddScoped<IStudentFileService, StudentFileService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IEmailClient, EmailClient>();
            services.AddScoped<IFileManager, FileManager>();
        }
    }
}
