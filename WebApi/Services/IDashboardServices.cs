using Domain.Entities;

namespace WebApi.Services
{
    public interface IDashboardServices
    {
        public Task<Response<object>> GetActividadMasReservada(int id);
        public Task<Response<object>> GetIngresosPorDia(int id);
        public Task<Response<object>> GetMejorCliente(int id);
        public Task<Response<object>> GetVentasPorDia(int id);
        public Task<Response<object>> GetTotalActividades(int id);
        public Task<Response<object>> GetTotalReservaciones(int id);
        public Task<Response<object>> GetTotalIngresos(int id);
    }
}
