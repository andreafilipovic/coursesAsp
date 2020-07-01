using Courses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Application.DataTransfer
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string VideoLink { get; set; }
        public string Image { get; set; } = "default.jpg";
        public int TeacherId { get; set; }
        public int CategoryId { get; set; }
    }
    public class ReadCourseDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string VideoLink { get; set; }
        public string Image { get; set; }
        public int TeacherId { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<ReadLectureDto> Lectures { get; set; } = new List<ReadLectureDto>();
    }

    public class ReadLectureDto {
        public string Title { get; set; }
        public int CoursId { get; set; }
    }
}
