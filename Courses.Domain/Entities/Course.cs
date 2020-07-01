using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Domain.Entities
{
    public class Course : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string VideoLink { get; set; }
        public string Image { get; set; } 
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; } = new HashSet<Lecture>();
        public virtual ICollection<UserCourse> UserCourses { get; set; } = new HashSet<UserCourse>();


    }
}
