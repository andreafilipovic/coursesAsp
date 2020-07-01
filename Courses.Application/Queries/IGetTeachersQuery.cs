using Courses.Application.Commands;
using Courses.Application.DataTransfer;
using Courses.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Application.Queries
{
    public interface IGetTeachersQuery : IQuery<TeacherSearch, PagedResponse<TeacherDto>>
    {
    }
}
