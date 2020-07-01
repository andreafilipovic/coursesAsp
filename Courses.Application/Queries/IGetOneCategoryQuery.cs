using Courses.Application.Commands;
using Courses.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Application.Queries
{
    public interface IGetOneCategoryQuery : IQuery<int,ReadCategoryDto>
    {
    }
}
