using Courses.Application;
using Courses.Application.Commands;
using Courses.Application.Queries;
using Courses.Implementation.Commands;
using Courses.Implementation.Logging;
using Courses.Implementation.Queries;
using Courses.Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Api.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<CreateCourseValidator>();
            services.AddTransient<UpdateCourseValidator>();
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<UpdateCategoryValidator>();
            services.AddTransient<CreateTeacherValidator>();
            services.AddTransient<CreateLectureValidator>();
            services.AddTransient<UpdateLectureValidator>();
            services.AddTransient<SubscribeValidator>();

            services.AddTransient<ICreateCourseCommand, CreateCourseCommand>();
            services.AddTransient<IDeleteCourseCommand, DeleteCourseCommand>();
            services.AddTransient<IUpdateCourseCommand, UpdateCourseCommand>();
            services.AddTransient<IGetCourseQuery, GetCourseQuery>();
            services.AddTransient<IGetOneCourseQuery, GetOneCourseQuery>();

            services.AddTransient<IGetOneUserQuery, GetOneUser>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IGetUsersQuery, GetUsersQuery>();

            services.AddTransient<IGetOneCategoryQuery, GetOneCategoryQuery>();
            services.AddTransient<IGetCategoriesQuery, GetCategoriesQuery>();
            services.AddTransient<IDeleteCategoryCommand, DeleteCategoryCommand>();
            services.AddTransient<ICreateCategory, CreateCategoryCommand>();
            services.AddTransient<IUpdateCategoryCommand, UpdateCategoryCommand>();

            services.AddTransient<IGetOneTeacherQuery, GetOneTeacherQuery>();
            services.AddTransient<IGetTeachersQuery, GetTeachersQuery>();
            services.AddTransient<ICreateTeacherCommand, CreateTeacherCommand>();
            services.AddTransient<IUpdateTeacherCommand, UpdateTeacherCommand>();
            services.AddTransient<IDeleteTeacherCommand, DeleteTeacherCommand>();

            services.AddTransient<IGetLecturesQuery, GetLecturesQuery>();
            services.AddTransient<IGetOneLectureQuery, GetOneLectureQuery>();
            services.AddTransient<IDeleteLectureCommand, DeleteLectureCommand>();
            services.AddTransient<ICreateLectureCommand, CreateLectureCommand>();
            services.AddTransient<IUpdateLectureCommand, UpdateLectureCommand>();
            services.AddTransient<UseCaseExecutor>();

            services.AddTransient<IUseCaseLogger, LoggUseCaseDatabase>();
            services.AddTransient<ISubscribeCommand, SubscribeCommand>();
            services.AddTransient<IUnsubscribeCommand, UnsubscribeCommand>();
            services.AddTransient<IRegisterUserCommand, RegisterUser>();
        }

        public static void AddApplicationActor(this IServiceCollection services)
        {

            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });
        }

        public static void AddJwt(this IServiceCollection services) {
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

        }


    }
}
