using Courses.Application.DataTransfer;
using Courses.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses.Implementation.Validators
{
    public class CreateUserValidator : AbstractValidator<UserDto>
    {
        private readonly CoursesContext _context;
        public CreateUserValidator(CoursesContext context)
        {
            _context = context;

            RuleFor(x => x.FirstName)
               .NotEmpty()
               .WithMessage("First name is required parameter.");

            RuleFor(x => x.LastName)
               .NotEmpty()
               .WithMessage("Last name is required parameter.");

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required parameter")
                .Must(username => !context.Users.Any(u => u.Username == username))
                .WithMessage(u => $"Course with the name of {u.Username} already exists in database.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(6);

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required parameter")
                .EmailAddress()
                .Must(email => !context.Users.Any(u => u.Email == email))
                .WithMessage(u => $"User with the email  {u.Email} already exists in database.");


        }
    }
}
