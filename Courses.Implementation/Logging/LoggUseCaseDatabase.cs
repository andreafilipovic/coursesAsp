using Courses.Application;
using Courses.Application.Commands;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Implementation.Logging
{
    public class LoggUseCaseDatabase : IUseCaseLogger
    {
        private readonly CoursesContext context;
        public LoggUseCaseDatabase(CoursesContext context) {
            this.context = context;
        }
        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            context.UseCaseLogs.Add(new UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.Now,
                UseCaseName = useCase.Name
            });

            context.SaveChanges();
        }
    }
}
