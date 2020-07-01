using AutoMapper;
using Courses.Application.DataTransfer;
using Courses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.Api.Core.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, ReadTeacherDto>()
                 .ForMember(dto => dto.Courses, opt => opt.MapFrom(Teacher => Teacher.Courses.Select(ol => new ReadCourseDetailsDto
                 {
                     
                     Name=ol.Name,
                     Id=ol.Id
                 })));
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>();

        }
    }
}
