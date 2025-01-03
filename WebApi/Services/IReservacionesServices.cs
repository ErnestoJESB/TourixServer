﻿using Domain.DTO;
using Domain.Entities;

namespace WebApi.Services
{
    public interface IReservacionesServices
    {
        public Task<Response<List<Reservaciones>>> GetReservaciones();
        public Task<Response<List<Reservaciones>>> GetReservacionesTipo( string tipo );
        public Task<Response<List<ReservacionDTO>>> GetReservacionesByAgencia(int id);
        public Task<Response<List<ReservacionDTO>>> GetReservacionesByCliente(int id);
        public Task<Response<ReservacionCreateDTO>> CreateReservacion(ReservacionCreateDTO request);
        public Task<Response<bool>> UpdateReservacion(int id, string Estado);
        public Task<Response<bool>> DeleteReservacion(int id);
    }
}
