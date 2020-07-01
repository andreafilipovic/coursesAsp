﻿using AutoMapper;
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
        public GetOneCourseQuery(CoursesContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 4;

        public string Name => "Get one course";

        public ReadCourseDto Execute(int search)
        {
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
