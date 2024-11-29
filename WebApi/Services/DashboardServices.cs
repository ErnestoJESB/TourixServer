using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Context;

namespace WebApi.Services
{
    public class DashboardServices : IDashboardServices
    {
        private readonly ApplicationDBContext _context;

        public DashboardServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response<object>> GetActividadMasReservada(int id)
        {
            try
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@AgenciaID", id, DbType.Int32);
                    var actividad = await connection.QueryFirstOrDefaultAsync<object>("spGetActividadMasReservada", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<object>(true, "La actividad más vendida es:", actividad);
                }
            }
            catch (Exception ex)
            {
                return new Response<object>(false, $"Sucedió un error: {ex.Message}", null);

            }
        }

        public async Task<Response<object>> GetIngresosPorDia(int id)
        {
            try
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@AgenciaID", id, DbType.Int32);
                    var ingresos = await connection.QueryAsync<object>("spGetIngresosPorDia", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<object>(true, "Ingresos por día:", ingresos);
                }
            }
            catch (Exception ex)
            {
                return new Response<object>(false, $"Sucedió un error: {ex.Message}", null);
            }
        }

        public async Task<Response<object>> GetMejorCliente(int id)
        {
            try
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@AgenciaID", id, DbType.Int32);
                    var cliente = await connection.QueryFirstOrDefaultAsync<object>("spGetMejorCliente", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<object>(true, "El mejor cliente es:", cliente);
                }
            }
            catch (Exception ex)
            {
                return new Response<object>(false, $"Sucedió un error: {ex.Message}", null);
            }
        }

        public async Task<Response<object>> GetVentasPorDia(int id)
        {
            try
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@AgenciaID", id, DbType.Int32);
                    var ventas = await connection.QueryAsync<object>("spGetVentasPorDia", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<object>(true, "Ventas por día:", ventas);
                }
            }
            catch (Exception ex)
            {
                return new Response<object>(false, $"Sucedió un error: {ex.Message}", null);
            }
        }

        public async Task<Response<object>> GetTotalActividades(int id)
        {
            try
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@AgenciaID", id, DbType.Int32);
                    var actividades = await connection.QueryFirstOrDefaultAsync<object>("spGetTotalActividades", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<object>(true, "Total de actividades:", actividades);
                }
            }
            catch (Exception ex)
            {
                return new Response<object>(false, $"Sucedió un error: {ex.Message}", null);
            }
        }

        public async Task<Response<object>> GetTotalReservaciones(int id)
        {
            try
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@AgenciaID", id, DbType.Int32);
                    var reservaciones = await connection.QueryFirstOrDefaultAsync<object>("spGetTotalReservaciones", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<object>(true, "Total de reservaciones:", reservaciones);
                }
            }
            catch (Exception ex)
            {
                return new Response<object>(false, $"Sucedió un error: {ex.Message}", null);
            }
        }
    }
}
