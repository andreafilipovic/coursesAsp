using Courses.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Application.Searches
{
    public class CourseSearch : PagedSearch
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
