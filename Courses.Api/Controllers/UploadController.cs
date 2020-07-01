using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Courses.Application;
using Courses.Application.Exceptions;
using Courses.Domain.Entities;
using Courses.EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Courses.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly CoursesContext _context;
        private readonly IApplicationActor actor;
        public UploadController(CoursesContext context, IApplicationActor actor)
        {
            _context = context;
            this.actor = actor;
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok(actor);
        }

        // PUT api/<UploadController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromForm] UploadDto dto)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                throw new EntityNotFoundException(id, typeof(Course));
            }
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.Image.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.Image.CopyTo(fileStream);
            }
            
            course.Image = newFileName;
            _context.SaveChanges();
            return NoContent();
        }

        
    }

    public class UploadDto
    {
        public IFormFile Image { get; set; }
        public int CourseId { get; set; }
    }
}
