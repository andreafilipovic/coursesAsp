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
    public class UpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly CoursesContext _context;
        private readonly IMapper _mapper;
        private readonly UpdateCategoryValidator _validator;

        public UpdateCategoryCommand(CoursesContext context, IMapper mapper, UpdateCategoryValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public int Id => 15;

        public string Name => "Updating category";

        public void Execute(CategoryDto request)
        {
            var id = request.Id;
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                throw new EntityNotFoundException(id, typeof(CategoryDto));
            }

            _validator.ValidateAndThrow(request);
            _mapper.Map(request, category);
            _context.SaveChanges();
        }
    }
}
