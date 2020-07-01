using AutoMapper;
using Courses.Application;
using Courses.Application.Commands;
using Courses.Application.DataTransfer;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using Courses.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Implementation.Commands
{
    public class SubscribeCommand : ISubscribeCommand
    {
        private readonly CoursesContext context;
        private readonly SubscribeValidator validator;
        private readonly IMapper _mapper;
        private readonly IApplicationActor _actor;

        public SubscribeCommand(CoursesContext context, SubscribeValidator validator, IMapper mapper, IApplicationActor actor)
        {
            this.context = context;
            this.validator = validator;
            _mapper = mapper;
            _actor = actor;
        }
        public int Id =>26;

        public string Name => "Subscribe user to a course";

        public void Execute(UserCoursesDto request)
        {
            validator.ValidateAndThrow(request);
            var actorId = _actor.Id;
            var sub = new UserCourse
            {
                UserId = actorId,
                CourseId = request.CourseId
            };
            context.UserCourse.Add(sub);

            context.SaveChanges();
        }
    }
}



