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
    public class CreateLectureCommand : ICreateLectureCommand
    {
        private readonly CoursesContext _context;
        private readonly CreateLectureValidator _validator;
        private readonly IMapper _mapper;

        public CreateLectureCommand(CoursesContext context, CreateLectureValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }
        public int Id => 24;

        public string Name => "Create new lecture";

        public void Execute(LectureDto request)
        {
            _validator.ValidateAndThrow(request);
            var lecture = _mapper.Map<Lecture>(request);
            _context.Lectures.Add(lecture);
            _context.SaveChanges();
        }
    }
}
