using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Configuration;
using PhDSystem.Data.Entities;
using System;

namespace PhDSystem.Data
{
    public class PhdSystemDbContext : DbContext
    {
        public PhdSystemDbContext(DbContextOptions<PhdSystemDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentTeacher>().HasKey(st => new { st.StudentId, st.TeacherId });
            modelBuilder.Entity<StudentTeacher>()
                .HasOne<Student>(st => st.Student)
                .WithMany(s => s.StudentTeachers)
                .HasForeignKey(st => st.StudentId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<StudentTeacher>()
                .HasOne<Teacher>(st => st.Teacher)
                .WithMany(t => t.StudentTeachers)
                .HasForeignKey(st => st.TeacherId);

            modelBuilder.Entity<Teacher>().HasIndex(t => t.UserId).IsUnique();
            modelBuilder.Entity<Student>().HasIndex(s => s.UserId).IsUnique();


            modelBuilder.ApplyConfiguration(new FormOfEducationConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UniversityConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessionalFieldConfiguration());

            //modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new FacultyConfiguration());
            modelBuilder.ApplyConfiguration(new PhdProgramConfiguration());

            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

            //modelBuilder.ApplyConfiguration(new StudentConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<University> Universities { get; set; }

        public virtual DbSet<Faculty> Faculties { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<StudentTeacher> StudentTeachers { get; set; }

        public virtual DbSet<FormOfEducation> FormsOfEducation { get; set; }

        public virtual DbSet<PhdProgram> PhdPrograms { get; set; }

        public virtual DbSet<ProfessionalField> ProfessionalFields { get; set; }

        public virtual DbSet<StudentFile> StudentFiles { get; set; }

        public virtual DbSet<Exam> Exams { get; set; }
    }
}
