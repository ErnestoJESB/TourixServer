using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ActividadesController : ControllerBase
    {
        private readonly IActividadesServices _actividadesServices;
        public ActividadesController(IActividadesServices actividadesServices)
        {
            _actividadesServices = actividadesServices;
        }

        //Obtener Actividades
        [HttpGet]
        public async Task<IActionResult> GetActividades()
        {
            try
            {
                var response = await _actividadesServices.GetActividades();

                return Ok(response);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Creacion de actividades
        [HttpPost]
        public async Task<IActionResult> CrearActividad([FromBody] ActividadDTO request)
        {
            try
            {
                var response = await _actividadesServices.CrearActividad(request);

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Obtener actividad x id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _actividadesServices.GetByID(id);
            return Ok(response);
        }
        //Actualizacion de actividad
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ActividadDTO request)
        {
            var response = await _actividadesServices.ActualizarActividad(id, request);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response);
        }
        //Eliminar actividad
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var response = await _actividadesServices.EliminarActividad(id);
                if (!response.Success)
                {
                    return NotFound(response.Message);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //get actividades by agencia
        [HttpGet("Agencia/{id}")]
        public async Task<IActionResult> GetByAgencia(int id)
        {
            var response = await _actividadesServices.GetActividadesByAgencia(id);
            return Ok(response);
        }

        //get nearbyActividad
        [HttpPost("ActividadCercana")]
        public async Task<IActionResult> GetNearbyActividad([FromBody] NearbyActividadDTO request)
        {
            try
            {           
                var response = await _actividadesServices.GetNearbyActividad(request);

                return Ok(response);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("LastReleases")]
        public async Task<IActionResult> GetLastReleases()
        {
            var response = await _actividadesServices.GetLastReleases();
            return Ok(response);
        }

        [HttpGet("Random")]
        public async Task<IActionResult> GetRandom()
        {
            var response = await _actividadesServices.GetRandom();
            return Ok(response);
        }
    }
}
