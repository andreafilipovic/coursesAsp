using AutoMapper;
using Courses.Application.DataTransfer;
using Courses.Application.Queries;
using Courses.Application.Searches;
using Courses.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses.Implementation.Queries
{
    public class GetCategoriesQuery : IGetCategoriesQuery
    {
        private readonly CoursesContext context;
        private readonly IMapper _mapper;

        public GetCategoriesQuery(CoursesContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }
        public int Id => 12;

        public string Name => "Search categories";

        public PagedResponse<ReadCategoryDto> Execute(CategorySearch search)
        {
            var query = context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            var skipCount = search.PerPage * (search.Page - 1);
            var reponse = new PagedResponse<ReadCategoryDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new ReadCategoryDto
                {
                    Id=x.Id,
                    Name=x.Name,
                    Courses=x.Courses.Select(c => new ReadCourseDetailsDto
                    { 
                        Name=c.Name,
                        Id=c.Id
                    })}).ToList()
            };
            return reponse;
        }
    }
}
