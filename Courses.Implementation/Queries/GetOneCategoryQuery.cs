using AutoMapper;
using Courses.Application.DataTransfer;
using Courses.Application.Exceptions;
using Courses.Application.Queries;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses.Implementation.Queries
{
    public class GetOneCategoryQuery : IGetOneCategoryQuery
    {
        private readonly CoursesContext _context;
        private readonly IMapper _mapper;
        public GetOneCategoryQuery(CoursesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 11;

        public string Name => "Get one category";

        public ReadCategoryDto Execute(int search)
        {
            var category = _context.Categories.Find(search);
            if (category == null)
            {
                throw new EntityNotFoundException(search, typeof(Category));
            }
            var cat= _context.Categories.Include(x => x.Courses).FirstOrDefault(c => c.Id == search);
            return (_mapper.Map<Category, ReadCategoryDto>(cat));
        }
    }
}
