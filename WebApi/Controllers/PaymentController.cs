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

        [HttpGet("paypal/success")]
        public async Task<IActionResult> PaymentSuccess(string paymentId, string PayerID)
        {
            try
            {
                var result = await _paymentService.ExecutePayment(paymentId, PayerID);
                if (result == "approved")
                {
                    return Ok(new { status = true, message = "Pago exitoso" }); // Redirige a una página de éxito en tu app
                }
                else
                {
                    return Ok(new { status = false, message = "Pago no aprobado" }); // Redirige a una página de error
                }
            }
            catch (Exception ex)
            {
                return Ok(new { status = false, message = "Pago no aprobado" }); // Muestra un error genérico
            }
        }

        [HttpGet("paypal/cancel")]
        public IActionResult PaymentCancelled()
        {
            return Ok(new { status = false, message = "Pago no aprobado" }); // Redirige a una página de cancelación en tu app
        }


    }

}
