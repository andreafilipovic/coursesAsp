using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.Application;
using Courses.Application.Commands;
using Courses.Application.DataTransfer;
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
    public class SubscriptionController : ControllerBase
    {
        private readonly CoursesContext context;
        private readonly UseCaseExecutor executor;
        private readonly IApplicationActor _actor;
        
        public SubscriptionController(CoursesContext context, UseCaseExecutor executor, IApplicationActor actor)
        {
            this.context = context;
            this.executor = executor;
            _actor=actor;
        }

        // POST api/<SubscriptionController>
        [HttpPost]
        public IActionResult Post([FromBody] UserCoursesDto dto, [FromServices] ISubscribeCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<SubscriptionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IUnsubscribeCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
