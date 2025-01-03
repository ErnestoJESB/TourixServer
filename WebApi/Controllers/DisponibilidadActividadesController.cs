﻿using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisponibilidadActividadesController : ControllerBase
    {
        private readonly IDisponibilidadActividadesServices _disponibilidadActividadesServices;
        public DisponibilidadActividadesController(IDisponibilidadActividadesServices disponibilidadActividadesServices)
        {
            _disponibilidadActividadesServices = disponibilidadActividadesServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetDisponibilidad()
        {
            var response = await _disponibilidadActividadesServices.GetDisponibilidad();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDisponibilidad([FromBody] DisponibilidadActividadesDTO request)
        {
            var response = await _disponibilidadActividadesServices.CreateDisponibilidad(request);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDisponibilidadByActividad(int id)
        {
            var response = await _disponibilidadActividadesServices.GetDisponibilidadByActividad(id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisponibilidad(int id)
        {
            var response = await _disponibilidadActividadesServices.DeleteDisponibilidades(id);
            return Ok(response);
        }

        [HttpPut("{disponibilidadID}")]
        public async Task<IActionResult> UpdateDisponibilidad(int disponibilidadID, [FromBody] int cupoReservado)
        {
            var response = await _disponibilidadActividadesServices.UpdateDisponibilidad(disponibilidadID, cupoReservado);
            return Ok(response);
        }
    }
}
