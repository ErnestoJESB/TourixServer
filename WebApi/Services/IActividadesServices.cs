using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using static WebApi.Services.ActividadesServices;

namespace WebApi.Services
{
    public interface IActividadesServices
    {
        public Task<Response<List<ActividadImagenDTO>>> GetActividades();
        public Task<Response<ActividadCreateDTO>> CrearActividad(ActividadDTO request);
        public Task<Response<ActividadImagenDTO>> GetByID(int id);
        public Task<Response<ActividadDTO>> ActualizarActividad(int id, ActividadDTO request);
        public Task<Response<bool>> EliminarActividad(int id);
        public Task<Response<List<ActividadImagenDTO>>> GetActividadesByAgencia(int id);
        public Task<Response<List<NearbyActivitidad>>> GetNearbyActividad(NearbyActividadDTO request);
        public Task<Response<List<ActividadImagenDTO>>> GetLastReleases();
        public Task<Response<List<ActividadImagenDTO>>> GetRandom();
        public Task<Response<LogDTO>> LogActividad(LogDTO request);

    }
}
