using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Application.Exceptions
{
    public class NotSubscribedException : Exception
    {
        public NotSubscribedException(int id) : base($"You must subscribe to a course with an id of {id} to view details.") { }
    }
}
