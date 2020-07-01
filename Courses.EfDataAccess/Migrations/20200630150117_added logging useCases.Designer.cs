﻿// <auto-generated />
using System;
using Courses.EfDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Courses.EfDataAccess.Migrations
{
    [DbContext(typeof(CoursesContext))]
    [Migration("20200630150117_added logging useCases")]
    partial class addedlogginguseCases
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Courses.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 12, 928, DateTimeKind.Local).AddTicks(2049),
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Operating Systems"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 129, DateTimeKind.Local).AddTicks(4156),
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Frontend"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 129, DateTimeKind.Local).AddTicks(4273),
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Backend"
                        });
                });

            modelBuilder.Entity("Courses.Domain.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("VideoLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 130, DateTimeKind.Local).AddTicks(4991),
                            Description = "Linux and UNIX operating systems have become increasingly popular in commercial computing environments. Due to their rapid growth in today's businesses, Linux/UNIX administrators have also become very much in-demand. This hands-on duo of courses will help you prepare for the CompTIA Linux+ and the Novell Certified Linux Professional certification exams, thus improving your chances of scoring a big income working with Linux.",
                            Duration = "2 hour 34 minutes",
                            Image = "linux.jpg",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Linux/UNIX Certification Training Bundle",
                            TeacherId = 3,
                            VideoLink = "https://www.youtube.com/watch?v=v_1zB2WNN14"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 131, DateTimeKind.Local).AddTicks(4042),
                            Description = "PHP and MySQL are two important tools used in web development, allowing you to create interactive content that integrates with databases to manage large amounts of data. Learning both will help you create login pages, check details from a form, create forums, restrict user access to certain pages, and much more. Your websites will have considerably more functionality, and you can leverage the knowledge you gain in this course into high-paying web development jobs.",
                            Duration = "4 hour 36 minutes",
                            Image = "php.jpg",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "PHP and MySQL",
                            TeacherId = 2,
                            VideoLink = "https://www.youtube.com/watch?v=OK_JCtrrv-c"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 131, DateTimeKind.Local).AddTicks(4272),
                            Description = "JavaScript is the language that powers the internet and if you want to build websites, you have to know JavaScript. This course delivers everything you need to get started with JavaScript and will help you build and apply 50 projects and challenges.",
                            Duration = "3 hour 26 minutes",
                            Image = "javaScript.jpg",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Complete Introduction to JavaScript",
                            TeacherId = 4,
                            VideoLink = "https://www.youtube.com/watch?v=PkZNo7MFNFg"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 131, DateTimeKind.Local).AddTicks(4295),
                            Description = "Windows Server 2016 is the most recent version of Microsoft's server technology, offering multiple benefits over previous versions, including better security, consistent identity management, built-in support for containers, deployment features for the cloud, and much more. It's the next-gen server for developers, and this course has been designed to help you understand all things Windows Server 2016.",
                            Duration = "1 hour 15 minutes",
                            Image = "windows.jpg",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Windows Server 2016",
                            TeacherId = 1,
                            VideoLink = "https://www.youtube.com/watch?v=hZ2QiiHyTnU"
                        });
                });

            modelBuilder.Entity("Courses.Domain.Entities.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoursId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CoursId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Lectures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CoursId = 1,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 131, DateTimeKind.Local).AddTicks(5864),
                            IsActive = false,
                            IsDeleted = false,
                            Title = "Mod 1: Instructions"
                        },
                        new
                        {
                            Id = 2,
                            CoursId = 1,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 131, DateTimeKind.Local).AddTicks(8800),
                            IsActive = false,
                            IsDeleted = false,
                            Title = "Mod 2: Managing Softwer"
                        },
                        new
                        {
                            Id = 3,
                            CoursId = 1,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 131, DateTimeKind.Local).AddTicks(8933),
                            IsActive = false,
                            IsDeleted = false,
                            Title = "Mod 3: Managing Files"
                        },
                        new
                        {
                            Id = 4,
                            CoursId = 1,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 131, DateTimeKind.Local).AddTicks(8953),
                            IsActive = false,
                            IsDeleted = false,
                            Title = "Mod 4: Managing Hardwer"
                        },
                        new
                        {
                            Id = 5,
                            CoursId = 2,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 131, DateTimeKind.Local).AddTicks(8965),
                            IsActive = false,
                            IsDeleted = false,
                            Title = "Section 1: Introduction"
                        },
                        new
                        {
                            Id = 6,
                            CoursId = 2,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 131, DateTimeKind.Local).AddTicks(8999),
                            IsActive = false,
                            IsDeleted = false,
                            Title = "Section 2: Important Concepts in PHP"
                        },
                        new
                        {
                            Id = 7,
                            CoursId = 2,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 131, DateTimeKind.Local).AddTicks(9008),
                            IsActive = false,
                            IsDeleted = false,
                            Title = "Section 3: Advanced Concepts in PHP"
                        },
                        new
                        {
                            Id = 8,
                            CoursId = 2,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 131, DateTimeKind.Local).AddTicks(9023),
                            IsActive = false,
                            IsDeleted = false,
                            Title = "Section 4: Expertise In PHP and MySQL"
                        },
                        new
                        {
                            Id = 9,
                            CoursId = 3,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 131, DateTimeKind.Local).AddTicks(9035),
                            IsActive = false,
                            IsDeleted = false,
                            Title = "Lecture 1: Core JavaScript introduction"
                        },
                        new
                        {
                            Id = 10,
                            CoursId = 3,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 131, DateTimeKind.Local).AddTicks(9049),
                            IsActive = false,
                            IsDeleted = false,
                            Title = "Lecture 2: JavaScript DOM and dynamic web pages with JavaScript"
                        },
                        new
                        {
                            Id = 11,
                            CoursId = 3,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 131, DateTimeKind.Local).AddTicks(9057),
                            IsActive = false,
                            IsDeleted = false,
                            Title = "Lecture 3: JavaScript Advanced and dynamic web applications"
                        },
                        new
                        {
                            Id = 12,
                            CoursId = 4,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 131, DateTimeKind.Local).AddTicks(9069),
                            IsActive = false,
                            IsDeleted = false,
                            Title = "Introduction to practical Windows system management"
                        },
                        new
                        {
                            Id = 13,
                            CoursId = 4,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 131, DateTimeKind.Local).AddTicks(9081),
                            IsActive = false,
                            IsDeleted = false,
                            Title = "Users and authentication in a Windows environment"
                        },
                        new
                        {
                            Id = 14,
                            CoursId = 4,
                            CreatedAt = new DateTime(2020, 6, 30, 17, 1, 13, 131, DateTimeKind.Local).AddTicks(9097),
                            IsActive = false,
                            IsDeleted = false,
                            Title = "Securing Windows in the enterprise"
                        });
                });

            modelBuilder.Entity("Courses.Domain.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Anna",
                            IsActive = false,
                            IsDeleted = false,
                            LastName = "Boss"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Michael",
                            IsActive = false,
                            IsDeleted = false,
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Stella",
                            IsActive = false,
                            IsDeleted = false,
                            LastName = "Williams"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Nick",
                            IsActive = false,
                            IsDeleted = false,
                            LastName = "Davis"
                        });
                });

            modelBuilder.Entity("Courses.Domain.Entities.UseCaseLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Actor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("UseCaseName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UseCaseLogs");
                });

            modelBuilder.Entity("Courses.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Courses.Domain.Entities.UserCourse", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCourse");
                });

            modelBuilder.Entity("Courses.Domain.Entities.UserUserCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UseCaseId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserUserCase");
                });

            modelBuilder.Entity("Courses.Domain.Entities.Course", b =>
                {
                    b.HasOne("Courses.Domain.Entities.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Courses.Domain.Entities.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Domain.Entities.Lecture", b =>
                {
                    b.HasOne("Courses.Domain.Entities.Course", "Course")
                        .WithMany("Lectures")
                        .HasForeignKey("CoursId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Domain.Entities.UserCourse", b =>
                {
                    b.HasOne("Courses.Domain.Entities.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Courses.Domain.Entities.User", "User")
                        .WithMany("UserCourses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Domain.Entities.UserUserCase", b =>
                {
                    b.HasOne("Courses.Domain.Entities.User", "User")
                        .WithMany("UserUserCases")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
