using Courses.Application.DataTransfer;
using Courses.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses.Implementation.Validators
{
    public class CreateTeacherValidator : AbstractValidator<TeacherDto>
    {
        private readonly CoursesContext context;
        public CreateTeacherValidator(CoursesContext context)
        {
            this.context = context;

            RuleFor(x => x.FirstName)
               .NotEmpty()
               .WithMessage("First name is required parameter.");
            //.Must(firsName => !context.Teachers.Any(c => c.FirstName == firsName))
            //.WithMessage(c => $"Teacher with the name of {c.FirstName} already exists in database.");

            RuleFor(x => x.LastName)
             .NotEmpty()
             .WithMessage("Last name is required parameter.");
        }
    }
}
