using Courses.Application.DataTransfer;
using Courses.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses.Implementation.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        private readonly CoursesContext context;
        public CreateCategoryValidator(CoursesContext context)
        {
            this.context = context;

            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage("Name is required parameter.")
               .Must(name => !context.Categories.Any(c => c.Name == name))
               .WithMessage(c => $"Category with the name of {c.Name} already exists in database.");

            
        }
    }
}
