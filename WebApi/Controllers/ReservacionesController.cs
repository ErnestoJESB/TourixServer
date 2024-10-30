﻿using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservacionesController : ControllerBase
    {
        private readonly IReservacionesServices _reservacionesServices;
        public ReservacionesController(IReservacionesServices reservacionesServices)
        {
            _reservacionesServices = reservacionesServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservaciones()
        {
            var response = await _reservacionesServices.GetReservaciones();

            return Ok(response);
        }

        [HttpGet("{tipoReservacion}")]
        public async Task<IActionResult> GetReservacionesTipo(string tipoReservacion)
        {
            var response = await _reservacionesServices.GetReservacionesTipo(tipoReservacion);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservacion([FromBody] ReservacionCreateDTO request)
        {
            var response = await _reservacionesServices.CreateReservacion(request);

            return Ok(response);
        }
    }
}