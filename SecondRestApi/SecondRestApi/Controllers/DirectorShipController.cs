using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecondRestApi.Business;
using SecondRestApi.Model;

namespace SecondRestApi.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class DirectorShipController : ControllerBase
    {
        private readonly ILogger<DirectorShipController> _logger;
        private IDirectorShipBusiness _directorShipBusiness;

        public DirectorShipController(ILogger<DirectorShipController> logger, IDirectorShipBusiness directorShipBusiness)
        {
            _logger = logger;
            _directorShipBusiness = directorShipBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_directorShipBusiness.FindAll());
        }

        [HttpPost]

        public IActionResult Post([FromBody] DirectorShip director)
        {
            if (director == null) return BadRequest();
            return Ok(_directorShipBusiness.Create(director));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _directorShipBusiness.Delete(id);
            return NoContent();
        }
    }
}
