using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.Application;
using Courses.Application.Commands;
using Courses.Application.DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly UseCaseExecutor executor;
        public RegisterController(UseCaseExecutor executor) {
            this.executor = executor;
        }
        
        // POST api/<RegisterController>
        [HttpPost]
        public IActionResult Post([FromBody] UserDto dto, [FromServices] IRegisterUserCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

      
    }
}
