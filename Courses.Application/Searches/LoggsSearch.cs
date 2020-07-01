using Courses.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Application.Searches
{
    public class LoggsSearch : PagedSearch
    {
        public string User { get; set; }
        public string UseCaseName { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
    }
}
