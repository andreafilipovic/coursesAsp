using AutoMapper;
using Courses.Application.DataTransfer;
using Courses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.Api.Core.Profiles
{
    public class CategoryProfil : Profile
    {
        public CategoryProfil() {
            CreateMap<Category, ReadCategoryDto>()
                 .ForMember(dto => dto.Courses, opt => opt.MapFrom(Category => Category.Courses.Select(ol => new ReadCourseDetailsDto
                 {
                     Name=ol.Name,
                     Id=ol.Id
                 })));
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
