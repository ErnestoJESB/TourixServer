using Domain.DTO;
using Domain.Entities;

namespace WebApi.Services
{
    public interface IDisponibilidadActividadesServices
    {
        Task<Response<List<DisponibilidadActividades>>> GetDisponibilidad();
        Task<Response<DisponibilidadActividadesDTO>> CreateDisponibilidad(DisponibilidadActividadesDTO request);
        Task<Response<List<DisponibilidadByActividadDTO>>> GetDisponibilidadByActividad (int id);
        Task<Response<bool>> DeleteDisponibilidades(int id);
    }
}
