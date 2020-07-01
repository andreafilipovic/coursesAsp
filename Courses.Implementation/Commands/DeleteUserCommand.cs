using Courses.Application.Commands;
using Courses.Application.Exceptions;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Implementation.Commands
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly CoursesContext _context;
        public DeleteUserCommand(CoursesContext context)
        {
            _context = context;
        }
        public int Id => 7;

        public string Name => "Deleting user";

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);

            if (user == null)
            {
                throw new EntityNotFoundException(request, typeof(User));
            }

            user.IsDeleted = true;
            user.IsActive = false;
            user.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
