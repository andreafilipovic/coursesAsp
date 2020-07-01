using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Courses.Application;
using Courses.Application.Commands;
using Courses.Application.DataTransfer;
using Courses.Application.Queries;
using Courses.Application.Searches;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using Courses.Implementation;
using Courses.Implementation.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly CoursesContext _context;
        private readonly IMapper _mapper;
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

       
        public CoursesController(IMapper mapper, IApplicationActor actor, UseCaseExecutor executor)
        {

            _context = new CoursesContext();
            _mapper = mapper;
            this.actor = actor;
            this.executor = executor;
        }


        // GET: api/<CoursesController>
        
        [HttpGet]
        //[Authorize]
        public IActionResult Get([FromQuery] CourseSearch search, [FromServices] IGetCourseQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id, [FromServices] IGetOneCourseQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<CoursesController>
        [HttpPost]
        public IActionResult Post([FromBody] CourseDto dto,
            [FromServices] ICreateCourseCommand command)
        {
           
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

       

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(
            [FromBody] CourseDto dto,
            [FromServices] IUpdateCourseCommand command)
        {
            executor.ExecuteCommand(command, dto); 
            return NoContent();
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteCourseCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
          
        }

        
    }

    
}
