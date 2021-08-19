using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecondRestApi.Business;
using SecondRestApi.Model;


namespace SecondRestApi.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private IStudentBusiness _studentBusiness;

        public StudentController(ILogger<StudentController> logger, IStudentBusiness studentBusiness)
        {
            _logger = logger;
            _studentBusiness = studentBusiness;
        }
        

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentBusiness.FindAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            if (student == null) return BadRequest();
            return Ok(_studentBusiness.Create(student));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Student student)
        {
            if (student == null) return BadRequest();
            return Ok(_studentBusiness.Update(student));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _studentBusiness.Delete(id);
            return NoContent();
        }
    }
}
