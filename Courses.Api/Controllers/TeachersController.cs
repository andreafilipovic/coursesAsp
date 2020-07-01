using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.Application;
using Courses.Application.Commands;
using Courses.Application.DataTransfer;
using Courses.Application.Queries;
using Courses.Application.Searches;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly CoursesContext _context;
        private readonly UseCaseExecutor executor;

        public TeachersController(CoursesContext context, UseCaseExecutor executor)
        {
            _context = context;
            this.executor = executor;
        }
        // GET: api/<TeachersController>
        [HttpGet]
        public IActionResult Get([FromQuery] TeacherSearch search, [FromServices] IGetTeachersQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<TeachersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneTeacherQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<TeachersController>
        [HttpPost]
        public IActionResult Post([FromBody] TeacherDto dto, [FromServices] ICreateTeacherCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<TeachersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TeacherDto dto,[FromServices] IUpdateTeacherCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteTeacherCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
