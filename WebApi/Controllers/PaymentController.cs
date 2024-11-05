using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] PaymentOrderDTO orderDto)
        {
            try
            {
                if (orderDto == null || orderDto.Amount <= 0)
                    return BadRequest("Invalid order details.");

                var approvalUrl = await _paymentService.CreatePaymentOrder(orderDto);

                if (string.IsNullOrEmpty(approvalUrl))
                    return StatusCode(500, "Failed to create payment order.");

                return Ok(new { approvalUrl });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
