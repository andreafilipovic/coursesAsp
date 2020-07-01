using AutoMapper;
using Courses.Application.DataTransfer;
using Courses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.Api.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
           
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
