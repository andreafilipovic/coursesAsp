using Courses.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Application.Searches
{
    public class LectureSearch : PagedSearch
    {
        public string Title { get; set; }
        public int CourseId { get; set; }
    }
}
