using AutoMapper;
using Courses.Application.DataTransfer;
using Courses.Application.Queries;
using Courses.Application.Searches;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses.Implementation.Queries
{
    public class GetUsersQuery : IGetUsersQuery
    {
        private readonly CoursesContext context;
        private readonly IMapper _mapper;

        public GetUsersQuery(CoursesContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }
        public int Id => 10;

        public string Name => "Search user";

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            var query = context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search.FirstName) || !string.IsNullOrWhiteSpace(search.FirstName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.LastName) || !string.IsNullOrWhiteSpace(search.LastName))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Username) || !string.IsNullOrWhiteSpace(search.Username))
            {
                query = query.Where(x => x.Username.ToLower().Contains(search.Username.ToLower()));
            }



            var skipCount = search.PerPage * (search.Page - 1);

             
            var reponse = new PagedResponse<UserDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).AsEnumerable().Select(item => _mapper.Map<User, UserDto>(item)).ToList()
                //Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new UserDto
                /*{
                    Id = x.Id,
                    Username = x.Username,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Password = x.Password,
                    Email=x.Email
                    //UserUserCases = x.UserUserCases,
                    //UserCourses=x.UserCourses


                }).ToList()*/
            };
           
            return reponse;
        }
    }
}
