using Courses.Application.DataTransfer;
using Courses.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses.Implementation.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<CategoryDto>
    {
        private readonly CoursesContext context;
            public UpdateCategoryValidator(CoursesContext context)
            {
                this.context = context;
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("Name is required parameter.")
                    .Must((dto, name) => !context.Categories.Any(p => p.Name == name && p.Id != dto.Id))
                    .WithMessage(p => $"Category with the name of {p.Name} already exists in database.");
            }
    }
}
