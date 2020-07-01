using Courses.Application;
using Courses.Application.Commands;
using Courses.Application.Exceptions;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses.Implementation.Commands
{
    public class UnsubscribeCommand : IUnsubscribeCommand
    {
        private readonly CoursesContext context;
        private readonly IApplicationActor actor;

        public UnsubscribeCommand(CoursesContext context, IApplicationActor actor)
        {
            this.context = context;
            this.actor = actor;
        }

        public int Id => 27;

        public string Name => "Unsubcribe from course";

        public void Execute(int request)
        {
            var userId = actor.Id;
            var sub = context.UserCourse.Where(x => x.CourseId == request && x.UserId == actor.Id).FirstOrDefault();

            if (sub == null)
            {
                throw new EntityNotFoundException(request, typeof(UserCourse));
            }

            context.UserCourse.Remove(sub);
            context.SaveChanges();
        }
    }
}
