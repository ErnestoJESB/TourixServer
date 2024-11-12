using Dapper;
using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Context;

namespace WebApi.Services
{
    public class AgenciasServices : IAgenciasServices
    {
        private readonly ApplicationDBContext _context;
        public AgenciasServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Agencias>>> GetAgencias()
        {
            try
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    var agencias = await connection.QueryAsync<Agencias>("spGetAgencias", commandType: CommandType.StoredProcedure);
                    return new Response<List<Agencias>>(agencias.ToList());
                }
            }
            catch (Exception ex)
            {
                return new Response<List<Agencias>>(false, $"Sucedió un error: {ex.Message}", null);
            }
        }
        public async Task<Response<AgenciasResponseDTO>> Login(LoginUser login)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EmailInput", login.email, DbType.String);
                parameters.Add("@Password", dbType: DbType.String, size: 250, direction: ParameterDirection.Output);
                parameters.Add("@Resultado", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                parameters.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Nombre", dbType: DbType.String, size: 250, direction: ParameterDirection.Output);
                parameters.Add("@EmailOutput", dbType: DbType.String, size: 250, direction: ParameterDirection.Output);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spLoginAgencias", parameters, commandType: CommandType.StoredProcedure);

                    var resultado = parameters.Get<bool>("@Resultado");
                    var ID = parameters.Get<int>("@ID");
                    var Nombre = parameters.Get<string>("@Nombre");
                    var EmailOutput = parameters.Get<string>("@EmailOutput");
                    var Password = parameters.Get<string>("@Password");
                    
                    if (!resultado)
                    {
                        return new Response<AgenciasResponseDTO>(false, "Credenciales incorrectas.");
                    }

                    string storedPasswordHash = parameters.Get<string>("@Password");
                        if (!BCrypt.Net.BCrypt.Verify(login.password, storedPasswordHash))
                        {
                            return new Response<AgenciasResponseDTO>(false, "Credenciales incorrectas.");
                        }

                        return new Response<AgenciasResponseDTO>(new AgenciasResponseDTO
                        {
                            ID = parameters.Get<int>("@ID"),
                            Nombre = parameters.Get<string>("@Nombre"),
                            Correo = parameters.Get<string>("@EmailOutput"),
                        });
                    
                }
            }
            catch (Exception ex)
            {
                return new Response<AgenciasResponseDTO>(false, $"Sucedió un error: {ex.Message}", null);
            }
        }
    
        public async Task<Response<AgenciasResponseDTO>> Register(AgenciaCreateDTO agencia)
        {
            try
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(agencia.Password, 10);
                var parameters = new DynamicParameters();
                parameters.Add("@Nombre", agencia.NombreAgencia, DbType.String);
                parameters.Add("@Email", agencia.Email, DbType.String);
                parameters.Add("@Telefono", agencia.Telefono, DbType.String);
                parameters.Add("@Direccion", agencia.Direccion, DbType.String);
                parameters.Add("@Descripcion", agencia.Descripcion, DbType.String);
                parameters.Add("@Password", hashedPassword, DbType.String);

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.ExecuteAsync("spCreateAgencia", parameters, commandType: CommandType.StoredProcedure);
                    return new Response<AgenciasResponseDTO>(true, "Agencia registrada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                return new Response<AgenciasResponseDTO>(false, $"Sucedió un error: {ex.Message}");
            }
        }

    }
}
