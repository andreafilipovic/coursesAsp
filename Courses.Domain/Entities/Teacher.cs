using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Domain.Entities
{
    public class Teacher : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
