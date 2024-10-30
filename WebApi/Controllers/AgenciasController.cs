using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgenciasController : Controller
    {
        public readonly IAgenciasServices _administradoresServices;

        public AgenciasController(IAgenciasServices administradoresServices)
        {
            _administradoresServices = administradoresServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAgencias()
        {
            var response = await _administradoresServices.GetAgencias();
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser login)
        {
            var response = await _administradoresServices.Login(login);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AgenciaCreateDTO agencia)
        {
            var response = await _administradoresServices.Register(agencia);
            return Ok(response);
        }
    }
}
