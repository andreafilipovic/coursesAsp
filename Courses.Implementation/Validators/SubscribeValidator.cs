using Courses.Application;
using Courses.Application.DataTransfer;
using Courses.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses.Implementation.Validators
{
    public class SubscribeValidator : AbstractValidator<UserCoursesDto>
    {
        private readonly CoursesContext context;
        private readonly IApplicationActor _actor;
        public SubscribeValidator(CoursesContext context, IApplicationActor actor)
        {
            this.context = context;
            _actor = actor;

            RuleFor(x => x.CourseId)
              .NotEmpty()
              .WithMessage("CourseId is reqired")
              .Must(CourseExists)
              .WithMessage("Cours doesn't exists")
              .Must((CourseId) => !context.UserCourse.Any(dto => dto.CourseId == CourseId && dto.UserId == _actor.Id))
              .WithMessage(dto => $"User already subscribed to a cours with Id {dto.CourseId} .");

        }

        private bool CourseExists(int courseId)
        {
            return context.Courses.Any(x => x.Id == courseId);
        }
    }
}
