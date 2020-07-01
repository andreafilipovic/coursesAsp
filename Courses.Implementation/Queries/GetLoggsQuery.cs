using AutoMapper;
using Courses.Application.DataTransfer;
using Courses.Application.Queries;
using Courses.Application.Searches;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Courses.Implementation.Queries
{
    public class GetLoggsQuery : IGetLoggsQuery
    {
        private readonly CoursesContext context;
        private readonly IMapper _mapper;

        public GetLoggsQuery(CoursesContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }
        public int Id => 29;

        public string Name => "Logs search";

        public PagedResponse<UseCaseLogDto> Execute(LoggsSearch search)
        {
            var query = context.UseCaseLogs.AsQueryable();
            
            
            if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.User) || !string.IsNullOrWhiteSpace(search.User))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.User.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.DateFrom) || !string.IsNullOrWhiteSpace(search.DateFrom)) {
                DateTime od = DateTime.Parse(search.DateFrom);
                query = query.Where(x => x.Date.Date >= od);
            }
            if (!string.IsNullOrEmpty(search.DateTo) || !string.IsNullOrWhiteSpace(search.DateTo))
            {
                DateTime to = DateTime.Parse(search.DateTo);
                query = query.Where(x => x.Date.Date <= to);
            }

            var skipCount = search.PerPage * (search.Page - 1);
            var reponse = new PagedResponse<UseCaseLogDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).AsEnumerable().Select(item => _mapper.Map<UseCaseLog, UseCaseLogDto>(item)).ToList()
            };

            return reponse;
        }
    }
}
