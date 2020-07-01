using Courses.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Application.Searches
{
    public class CategorySearch : PagedSearch
    {
        public string Name { get; set; }
    }
}
