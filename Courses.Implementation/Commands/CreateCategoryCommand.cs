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
    public class CreateCategoryCommand : ICreateCategory
    {
        private readonly CoursesContext _context;
        private readonly CreateCategoryValidator _validator;
        private readonly IMapper _mapper;

        public CreateCategoryCommand(CoursesContext context, CreateCategoryValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }
        public int Id => 14;

        public string Name =>"Creating new category";

        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);
            var category = _mapper.Map<Category>(request);
            _context.Categories.Add(category);

            _context.SaveChanges();
        }
    }
}
