using Courses.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Application.Searches
{
    public class TeacherSearch : PagedSearch
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
