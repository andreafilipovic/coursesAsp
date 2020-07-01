using Courses.Domain.Entities;
using Courses.EfDataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses.EfDataAccess
{
    public class CoursesContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var categories = new List<Category> {
                new Category {
                    Id=1,
                    Name="Operating Systems",
                    CreatedAt=DateTime.Now
                },
                   new Category {
                    Id=2,
                    Name="Frontend",
                    CreatedAt=DateTime.Now
                },
                   new Category {
                    Id=3,
                    Name="Backend",
                    CreatedAt=DateTime.Now
                },

            };
            var teachers = new List<Teacher>{
                new Teacher{
                    Id=1,
                    FirstName="Anna",
                    LastName="Boss"
                },
                new Teacher{
                    Id=2,
                    FirstName="Michael",
                    LastName="Smith"
                },
                new Teacher{
                    Id=3,
                    FirstName="Stella",
                    LastName="Williams"
                },
                new Teacher{
                    Id=4,
                    FirstName="Nick",
                    LastName="Davis"
                }
            };

            var courses = new List<Course> {
                new Course{
                    Id=1,
                    CreatedAt=DateTime.Now,
                    Name="Linux/UNIX Certification Training Bundle",
                    Description="Linux and UNIX operating systems have become increasingly popular in commercial computing environments. Due to their rapid growth in today's businesses, Linux/UNIX administrators have also become very much in-demand. This hands-on duo of courses will help you prepare for the CompTIA Linux+ and the Novell Certified Linux Professional certification exams, thus improving your chances of scoring a big income working with Linux.",
                    Duration="2 hour 34 minutes" ,
                    VideoLink="https://www.youtube.com/watch?v=v_1zB2WNN14",
                    Image="linux.jpg",
                    TeacherId=3,
                    CategoryId=1
                },
                   new Course{
                    Id=2,
                    CreatedAt=DateTime.Now,
                    Name="PHP and MySQL",
                    Description="PHP and MySQL are two important tools used in web development, allowing you to create interactive content that integrates with databases to manage large amounts of data. Learning both will help you create login pages, check details from a form, create forums, restrict user access to certain pages, and much more. Your websites will have considerably more functionality, and you can leverage the knowledge you gain in this course into high-paying web development jobs.",
                    Duration="4 hour 36 minutes" ,
                    VideoLink="https://www.youtube.com/watch?v=OK_JCtrrv-c",
                    Image="php.jpg",
                    TeacherId=2,
                    CategoryId=3
                },
                    new Course{
                    Id=3,
                    CreatedAt=DateTime.Now,
                    Name="Complete Introduction to JavaScript",
                    Description="JavaScript is the language that powers the internet and if you want to build websites, you have to know JavaScript. This course delivers everything you need to get started with JavaScript and will help you build and apply 50 projects and challenges.",
                    Duration="3 hour 26 minutes" ,
                    VideoLink="https://www.youtube.com/watch?v=PkZNo7MFNFg",
                    Image="javaScript.jpg",
                    TeacherId=4,
                    CategoryId=2
                },
                    new Course{
                    Id=4,
                    CreatedAt=DateTime.Now,
                    Name="Windows Server 2016",
                    Description="Windows Server 2016 is the most recent version of Microsoft's server technology, offering multiple benefits over previous versions, including better security, consistent identity management, built-in support for containers, deployment features for the cloud, and much more. It's the next-gen server for developers, and this course has been designed to help you understand all things Windows Server 2016.",
                    Duration="1 hour 15 minutes" ,
                    VideoLink="https://www.youtube.com/watch?v=hZ2QiiHyTnU",
                    Image="windows.jpg",
                    TeacherId=1,
                    CategoryId=1
                }
                   
                

          };
            var users = new List<User> {
                new User{
                    Id=1,
                    CreatedAt=DateTime.Now,
                    FirstName="Pera",
                    LastName="Peric",
                    Username="perica",
                    Email="pera@gmail.com",
                    Password="sifra1"
                }
            };

            //var allow = new List<int>();
            var allowed = Enumerable.Range(1, 30).ToList();
            var cases = new List<UserUserCase>();
            foreach (var a in allowed) {
               cases.Add(new UserUserCase
                {
                    Id=a,
                    UserId = 1,
                    UseCaseId=a
                });
                
            }


            var lectures = new List<Lecture> {
                new Lecture {
                    Id=1,
                    CreatedAt=DateTime.Now,
                    Title="Mod 1: Instructions",
                    CoursId=1
                } ,
                    new Lecture {
                    Id=2,
                    CreatedAt=DateTime.Now,
                    Title="Mod 2: Managing Softwer",
                    CoursId=1
                } ,
                    new Lecture {
                    Id=3,
                    CreatedAt=DateTime.Now,
                    Title="Mod 3: Managing Files",
                    CoursId=1
                } ,
                    new Lecture {
                    Id=4,
                    CreatedAt=DateTime.Now,
                    Title="Mod 4: Managing Hardwer",
                    CoursId=1
                } ,
                    new Lecture {
                    Id=5,
                    CreatedAt=DateTime.Now,
                    Title="Section 1: Introduction",
                    CoursId=2
                } ,
                    new Lecture {
                    Id=6,
                    CreatedAt=DateTime.Now,
                    Title="Section 2: Important Concepts in PHP",
                    CoursId=2
                } ,
                    new Lecture {
                    Id=7,
                    CreatedAt=DateTime.Now,
                    Title="Section 3: Advanced Concepts in PHP",
                    CoursId=2
                } ,
                    new Lecture {
                    Id=8,
                    CreatedAt=DateTime.Now,
                    Title="Section 4: Expertise In PHP and MySQL",
                    CoursId=2
                } ,
                    new Lecture {
                    Id=9,
                    CreatedAt=DateTime.Now,
                    Title="Lecture 1: Core JavaScript introduction",
                    CoursId=3
                } ,
                    new Lecture {
                    Id=10,
                    CreatedAt=DateTime.Now,
                    Title="Lecture 2: JavaScript DOM and dynamic web pages with JavaScript",
                    CoursId=3
                } ,
                    new Lecture {
                    Id=11,
                    CreatedAt=DateTime.Now,
                    Title="Lecture 3: JavaScript Advanced and dynamic web applications",
                    CoursId=3
                } ,
                    new Lecture {
                    Id=12,
                    CreatedAt=DateTime.Now,
                    Title="Introduction to practical Windows system management",
                    CoursId=4
                } ,
                    new Lecture {
                    Id=13,
                    CreatedAt=DateTime.Now,
                    Title="Users and authentication in a Windows environment",
                    CoursId=4
                } ,
                    new Lecture {
                    Id=14,
                    CreatedAt=DateTime.Now,
                    Title="Securing Windows in the enterprise",
                    CoursId=4
                } ,
            };

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Teacher>().HasData(teachers);
            modelBuilder.Entity<Course>().HasData(courses);
            modelBuilder.Entity<Lecture>().HasData(lectures);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<UserUserCase>().HasData(cases);
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new LectureConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<Course>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Teacher>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Lecture>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<UserCourse>().HasKey(x => new { x.CourseId, x.UserId });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=CoursesAsp;Integrated Security=True");
            
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {

                if (entry.Entity is Entity e)
                {

                    switch (entry.State)
                    {

                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.Now;
                            e.IsDeleted = false;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<UserCourse> UserCourse { get; set; }
        public DbSet<UserUserCase> UserUserCase { get; set; }


    }
}
