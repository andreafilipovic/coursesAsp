using Courses.Application.DataTransfer;
using Courses.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses.Implementation.Validators
{
    public class CreateLectureValidator : AbstractValidator<LectureDto>
    {
        private readonly CoursesContext context;
        public CreateLectureValidator(CoursesContext context) {

            this.context = context;
            RuleFor(x => x.Title)
               .NotEmpty()
               .WithMessage("Title is required parameter.")
               .Must(title => !context.Lectures.Any(c => c.Title == title))
               .WithMessage(c => $"Lecture with the name of {c.Title} already exists in database.");
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
