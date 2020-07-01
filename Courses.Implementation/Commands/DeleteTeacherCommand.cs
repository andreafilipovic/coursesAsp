using Courses.Application.Commands;
using Courses.Application.Exceptions;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Implementation.Commands
{
    public class DeleteTeacherCommand : IDeleteTeacherCommand
    {
        private readonly CoursesContext _context;
        public DeleteTeacherCommand(CoursesContext context)
        {
            _context = context;
        }
        public int Id => 20;

        public string Name => "Delete teacher";

        public void Execute(int request)
        {
            var teacher = _context.Teachers.Find(request);

            if (teacher == null)
            {
                throw new EntityNotFoundException(request, typeof(Teacher));
            }

            teacher.IsDeleted = true;
            teacher.IsActive = false;
            teacher.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
