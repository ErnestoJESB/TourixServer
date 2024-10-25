using Domain.DTO;
using Domain.Entities;

namespace WebApi.Services
{
    public interface IReservacionesServices
    {
        public Task<Response<List<Reservaciones>>> GetReservaciones();
        public Task<Response<List<Reservaciones>>> GetReservacionesTipo( string tipo );
        public Task<Response<ReservacionCreateDTO>> CreateReservacion(ReservacionCreateDTO request);

    }
}
