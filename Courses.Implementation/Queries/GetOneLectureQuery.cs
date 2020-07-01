using AutoMapper;
using Courses.Application.DataTransfer;
using Courses.Application.Exceptions;
using Courses.Application.Queries;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Implementation.Queries
{
    public class GetOneLectureQuery : IGetOneLectureQuery
    {
        private readonly CoursesContext _context;
        private readonly IMapper _mapper;
        public GetOneLectureQuery(CoursesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 22;

        public string Name => "Get one lecture";

        public LectureDto Execute(int search)
        {
            var lecture = _context.Lectures.Find(search);
            if (lecture == null)
            {
                throw new EntityNotFoundException(search, typeof(Lecture));
            }
            return (_mapper.Map<Lecture, LectureDto>(lecture));
        }
    }
}
