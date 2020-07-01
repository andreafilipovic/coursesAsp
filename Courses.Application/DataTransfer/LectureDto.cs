using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Application.DataTransfer
{
    public class LectureDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CoursId { get; set; }
    }
}
