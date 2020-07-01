using AutoMapper;
using Courses.Application.Commands;
using Courses.Application.DataTransfer;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using Courses.Implementation.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Implementation.Commands
{
    public class CreateCourseCommand : ICreateCourseCommand
    {
        private readonly CoursesContext _context;
        private readonly CreateCourseValidator _validator;
        private readonly IMapper _mapper;

        public CreateCourseCommand(CoursesContext context, CreateCourseValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }
        public int Id => 1;

        public string Name => "Create new Course";

        public void Execute(CourseDto request)
        {
            _validator.ValidateAndThrow(request);
            var course = _mapper.Map<Course>(request);
            _context.Courses.Add(course);
           
            _context.SaveChanges();
        }
    }
}


