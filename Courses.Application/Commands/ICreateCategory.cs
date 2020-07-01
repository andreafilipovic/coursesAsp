using Courses.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Application.Commands
{
    public interface ICreateCategory : ICommand<CategoryDto>
    {
    }
}
