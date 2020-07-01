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
    public class UpdateLectureCommand : IUpdateLectureCommand
    {
        private readonly CoursesContext _context;
        private readonly IMapper _mapper;
        private readonly UpdateLectureValidator _validator;

        public UpdateLectureCommand(CoursesContext context, IMapper mapper, UpdateLectureValidator validator)
        {

            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public int Id => 25;

        public string Name => "Update lecture";

        public void Execute(LectureDto request)
        {
            var id = request.Id;
            var lecture = _context.Lectures.Find(id);

            if (lecture == null)
            {
                throw new EntityNotFoundException(id, typeof(LectureDto));
            }

            _validator.ValidateAndThrow(request);
            _mapper.Map(request, lecture);
            _context.SaveChanges();
        }
    }
}
