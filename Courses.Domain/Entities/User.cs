using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserUserCase> UserUserCases { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; } = new HashSet<UserCourse>();
    }

   
}
