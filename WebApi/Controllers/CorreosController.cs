using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CorreosController : ControllerBase
    {
        private readonly ICorreoServices _correoServices;
        public CorreosController(ICorreoServices correoServices)
        {
            _correoServices = correoServices;
        }

        [HttpPost]
        public async Task<IActionResult> EnviarCorreo([FromBody] CorreoDTO request)
        {
            var response = await _correoServices.EnviarCorreo(request);

            return Ok(response);
        }
    }
}
