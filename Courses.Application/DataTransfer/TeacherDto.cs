using Courses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Application.DataTransfer
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       // public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }

    public class ReadTeacherDto 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<ReadCourseDetailsDto> Courses { get; set; } = new List<ReadCourseDetailsDto>();
    }
}
