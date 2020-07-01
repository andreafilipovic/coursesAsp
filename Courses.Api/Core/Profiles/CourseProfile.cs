using AutoMapper;
using Courses.Application.DataTransfer;
using Courses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.Api.Core.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, ReadCourseDto>()
                .ForMember(dto => dto.Lectures, opt => opt.MapFrom(Course => Course.Lectures.Select(ol => new ReadLectureDto
                {
                    CoursId=ol.CoursId,
                    Title=ol.Title
                })));
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
            
        }
    }
}


