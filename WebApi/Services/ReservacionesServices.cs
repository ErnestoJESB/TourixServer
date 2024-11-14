using Dapper;
using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Context;

namespace WebApi.Services
{
    public class ReservacionesServices :IReservacionesServices
    {
        private readonly ApplicationDBContext _context;

        public ReservacionesServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Reservaciones>>> GetReservaciones() 
        {
            try
            {
               using (var connection = _context.Database.GetDbConnection())
                {
                    var reservaciones = await connection.QueryAsync<Reservaciones>("spGetReservaciones", commandType: CommandType.StoredProcedure);
                    return new Response<List<Reservaciones>>(reservaciones.ToList());
                }
            }
            catch (Exception ex)
            {
                return new Response<List<Reservaciones>>(false, $"Sucedió un error: {ex.Message}");
            }
        }

        public async Task<Response<List<Reservaciones>>> GetReservacionesTipo (string tipo)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Tipo", tipo, DbType.String);
                using (var connection = _context.Database.GetDbConnection())
                {
                    var reservaciones = await connection.QueryAsync<Reservaciones>("spGetReservacionesTipo", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<List<Reservaciones>>(reservaciones.ToList());
                }
            }
            catch (Exception ex)
            {
                return new Response<List<Reservaciones>>(false, $"Sucedió un error: {ex.Message}");
            }
        }

        public async Task<Response<ReservacionCreateDTO>> CreateReservacion(ReservacionCreateDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ClienteID", request.ClienteID, DbType.Int32);
                parameters.Add("@FechaReservacion", request.FechaReservacion, DbType.DateTime);
                parameters.Add("@CantidadPersonas", request.CantidadPersonas, DbType.Int32);
                parameters.Add("@Total", request.Total, DbType.Decimal);
                parameters.Add("@Tipo", request.Tipo, DbType.String);
                parameters.Add("@ID", request.ID, dbType: DbType.Int32);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spCreateReservaciones", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<ReservacionCreateDTO>(true, "Reservación creada exitosamente.", request);
                }
            }
            catch (Exception ex)
            {
                return new Response<ReservacionCreateDTO>(false, $"Sucedió un error: {ex.Message}");
            }
        }
    }
}
