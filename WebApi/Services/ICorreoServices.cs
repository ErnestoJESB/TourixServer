using Domain.DTO;
using Domain.Entities;

namespace WebApi.Services
{
    public interface ICorreoServices
    {
        Task<Response<CorreoDTO>> EnviarCorreo(CorreoDTO request);
    }
}
