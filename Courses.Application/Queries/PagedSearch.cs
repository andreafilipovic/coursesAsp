﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Application.Queries
{
    public abstract class PagedSearch
    {
        public int PerPage { get; set; } = 2;
        public int Page { get; set; } = 1;
    }
}
