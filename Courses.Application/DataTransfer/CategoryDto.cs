using Courses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Application.DataTransfer
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
    }

    public class ReadCategoryDto {

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ReadCourseDetailsDto> Courses { get; set; } = new List<ReadCourseDetailsDto>();

    }

    public class ReadCourseDetailsDto { 
    
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
