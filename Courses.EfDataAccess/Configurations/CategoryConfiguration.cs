using Courses.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.EfDataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.HasMany(ca => ca.Courses)
                    .WithOne(cu => cu.Category)
                    .HasForeignKey(cu => cu.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
