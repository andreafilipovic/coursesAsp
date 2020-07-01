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
    public class GetLecturesQuery : IGetLecturesQuery
    {
        private readonly CoursesContext context;
        private readonly IMapper mapper;

        public GetLecturesQuery(CoursesContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 21;

        public string Name => "Search lectures";

        public PagedResponse<LectureDto> Execute(LectureSearch search)
        {
            var query = context.Lectures.AsQueryable();

            if (!string.IsNullOrEmpty(search.Title) || !string.IsNullOrWhiteSpace(search.Title))
            {
                query = query.Where(x => x.Title.ToLower().Contains(search.Title.ToLower()));
            }

            if (search.CourseId > 0)
            {
                query = query.Where(x => x.CoursId == search.CourseId);
            }

            var skipCount = search.PerPage * (search.Page - 1);

            
            var reponse = new PagedResponse<LectureDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).AsEnumerable().Select(item => mapper.Map<Lecture, LectureDto>(item)).ToList()
                /*Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new LectureDto
                {
                    Id = x.Id,
                    CoursId = x.CoursId,
                    Title=x.Title
                }).ToList()*/
            };
            
            return reponse;
        }
    }
}
