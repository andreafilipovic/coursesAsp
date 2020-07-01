using Courses.Application.DataTransfer;
using Courses.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses.Implementation.Validators
{
    public class UpdateCourseValidator : AbstractValidator<CourseDto>
    {
        private readonly CoursesContext context;
        public UpdateCourseValidator(CoursesContext context)
        {
            this.context = context;
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter.")
                .Must((dto, name) => !context.Courses.Any(p => p.Name == name && p.Id != dto.Id))
                .WithMessage(p => $"Course with the name of {p.Name} already exists in database.");

            RuleFor(x => x.Description)
              .NotEmpty()
              .WithMessage("Description is required");
            RuleFor(x => x.VideoLink)
               .NotEmpty()
               .WithMessage("Video link is required");
            RuleFor(x => x.Image)
              .NotEmpty()
              .WithMessage("Image is required");
            RuleFor(x => x.Duration)
              .NotEmpty()
              .WithMessage("Duration is required");
            RuleFor(x => x.CategoryId)
              .NotEmpty()
              .WithMessage("Course must have a category")
              .Must(CategoryExists)
              .WithMessage("Categorie doesn't exists");
            RuleFor(x => x.TeacherId)
            .NotEmpty()
            .WithMessage("Course must have a teacher")
            .Must(TeacherExists)
            .WithMessage("Teacher doesn't exists");
        }

        private bool CategoryExists(int cateegoryId)
        {
            return context.Categories.Any(x => x.Id == cateegoryId);
        }

        private bool TeacherExists(int teacherId)
        {
            return context.Categories.Any(x => x.Id == teacherId);
        }
    }
}
