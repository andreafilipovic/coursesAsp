using Courses.Application.Commands;
using Courses.Application.Exceptions;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Implementation.Commands
{
    public class DeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly CoursesContext _context;
        public DeleteCategoryCommand(CoursesContext context)
        {
            _context = context;
        }
        public int Id => 13;

        public string Name => "Deleting category";

        public void Execute(int request)
        {
            var category = _context.Categories.Find(request);

            if (category == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }

            category.IsDeleted = true;
            category.IsActive = false;
            category.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
