using AutoMapper;
using Courses.Application.DataTransfer;
using Courses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.Api.Core.Profiles
{
    public class UseCaseLogProfile : Profile
    {
        public UseCaseLogProfile() {
            CreateMap<UseCaseLog, UseCaseLogDto>();
            CreateMap<UseCaseLogDto, UseCaseLog>();
        }
    }
}
