using AutoMapper;
using Courses.Application.Commands;
using Courses.Application.DataTransfer;
using Courses.Application.Email;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using Courses.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Implementation.Commands
{
    public class RegisterUser : IRegisterUserCommand
    {
        private readonly CoursesContext context;
        private readonly CreateUserValidator validator;
        private readonly IEmailSender sender;
        private readonly IMapper mapper;

        public RegisterUser(CoursesContext context, CreateUserValidator validator, IEmailSender sender, IMapper mapper)
        {
            this.context = context;
            this.validator = validator;
            this.sender = sender;
            this.mapper = mapper;
        }
        public int Id => 28;

        public string Name => "Register user";

        public void Execute(UserDto request)
        {
            validator.ValidateAndThrow(request);
            var user= mapper.Map<User>(request);
            context.Users.Add(user);
            context.SaveChanges();
            sender.Send(new SendEmailDto
            {
                Content = "<h1>You are successfully registrated to online courses!</h1>",
                SendTo = request.Email,
                Subject = "Registration"
            });

            var userId = user.Id;
            var allow = new List<int> { 3, 4, 26, 27 };
            foreach (var a in allow) {
                context.UserUserCase.Add(new UserUserCase { 
                    UserId=userId,
                    UseCaseId=a
                });
            }

            context.SaveChanges();
        }
    }
}
