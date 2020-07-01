using Courses.Application.Commands;
using Courses.Application.Exceptions;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Implementation.Commands
{
    public class DeleteLectureCommand : IDeleteLectureCommand
    {
        private readonly CoursesContext _context;
        public DeleteLectureCommand(CoursesContext context)
        {
            _context = context;
        }
        public int Id => 23;

        public string Name => "Deleting lecture";

        public void Execute(int request)
        {
            var lecture = _context.Lectures.Find(request);

            if (lecture == null)
            {
                throw new EntityNotFoundException(request, typeof(Lecture));
            }

            lecture.IsDeleted = true;
            lecture.IsActive = false;
            lecture.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
