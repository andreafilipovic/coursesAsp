using AutoMapper;
using Courses.Application.DataTransfer;
using Courses.Application.Exceptions;
using Courses.Application.Queries;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Implementation.Queries
{
    public class GetOneUser : IGetOneUserQuery
    {
        private readonly CoursesContext _context;
        private readonly IMapper _mapper;
        public GetOneUser(CoursesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id =>6;

        public string Name => "Get one user";

        public UserDto Execute(int search)
        {
            var user = _context.Users.Find(search);
            if (user == null) {

                throw new EntityNotFoundException(search, typeof(User));
            }
            return (_mapper.Map<User, UserDto>(user));

        }
    }
}
