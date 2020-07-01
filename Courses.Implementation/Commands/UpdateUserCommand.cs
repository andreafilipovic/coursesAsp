using AutoMapper;
using Courses.Application.Commands;
using Courses.Application.DataTransfer;
using Courses.Application.Exceptions;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using Courses.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Implementation.Commands
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly CoursesContext _context;
        private readonly IMapper _mapper;
        private readonly UpdateUserValidator _validator;

        public UpdateUserCommand(CoursesContext context, IMapper mapper, UpdateUserValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public int Id => 9;

        public string Name => "Update user";

        public void Execute(UserDto request)
        {
            var id = request.Id;
            var user = _context.Users.Find(id);

            if (user == null)
            {
                throw new EntityNotFoundException(id, typeof(UserDto));
            }

            _validator.ValidateAndThrow(request);
            _mapper.Map(request, user);
            _context.SaveChanges();
        }
    }
}
