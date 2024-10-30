using Domain.DTO;
using Domain.Entities;

namespace WebApi.Services
{
    public interface IImagenesActividadesServices
    {
        public Task<Response<List<ImagenesActividades>>> GetImagenesActividades(int id);
        public Task<Response<ImagenesActividadesDTO>> CreateImagenesActividades(ImagenesActividadesDTO imagenesActividades);

    }
}
