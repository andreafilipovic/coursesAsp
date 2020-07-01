using Courses.Application.DataTransfer;
using Courses.Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Application.Queries
{
    public interface IGetOneCourseQuery : IQuery<int,ReadCourseDto>
    {
    }
}
