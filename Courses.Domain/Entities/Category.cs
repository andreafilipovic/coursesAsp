using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
