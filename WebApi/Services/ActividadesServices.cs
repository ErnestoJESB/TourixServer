using Dapper;
using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Context;

namespace WebApi.Services
{
    public class ActividadesServices : IActividadesServices
    {
        private readonly ApplicationDBContext _context;

        public ActividadesServices(ApplicationDBContext context)
        {
            _context = context;
        }

        //obtencion de actividades
        public async Task<Response<List<ActividadImagenDTO>>> GetActividades()
        {
            try
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    var actividades = await connection.QueryAsync<ActividadImagenDTO>("spGetActividades", commandType: CommandType.StoredProcedure);
                    return new Response<List<ActividadImagenDTO>>(actividades.ToList());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error catastrofico: " + ex.Message);
            }
        }

        public async Task<Response<ActividadCreateDTO>> CrearActividad(ActividadDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AgenciaID", request.AgenciaID, DbType.Int32);
                parameters.Add("@Nombre", request.NombreActividad, DbType.String);
                parameters.Add("@Descripcion", request.Descripcion, DbType.String);
                parameters.Add("@Precio", request.Precio, DbType.Decimal);
                parameters.Add("@Duracion", request.Duracion, DbType.Int32);
                parameters.Add("@Direccion", request.Direccion, DbType.String);
                parameters.Add("@Latitud", request.Latitud, DbType.Double);
                parameters.Add("@Longitud", request.Longitud, DbType.Double);
                parameters.Add("@LastID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spCreateActividad", parameters, commandType: CommandType.StoredProcedure);  
                    
                    var Respuesta = new ActividadCreateDTO
                    {
                        LastID = parameters.Get<int>("@LastID"),
                        AgenciaID = request.AgenciaID,
                        NombreActividad = request.NombreActividad,
                        Descripcion = request.Descripcion,
                        Precio = request.Precio,
                        Duracion = request.Duracion,
                        Direccion = request.Direccion,
                        Latitud = request.Latitud,
                        Longitud = request.Longitud
                    };

                    return new Response<ActividadCreateDTO>(Respuesta, "Actividad registrada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error macabro: " + ex.Message);
            }
        }

        public async Task<Response<ActividadImagenDTO>> GetByID(int id)
        {
            try
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@ActividadID", id, DbType.Int32);

                    var actividad = await connection.QueryFirstOrDefaultAsync<ActividadImagenDTO>("spGetActividadByID", parameters, commandType: CommandType.StoredProcedure);

                    return new Response<ActividadImagenDTO>(actividad!);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error macabro: " + ex.Message);
            }
        }
        //Actualizacion de actividad con spUpdateActividad
        public async Task<Response<ActividadDTO>> ActualizarActividad(int id, ActividadDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ActividadID", id, DbType.Int32);
                parameters.Add("@Nombre", request.NombreActividad, DbType.String);
                parameters.Add("@Descripcion", request.Descripcion, DbType.String);
                parameters.Add("@Precio", request.Precio, DbType.Decimal);
                parameters.Add("@Duracion", request.Duracion, DbType.Int32);
                parameters.Add("@Direccion", request.Direccion, DbType.String);
                parameters.Add("@Latitud", request.Latitud, DbType.Double);
                parameters.Add("@Longitud", request.Longitud, DbType.Double);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spUpdateActividad", parameters, commandType: CommandType.StoredProcedure);

                    return new Response<ActividadDTO>(request, "Actividad actualizada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error macabro: " + ex.Message);
            }
        }
        //Eliminacion de actividad con spDeleteActividad
        public async Task<Response<bool>> EliminarActividad(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ActividadID", id, DbType.Int32);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spDeleteActividad", parameters, commandType: CommandType.StoredProcedure);

                    return new Response<bool>(true, "Actividad eliminada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error macabro: " + ex.Message);
            }
        }
        //get actividades by agencia con [spGetActividadesByAgencia]
        public async Task<Response<List<ActividadImagenDTO>>> GetActividadesByAgencia(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AgenciaID", id, DbType.Int32);

                using (var connection = _context.Database.GetDbConnection())
                {
                    var res = await connection.QueryAsync<ActividadImagenDTO>("spGetActividadesByAgencia", parameters, commandType: CommandType.StoredProcedure);

                    return new Response<List<ActividadImagenDTO>>(res.ToList());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error macabro: " + ex.Message);
            }
        }


        //get actividades by cercanía con [sp_GetNearbyActivities]
        public async Task<Response<List<NearbyActivitidad>>> GetNearbyActividad(NearbyActividadDTO request)
        {
            try
            {
                
                var parameters = new DynamicParameters();
                parameters.Add("@user_lat", request.Latitud, DbType.Single);
                parameters.Add("@user_lng", request.Longitud, DbType.Single);

                using (var connection = _context.Database.GetDbConnection())
                {
                    var res = await connection.QueryAsync<NearbyActivitidad>("sp_GetNearbyActivities", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<List<NearbyActivitidad>>(res.ToList());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error macabro: " + ex.Message);
            }
        }

        public async Task<Response<List<ActividadImagenDTO>>> GetLastReleases()
        {
            try
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    var res = await connection.QueryAsync<ActividadImagenDTO>("spGetLastReleases", commandType: CommandType.StoredProcedure);
                    return new Response<List<ActividadImagenDTO>>(res.ToList());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error macabro: " + ex.Message);
            }
        }

        public async Task<Response<List<ActividadImagenDTO>>> GetRandom()
        {
            try
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    var res = await connection.QueryAsync<ActividadImagenDTO>("spGetRandom", commandType: CommandType.StoredProcedure);
                    return new Response<List<ActividadImagenDTO>>(res.ToList());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error macabro: " + ex.Message);
            }
        }

    }
}
