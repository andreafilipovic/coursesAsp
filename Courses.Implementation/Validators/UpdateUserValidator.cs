using Courses.Application.DataTransfer;
using Courses.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses.Implementation.Validators
{
    public class UpdateUserValidator : AbstractValidator<UserDto>
    {
        private readonly CoursesContext context;
        public UpdateUserValidator(CoursesContext context)
        {
            this.context = context;
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required parameter.")
                .Must((dto, username) => !context.Users.Any(u => u.Username== username && u.Id != dto.Id))
                .WithMessage(u => $"User with the username of {u.Username} already exists in database.");

            RuleFor(x => x.FirstName)
              .NotEmpty()
              .WithMessage("First name is required");
            RuleFor(x => x.LastName)
               .NotEmpty()
               .WithMessage("Last name is required");
            RuleFor(x => x.Password)
              .NotEmpty()
              .WithMessage("Password is required");
            
            
        }
    }
}
