using Domain.DTO;
using Domain.Entities;
using MailKit.Net.Smtp;
using MimeKit;
using WebApi.Context;

namespace WebApi.Services
{
    public class CorreoServices : ICorreoServices
    {
        private readonly ApplicationDBContext _context;
        private readonly IConfiguration _configuration;
        public CorreoServices(ApplicationDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Response<CorreoDTO>> EnviarCorreo(CorreoDTO request)
        {
            try
            {
                string body = $@"
            <body>
                <h1>Reservación de la actividad</h1>
                <p>Se ha realizado una reservación para la actividad: <strong>{request.NombreActividad}</strong></p>
                <p>Fecha de la actividad: <strong>{request.Fecha}</strong></p>
                <p>Nombre del cliente: <strong>{request.Nombre}</strong></p>
                <p>Correo del cliente: <strong>{request.Email}</strong></p>
                <p>Teléfono del cliente: <strong>{request.Telefono}</strong></p>
            </body>";

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_configuration["Email:Username"]));
                email.To.Add(MailboxAddress.Parse(request.Email));
                email.Subject = $"Reservación de la actividad {request.NombreActividad}";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

                using var smtp = new SmtpClient();
                smtp.Connect(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]), MailKit.Security.SecureSocketOptions.StartTls);

                smtp.Authenticate(_configuration["Email:Username"], _configuration["Email:Password"]);

                smtp.Send(email);
                smtp.Disconnect(true);

                return new Response<CorreoDTO>(true, "Correo enviado correctamente", request);
            }
            catch (Exception ex)
            {
                return new Response<CorreoDTO>(false, $"Sucedió un error: {ex.Message}", null);
            }
        }
    }
}
