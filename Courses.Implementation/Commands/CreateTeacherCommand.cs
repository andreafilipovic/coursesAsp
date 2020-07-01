using AutoMapper;
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
    public class CreateTeacherCommand : ICreateTeacherCommand
    {
        private readonly CoursesContext _context;
        private readonly CreateTeacherValidator _validator;
        private readonly IMapper _mapper;

        public CreateTeacherCommand(CoursesContext context, CreateTeacherValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }
        public int Id => 18;

        public string Name => "Create new teacher";

        public void Execute(TeacherDto request)
        {
            _validator.ValidateAndThrow(request);
            var teacher = _mapper.Map<Teacher>(request);
            _context.Teachers.Add(teacher);

            _context.SaveChanges();
        }
    }
}
