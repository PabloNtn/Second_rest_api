using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecondRestApi.Business;
using SecondRestApi.Model;
using SecondRestApi.Repository.Implementations;
using SecondRestApi.Services;
using System;
using System.Threading.Tasks;

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

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] DirectorShip model)
        {
            // Recupera o usuário
            var user = DiretoriaRepositoryImplementation.Get(model.Dir_userName, model.Dir_pwd);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Dir_pwd = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Gerente";
    }
}
