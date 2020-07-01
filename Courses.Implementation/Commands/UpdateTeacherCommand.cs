using AutoMapper;
using Courses.Application.Commands;
using Courses.Application.DataTransfer;
using Courses.Application.Exceptions;
using Courses.EfDataAccess;
using Courses.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Implementation.Commands
{
    public class UpdateTeacherCommand : IUpdateTeacherCommand
    {
        private readonly CoursesContext _context;
        private readonly IMapper _mapper;
        private readonly CreateTeacherValidator _validator;

        public UpdateTeacherCommand(CoursesContext context, IMapper mapper, CreateTeacherValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public int Id => 19;

        public string Name => "Update teacher";

        public void Execute(TeacherDto request)
        {
            var id = request.Id;
            var teacher = _context.Teachers.Find(id);

            if (teacher == null)
            {
                throw new EntityNotFoundException(id, typeof(TeacherDto));
            }

            _validator.ValidateAndThrow(request);
            _mapper.Map(request, teacher);
            _context.SaveChanges();
        }
    }
}
