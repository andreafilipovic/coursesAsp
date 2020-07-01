using AutoMapper;
using Courses.Application;
using Courses.Application.DataTransfer;
using Courses.Application.Exceptions;
using Courses.Application.Queries;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Courses.Implementation.Queries
{
    public class GetOneCourseQuery : IGetOneCourseQuery
    {
        private readonly CoursesContext _context;
        private readonly IMapper _mapper;
        private readonly IApplicationActor actor;
        public GetOneCourseQuery(CoursesContext context, IMapper mapper, IApplicationActor actor) {
            _context = context;
            _mapper = mapper;
            this.actor = actor;
        }
        public int Id => 4;

        public string Name => "Get one course";

        public ReadCourseDto Execute(int search)
        {
            var sub = _context.UserCourse.Any(x => x.CourseId == search && x.UserId == actor.Id);
            if (!sub) {
                throw new NotSubscribedException(search);
            }
            var course = _context.Courses.Find(search);

            if (course == null)
            {
                throw new EntityNotFoundException(search, typeof(Course));
            }
            
            var bb = _context.Courses.Include(x => x.Lectures).FirstOrDefault(c => c.Id == search);

            return (_mapper.Map<Course, ReadCourseDto>(bb));
        }
    }
}
