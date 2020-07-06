using Microsoft.Extensions.DependencyInjection;
using PhDSystem.Data.Repositories;
using PhDSystem.Data.Repositories.Interfaces;

namespace PhDSystem.Api.Extensions
{
    public static class PhdSystemDataExtension
    {
        public static void AddDataConfig(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IStudentFileRepository, StudentFileRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IProfessionalFieldRepository, ProfessionalFieldRepository>();
            services.AddScoped<IPhdProgramRepository, PhdProgramRepository>();
            services.AddScoped<IPhdFileDataRepository, PhdFileDataRepository>();
            services.AddScoped<IUniversityRepository, UniversityRepository>();
            services.AddScoped<IFacultyRepository, FacultyRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IFormOfEducationRepository, FormOfEducationRepository>();
        }
    }
}
