using Domain.DTO;

namespace WebApi.Services
{
    public interface IPaymentService
    {
        Task<string> CreatePaymentOrder(PaymentOrderDTO orderDto);
    }
}
