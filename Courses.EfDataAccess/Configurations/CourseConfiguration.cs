using Courses.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.EfDataAccess.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
       

        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.VideoLink).IsRequired();
           // builder.Property(x => x.Image).IsRequired();


            builder.HasMany(c => c.Lectures)
                    .WithOne(l => l.Course)
                    .HasForeignKey(l => l.CoursId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.UserCourses)
                   .WithOne(uc => uc.Course)
                   .HasForeignKey(uc => uc.CourseId);
        }
    }
}
