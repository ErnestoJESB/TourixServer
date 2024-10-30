using Dapper;
using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Context;

namespace WebApi.Services
{
    public class ImagenesActividadesServices : IImagenesActividadesServices
    {
        private readonly ApplicationDBContext _context;
        public ImagenesActividadesServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response<List<ImagenesActividades>>> GetImagenesActividades(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ActividadID", id, DbType.Int32);

                using (var connection = _context.Database.GetDbConnection())
                {
                    var imagenes = await connection.QueryAsync<ImagenesActividades>("spGetImagenesActividades", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<List<ImagenesActividades>>(imagenes.ToList());
                }
            }
            catch (Exception ex)
            {
                return new Response<List<ImagenesActividades>>(false, $"Sucedió un error: {ex.Message}", null);
            }
        }

        public async Task<Response<ImagenesActividadesDTO>> CreateImagenesActividades(ImagenesActividadesDTO request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ActividadID", request.ActividadID, DbType.Int32);
                parameters.Add("@Url", request.ImagenURL, DbType.String);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spCreateImagenesActividades", parameters, commandType: CommandType.StoredProcedure);

                    return new Response<ImagenesActividadesDTO>(true, "Imagen creada exitosamente.", request);
                }
            }
            catch (Exception ex)
            {
                return new Response<ImagenesActividadesDTO>(false, $"Sucedió un error: {ex.Message}", null);
            }
        }
    }
}
