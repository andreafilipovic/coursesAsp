using AutoMapper;
using Courses.Application.DataTransfer;
using Courses.Application.Queries;
using Courses.Application.Searches;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses.Implementation.Queries
{
    public class GetTeachersQuery : IGetTeachersQuery
    {
        private readonly CoursesContext context;
        private readonly IMapper mapper;

        public GetTeachersQuery(CoursesContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 17;

        public string Name => "Search teacher";

        public PagedResponse<TeacherDto> Execute(TeacherSearch search)
        {
            var query = context.Teachers.AsQueryable();

            if (!string.IsNullOrEmpty(search.FirstName) || !string.IsNullOrWhiteSpace(search.FirstName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.LastName) || !string.IsNullOrWhiteSpace(search.LastName))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);


            var reponse = new PagedResponse<TeacherDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).AsEnumerable().Select(item => mapper.Map<Teacher, TeacherDto>(item)).ToList()
                /*Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new TeacherDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).ToList()*/
            };
           // 
            return reponse;
        }
    }
}
