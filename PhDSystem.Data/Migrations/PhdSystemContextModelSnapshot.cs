﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhDSystem.Data;

namespace PhDSystem.Data.Migrations
{
    [DbContext(typeof(PhdSystemDbContext))]
    partial class PhdSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhDSystem.Data.Entities.FormOfEducation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FormOfEducation");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "редовна",
                            YearsCount = 3
                        },
                        new
                        {
                            Id = 2,
                            Name = "задочна",
                            YearsCount = 4
                        },
                        new
                        {
                            Id = 3,
                            Name = "свободна",
                            YearsCount = 3
                        });
                });

            modelBuilder.Entity("PhDSystem.Data.Entities.PhdProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfessionalFieldId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessionalFieldId");

                    b.ToTable("PhdProgram");
                });

            modelBuilder.Entity("PhDSystem.Data.Entities.ProfessionalField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("ProfessionalField");
                });

            modelBuilder.Entity("PhDSystem.Data.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentYear")
                        .HasColumnType("int");

                    b.Property<DateTime>("FacultyCouncilChosenDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("FormOfEducationId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("SpecialtyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormOfEducationId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Student");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentYear = 0,
                            FacultyCouncilChosenDate = new DateTime(2020, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            FirstName = "Dijana",
                            FormOfEducationId = 1,
                            IsDeleted = false,
                            LastName = "Antovska",
                            SpecialtyName = "Computer and Software Engineering",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("PhDSystem.Data.Entities.StudentTeacher", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("StudentTeacher");
                });

            modelBuilder.Entity("PhDSystem.Data.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teacher");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Bill",
                            IsDeleted = false,
                            LastName = "Gates",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("PhDSystem.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@gmail.com",
                            IsDeleted = false,
                            Password = "admin",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "student@gmail.com",
                            IsDeleted = false,
                            Password = "student",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            Email = "supervisor@gmail.com",
                            IsDeleted = false,
                            Password = "supervisor",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("PhDSystem.Data.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Student"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Supervisor"
                        });
                });

            modelBuilder.Entity("PhDSystem.Data.Entities.PhdProgram", b =>
                {
                    b.HasOne("PhDSystem.Data.Entities.ProfessionalField", "ProfessionalField")
                        .WithMany("PhdPrograms")
                        .HasForeignKey("ProfessionalFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PhDSystem.Data.Entities.Student", b =>
                {
                    b.HasOne("PhDSystem.Data.Entities.FormOfEducation", "FormOfEducation")
                        .WithMany("Students")
                        .HasForeignKey("FormOfEducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PhDSystem.Data.Entities.StudentTeacher", b =>
                {
                    b.HasOne("PhDSystem.Data.Entities.Student", "Student")
                        .WithMany("StudentTeachers")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PhDSystem.Data.Entities.Teacher", "Teacher")
                        .WithMany("StudentTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PhDSystem.Data.Entities.User", b =>
                {
                    b.HasOne("PhDSystem.Data.Entities.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
