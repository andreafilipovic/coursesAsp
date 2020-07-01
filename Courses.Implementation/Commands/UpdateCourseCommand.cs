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
    public class UpdateCourseCommand : IUpdateCourseCommand
    {
        private readonly CoursesContext _context;
        private readonly IMapper _mapper;
        private readonly UpdateCourseValidator _validator;

        public UpdateCourseCommand(CoursesContext context, IMapper mapper,UpdateCourseValidator validator) {

            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public int Id => 5;

        public string Name => "Update course";

        public void Execute(CourseDto request)
        {
            var id = request.Id;
            var course = _context.Courses.Find(id);

            if (course == null)
            {
                throw new EntityNotFoundException(id,typeof(CourseDto));
            }

            _validator.ValidateAndThrow(request);
            _mapper.Map(request, course);
            _context.SaveChanges();

           
        }
    }
}
