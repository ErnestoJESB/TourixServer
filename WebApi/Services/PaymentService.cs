using Domain.DTO;
using PayPal.Api;

namespace WebApi.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly string clientId = "AfPXMheGnJ5z11nLFw5-0zv3QMnoaPYBZ4TEKAHHHAz2uySJ7JgC57AeiVIj5oBDKOhdWewa2F4wUFKy";
        private readonly string clientSecret = "EDNuGdWNJMOYLodWOabRRniE04EjsyNjKanx_2fISfRTHEDsdsc6u9i77ja3Q37rzKu6RbCjvzIFW8oY";

        public async Task<string> CreatePaymentOrder(PaymentOrderDTO orderDto)
        {
            var config = new Dictionary<string, string>
        {
            { "mode", "sandbox" }, // Cambia a "live" en producción
            { "clientId", clientId },
            { "clientSecret", clientSecret }
        };

            var apiContext = new APIContext(new OAuthTokenCredential(clientId, clientSecret, config).GetAccessToken())
            {
                Config = config
            };

            var payment = new Payment
            {
                intent = "sale",
                payer = new Payer { payment_method = "paypal" },
                transactions = new List<Transaction>
            {
                new Transaction
                {
                    description = orderDto.Description,
                    amount = new Amount
                    {
                        currency = orderDto.Currency,
                        total = orderDto.Amount.ToString("F2")
                    }
                }
            },
                redirect_urls = new RedirectUrls
                {
                    return_url = "https://tourix.azurewebsites.net/paypal/success",
                    cancel_url = "https://tourix.azurewebsites.net/paypal/cancel"
                }
            };

            var createdPayment = payment.Create(apiContext);
            return createdPayment.links.FirstOrDefault(link => link.rel == "approval_url")?.href;
        }

        public async Task<string> ExecutePayment(string paymentId, string payerId)
        {
            try
            {
                var config = new Dictionary<string, string>
                {
                    { "mode", "sandbox" }, // Cambia a "live" en producción
                    { "clientId", clientId },
                    { "clientSecret", clientSecret }
                };

                var apiContext = new APIContext(new OAuthTokenCredential(clientId, clientSecret, config).GetAccessToken())
                {
                    Config = config
                };

                var paymentExecution = new PaymentExecution { payer_id = payerId };
                var payment = new Payment { id = paymentId };

                var executedPayment = payment.Execute(apiContext, paymentExecution);

                return executedPayment.state; // Debería retornar "approved" si fue exitoso
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el pago: " + ex.Message);
            }
        }
    }

}
