using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecondRestApi.Model;
using SecondRestApi.Services.Implementations;

namespace SecondRestApi.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }
        

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentService.FindAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            if (student == null) return BadRequest();
            return Ok(_studentService.Create(student));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Student student)
        {
            if (student == null) return BadRequest();
            return Ok(_studentService.Update(student));
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            _studentService.Delete(name);
            return NoContent();
        }
    }
}
