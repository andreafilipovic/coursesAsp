using AutoMapper;
using Courses.Application.Commands;
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
    public class GetCourseQuery : IGetCourseQuery
    {
        private readonly CoursesContext context;
        private readonly IMapper mapper;

        public GetCourseQuery(CoursesContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 3;

        public string Name => "Search courses";

        public PagedResponse<CourseDto> Execute(CourseSearch search)
        {
            var query = context.Courses.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

           if (search.CategoryId > 0) {
               query = query.Where(x => x.CategoryId == search.CategoryId);
           }

            var skipCount = search.PerPage * (search.Page - 1);

            //Page == 1 
            var reponse = new PagedResponse<CourseDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).AsEnumerable().Select(item => mapper.Map<Course, CourseDto>(item)).ToList()
            /* Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new CourseDto
             {
                 Id = x.Id,
                 Name = x.Name,
                 Description = x.Description,
                 VideoLink = x.VideoLink,
                 Image = x.Image,
                 CategoryId = x.CategoryId,
                 Duration = x.Duration,
                 TeacherId = x.TeacherId,


                 //Lectures=x.Lectures,
                 //UserCourses=x.UserCourses


             //}).ToList()*/




        };
           // var result = mapper.Map<IEnumerable<ReadOrderDto>>(orders.ToList());
            return reponse;
        }
    }
}
