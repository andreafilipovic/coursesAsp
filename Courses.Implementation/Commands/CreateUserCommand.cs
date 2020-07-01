using AutoMapper;
using Courses.Application;
using Courses.Application.Commands;
using Courses.Application.DataTransfer;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using Courses.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Implementation.Commands
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly CoursesContext _context;
        private readonly CreateUserValidator _validator;
        private readonly IMapper _mapper;

        public CreateUserCommand(CoursesContext context, CreateUserValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }
        public int Id => 8;

        public string Name => "Create new user";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);
            var user = _mapper.Map<User>(request);
            _context.Users.Add(user);

            _context.SaveChanges();
        }
    }
}
