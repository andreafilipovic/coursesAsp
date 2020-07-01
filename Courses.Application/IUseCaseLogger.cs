using Courses.Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Application
{
    public interface IUseCaseLogger
    {
        void Log(IUseCase userCase, IApplicationActor actor, object useCaseData);
    }
}
