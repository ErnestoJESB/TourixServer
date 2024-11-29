using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardServices _dashboardServices;
        public DashboardController(IDashboardServices dashboardServices)
        {
            _dashboardServices = dashboardServices;
        }

        [HttpGet("ActividadMasReservada/{id}")]
        public async Task<IActionResult> GetActividadMasReservada(int id)
        {
            var response = await _dashboardServices.GetActividadMasReservada(id);

            return Ok(response);
        }

        [HttpGet("IngresosPorDia/{id}")]
        public async Task<IActionResult> GetIngresosPorDia(int id)
        {
            var response = await _dashboardServices.GetIngresosPorDia(id);

            return Ok(response);
        }

        [HttpGet("MejorCliente/{id}")]
        public async Task<IActionResult> GetMejorCliente(int id)
        {
            var response = await _dashboardServices.GetMejorCliente(id);

            return Ok(response);
        }

        [HttpGet("VentasPorDia/{id}")]
        public async Task<IActionResult> GetVentasPorDia(int id)
        {
            var response = await _dashboardServices.GetVentasPorDia(id);

            return Ok(response);
        }

        [HttpGet("TotalActividades/{id}")]
        public async Task<IActionResult> GetTotalActividades(int id)
        {
            var response = await _dashboardServices.GetTotalActividades(id);
            return Ok(response);
        }

        [HttpGet("TotalReservaciones/{id}")]
        public async Task<IActionResult> GetTotalReservaciones(int id)
        {
            var response = await _dashboardServices.GetTotalReservaciones(id);
            return Ok(response);
        }
    }
}
