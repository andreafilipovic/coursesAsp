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
    public class GetOneTeacherQuery : IGetOneTeacherQuery
    {
        private readonly CoursesContext _context;
        private readonly IMapper _mapper;
        public GetOneTeacherQuery(CoursesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 16;

        public string Name => "Get one teacher";

        public ReadTeacherDto Execute(int search)
        {
            var teacher = _context.Teachers.Find(search);
            if (teacher == null)
            {
                throw new EntityNotFoundException(search, typeof(Teacher));
            }
            var t = _context.Teachers.Include(x => x.Courses).FirstOrDefault(c => c.Id == search);
            return (_mapper.Map<Teacher, ReadTeacherDto>(t));
        }
    }
}
