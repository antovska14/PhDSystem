using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Models;

namespace PhDSystem.Data
{
    public class PhdSystemContext : DbContext
    {
        public PhdSystemContext(DbContextOptions<PhdSystemContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentTeacher>().HasKey(st => new { st.StudentId, st.TeacherId });
            modelBuilder.Entity<StudentTeacher>()
                .HasOne<Student>(st => st.Student)
                .WithMany(s => s.StudentTeachers)
                .HasForeignKey(st => st.StudentId);
            modelBuilder.Entity<StudentTeacher>()
                .HasOne<Teacher>(st => st.Teacher)
                .WithMany(t => t.StudentTeachers)
                .HasForeignKey(st => st.TeacherId);

            modelBuilder.Entity<UserRole>()
                .HasData(
                    new UserRole() { Id = 1, Name = "Admin" },
                    new UserRole() { Id = 2, Name = "Student" },
                    new UserRole() { Id = 3, Name = "Supervisor" }
                );

            modelBuilder.Entity<User>()
                .HasData(
                    new User() { Id = 1, Username = "admin", Password = "admin", RoleId = 1 },
                    new User() { Id = 2, Username = "student", Password = "student", RoleId = 2 },
                    new User() { Id = 3, Username = "supervisor", Password = "supervisor", RoleId = 3 }
                );

            modelBuilder.Entity<Student>().HasIndex(s => s.UserId).IsUnique();
            modelBuilder.Entity<Student>()
                .HasData(
                    new Student() { Id = 1, FirstName = "Dijana", LastName = "Antovska", UserId = 2 }
                );

            modelBuilder.Entity<Student>().HasIndex(t => t.UserId).IsUnique();
            modelBuilder.Entity<Teacher>()
                .HasData(
                    new Teacher() { Id = 1, FirstName = "Bill", LastName = "Gates", UserId = 3 }
                );

            modelBuilder.Entity<FormOfEducation>()
                .HasData(
                    new FormOfEducation() { Id = 1, Name = "Regular", YearsCount = 3 },
                    new FormOfEducation() { Id = 2, Name = "Distance", YearsCount = 4 },
                    new FormOfEducation() { Id = 3, Name = "Free", YearsCount = 3 }
                );

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<StudentTeacher> StudentTeachers { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<FormOfEducation> FormsOfEducation { get; set; }
    }
}
