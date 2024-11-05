using Dapper;
using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Context;

namespace WebApi.Services
{
    public class DisponibilidadActividadesServices : IDisponibilidadActividadesServices
    {
        private readonly ApplicationDBContext _context;
        public DisponibilidadActividadesServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response<List<DisponibilidadActividades>>> GetDisponibilidad()
        {
            try
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    var disponibilidad = await connection.QueryAsync<DisponibilidadActividades>("spGetDisponibilidadActividad", commandType: CommandType.StoredProcedure);
                    return new Response<List<DisponibilidadActividades>>(disponibilidad.ToList());
                }
            }
            catch (Exception ex)
            {
                return new Response<List<DisponibilidadActividades>>(false, $"Sucedió un error: {ex.Message}", null);
            }
        }

        public async Task<Response<DisponibilidadActividadesDTO>> CreateDisponibilidad(DisponibilidadActividadesDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ActividadID", request.ActividadID, DbType.Int32);
                parameters.Add("@CupoMaximo", request.CupoMaximo, DbType.Int32);
                parameters.Add("@FechaHora", request.FechaHora, DbType.DateTime);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spCreateDisponibilidadActividad", parameters, commandType: CommandType.StoredProcedure);

                    return new Response<DisponibilidadActividadesDTO>(true, "Disponibilidad creada exitosamente.", request);
                }
            }
            catch (Exception ex)
            {
                return new Response<DisponibilidadActividadesDTO>(false, $"Sucedió un error: {ex.Message}", null);
            }
        }

        public async Task<Response<List<DisponibilidadByActividadDTO>>> GetDisponibilidadByActividad(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ActividadID", id, DbType.Int32);
                using (var connection = _context.Database.GetDbConnection())
                {
                    var disponibilidad = await connection.QueryAsync<DisponibilidadByActividadDTO>("spGetDisponibilidadByActividad", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<List<DisponibilidadByActividadDTO>>(disponibilidad.ToList());
                }
            }
            catch (Exception ex)
            {
                return new Response<List<DisponibilidadByActividadDTO>>(false, $"Sucedió un error: {ex.Message}", null);
            }
        }
    }
}
