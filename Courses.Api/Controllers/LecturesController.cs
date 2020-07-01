using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.Application;
using Courses.Application.Commands;
using Courses.Application.DataTransfer;
using Courses.Application.Queries;
using Courses.Application.Searches;
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
    public class LecturesController : ControllerBase
    {
        private readonly CoursesContext _context;
        private readonly UseCaseExecutor executor;

        public LecturesController(CoursesContext context, UseCaseExecutor executor)
        {
            _context = context;
            this.executor = executor;
        }
        // GET: api/<LecturesController>
        [HttpGet]
        public IActionResult Get([FromQuery] LectureSearch search, [FromServices] IGetLecturesQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<LecturesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneLectureQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<LecturesController>
        [HttpPost]
        public IActionResult Post([FromBody] LectureDto dto, [FromServices] ICreateLectureCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<LecturesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LectureDto dto, [FromServices] IUpdateLectureCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<LecturesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteLectureCommand command)
        {
            executor.ExecuteCommand(command,id);
            return NoContent();
        }
    }
}
