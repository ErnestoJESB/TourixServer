using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagenesActividadesController : Controller
    {
        public readonly IImagenesActividadesServices _imagenesActividadesServices;
        public ImagenesActividadesController(IImagenesActividadesServices imagenesActividadesServices)
        {
            _imagenesActividadesServices = imagenesActividadesServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImagenesActividades(int id)
        {
            var response = await _imagenesActividadesServices.GetImagenesActividades(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateImagenesActividades([FromBody] ImagenesActividadesDTO imagenesActividades)
        {
            var response = await _imagenesActividadesServices.CreateImagenesActividades(imagenesActividades);
            return Ok(response);
        }
    }
}
