using Courses.Application.Commands;
using Courses.Application.Exceptions;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Implementation.Commands
{
    public class DeleteCourseCommand : IDeleteCourseCommand
    {
        private readonly CoursesContext _context;
        public DeleteCourseCommand(CoursesContext context) {
            _context = context;
        }
        public int Id => 2;

        public string Name => "Delete course";

        public void Execute(int request)
        {
            var course = _context.Courses.Find(request);

            if (course == null)
            {
                throw new EntityNotFoundException(request, typeof(Course));
            }

            course.IsDeleted = true;
            course.IsActive = false;
            course.DeletedAt = DateTime.Now;
           // _context.Courses.Remove(course);

            _context.SaveChanges();
        }
    }
}
