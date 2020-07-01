using Courses.Application.DataTransfer;
using Courses.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses.Implementation.Validators
{
    public class UpdateLectureValidator : AbstractValidator<LectureDto>
    {
        private readonly CoursesContext context;
        public UpdateLectureValidator(CoursesContext context)
        {
            this.context = context;
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Titile is required parameter.")
                .Must((dto, title) => !context.Lectures.Any(p => p.Title == title && p.Id != dto.Id))
                .WithMessage(p => $"Lecture with the name of {p.Title} already exists in database.");
            RuleFor(x => x.CoursId)
              .NotEmpty()
              .WithMessage("Lecture must belong to a course")
              .Must(CourseExists)
              .WithMessage("Cours doesn't exists");
        }
        private bool CourseExists(int courseId)
        {
            return context.Courses.Any(x => x.Id == courseId);
        }
    }
}
