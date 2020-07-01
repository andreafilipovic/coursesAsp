using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.Application;
using Courses.Application.Queries;
using Courses.Application.Searches;
using Courses.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public LogsController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<LogsController>
        [HttpGet]
        public IActionResult Get([FromQuery] LoggsSearch search, [FromServices] IGetLoggsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

       
    }
}
