using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Domain.Entities
{
    public class Lecture : Entity
    {
        public string Title { get; set; }
        public int CoursId { get; set; }
        public virtual Course Course { get; set; }

    }
}
