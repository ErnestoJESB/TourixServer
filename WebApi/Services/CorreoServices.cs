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
        <!DOCTYPE html>

<html lang=""en"" xmlns:o=""urn:schemas-microsoft-com:office:office"" xmlns:v=""urn:schemas-microsoft-com:vml"">

<head>
	<title></title>
	<meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"" />
	<meta content=""width=device-width, initial-scale=1.0"" name=""viewport"" />
	<!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]--><!--[if !mso]><!-->
	<link href=""https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;300;400;500;600;700;800;900""
		rel=""stylesheet"" type=""text/css"" /><!--<![endif]-->
	<style>
		* {{
			box-sizing: border-box;
		}}

		body {{
			margin: 0;
			padding: 0;
		}}

		a[x-apple-data-detectors] {{
			color: inherit !important;
			text-decoration: inherit !important;
		}}

		#MessageViewBody a {{
			color: inherit;
			text-decoration: none;
		}}

		p {{
			line-height: inherit
		}}

		.desktop_hide,
		.desktop_hide table {{
			mso-hide: all;
			display: none;
			max-height: 0px;
			overflow: hidden;
		}}

		.image_block img+div {{
			display: none;
		}}

		sup,
		sub {{
			font-size: 75%;
			line-height: 0;
		}}

		@media (max-width:690px) {{
			.desktop_hide table.icons-inner {{
				display: inline-block !important;
			}}

			.icons-inner {{
				text-align: center;
			}}

			.icons-inner td {{
				margin: 0 auto;
			}}

			.image_block div.fullWidth {{
				max-width: 100% !important;
			}}

			.mobile_hide {{
				display: none;
			}}

			.row-content {{
				width: 100% !important;
			}}

			.stack .column {{
				width: 100%;
				display: block;
			}}

			.mobile_hide {{
				min-height: 0;
				max-height: 0;
				max-width: 0;
				overflow: hidden;
				font-size: 0px;
			}}

			.desktop_hide,
			.desktop_hide table {{
				display: table !important;
				max-height: none !important;
			}}

			.row-3 .column-1 .block-2.image_block .alignment div {{
				margin: 0 auto !important;
			}}
		}}
	</style>
	<!--[if mso ]><style>sup, sub {{ font-size: 100% !important; }} sup {{ mso-text-raise:10% }} sub {{ mso-text-raise:-10% }}</style> <![endif]-->
</head>

<body class=""body""
	style=""background-color: #ffffff; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;"">
	<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""nl-container"" role=""presentation""
		style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff;"" width=""100%"">
		<tbody>
			<tr>
				<td>
					<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""row row-1""
						role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
						<tbody>
							<tr>
								<td>
									<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0""
										class=""row-content stack"" role=""presentation""
										style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 670px; margin: 0 auto;""
										width=""670"">
										<tbody>
											<tr>
												<td class=""column column-1""
													style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;""
													width=""100%"">
													<div class=""spacer_block block-1""
														style=""height:10px;line-height:10px;font-size:1px;""> </div>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""row row-2""
						role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
						<tbody>
							<tr>
								<td>
									<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0""
										class=""row-content stack"" role=""presentation""
										style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 670px; margin: 0 auto;""
										width=""670"">
										<tbody>
											<tr>
												<td class=""column column-1""
													style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;""
													width=""100%"">
													<table border=""0"" cellpadding=""0"" cellspacing=""0""
														class=""image_block block-1"" role=""presentation""
														style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;""
														width=""100%"">
														<tr>
															<td class=""pad"" style=""width:100%;"">
																<div align=""center"" class=""alignment""
																	style=""line-height:10px"">
																	<div style=""max-width: 500px;""><img
																			alt=""Alternate text"" height=""auto""
																			src=""https://firebasestorage.googleapis.com/v0/b/urbanixphotos.appspot.com/o/Tourix%2FlogoTourix.png?alt=media&token=cf254d9a-ca92-4c6d-9ef6-d6d656b9f234""
																			style=""display: block; height: auto; border: 0; width: 100%;""
																			title=""Alternate text"" width=""500"" /></div>
																</div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""row row-3""
						role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
						<tbody>
							<tr>
								<td>
									<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0""
										class=""row-content stack"" role=""presentation""
										style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #2c2c54; color: #000000; width: 670px; margin: 0 auto;""
										width=""670"">
										<tbody>
											<tr>
												<td class=""column column-1""
													style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;""
													width=""100%"">
													<div class=""spacer_block block-1""
														style=""height:30px;line-height:30px;font-size:1px;""> </div>
													<table border=""0"" cellpadding=""0"" cellspacing=""0""
														class=""image_block block-2"" role=""presentation""
														style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;""
														width=""100%"">
														<tr>
															<td class=""pad""
																style=""width:100%;padding-right:0px;padding-left:0px;"">
																<div align=""center"" class=""alignment""
																	style=""line-height:10px"">
																	<div class=""fullWidth"" style=""max-width: 369px;"">
																		<img alt=""I'm an image"" height=""auto""
																			src=""https://firebasestorage.googleapis.com/v0/b/urbanixphotos.appspot.com/o/Tourix%2FimgThanks.png?alt=media&token=b44f7e96-ddee-4578-bb57-fcdee14c436e""
																			style=""display: block; height: auto; border: 0; width: 100%;""
																			title=""I'm an image"" width=""369"" /></div>
																</div>
															</td>
														</tr>
													</table>
													<table border=""0"" cellpadding=""0"" cellspacing=""0""
														class=""paragraph_block block-3"" role=""presentation""
														style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;""
														width=""100%"">
														<tr>
															<td class=""pad""
																style=""padding-bottom:10px;padding-left:40px;padding-right:40px;padding-top:10px;"">
																<div
																	style=""color:#ffffff;font-family:Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif;font-size:38px;line-height:150%;text-align:center;mso-line-height-alt:57px;"">
																	<p style=""margin: 0; word-break: break-word;"">
																		<strong><span
																				style=""word-break: break-word;"">Hola
																				{request.Nombre}, </span></strong></p>
																	<p style=""margin: 0; word-break: break-word;"">
																		<strong><span
																				style=""word-break: break-word;"">¡Gracias
																				por tu reserva!</span></strong></p>
																</div>
															</td>
														</tr>
													</table>
													<table border=""0"" cellpadding=""10"" cellspacing=""0""
														class=""paragraph_block block-4"" role=""presentation""
														style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;""
														width=""100%"">
														<tr>
															<td class=""pad"">
																<div
																	style=""color:#ffffff;font-family:Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif;font-size:22px;line-height:120%;text-align:center;mso-line-height-alt:26.4px;"">
																	<p style=""margin: 0; word-break: break-word;""><span
																			style=""word-break: break-word;"">Disfruta de
																			tu actividad<br /></span></p>
																</div>
															</td>
														</tr>
													</table>
													<div class=""spacer_block block-5""
														style=""height:55px;line-height:55px;font-size:1px;""> </div>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""row row-4""
						role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
						<tbody>
							<tr>
								<td>
									<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0""
										class=""row-content stack"" role=""presentation""
										style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 670px; margin: 0 auto;""
										width=""670"">
										<tbody>
											<tr>
												<td class=""column column-1""
													style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;""
													width=""100%"">
													<div class=""spacer_block block-1""
														style=""height:25px;line-height:25px;font-size:1px;""> </div>
													<table border=""0"" cellpadding=""0"" cellspacing=""0""
														class=""paragraph_block block-2"" role=""presentation""
														style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;""
														width=""100%"">
														<tr>
															<td class=""pad""
																style=""padding-left:20px;padding-right:20px;padding-top:10px;"">
																<div
																	style=""color:#191919;font-family:Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif;font-size:28px;line-height:150%;text-align:center;mso-line-height-alt:42px;"">
																	<p style=""margin: 0; word-break: break-word;""><span
																			style=""word-break: break-word;""><strong><span
																					style=""word-break: break-word;"">{request.NombreActividad}<br /></span></strong></span>
																	</p>
																</div>
															</td>
														</tr>
													</table>
													<table border=""0"" cellpadding=""5"" cellspacing=""0""
														class=""divider_block block-3"" role=""presentation""
														style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;""
														width=""100%"">
														<tr>
															<td class=""pad"">
																<div align=""center"" class=""alignment"">
																	<table border=""0"" cellpadding=""0"" cellspacing=""0""
																		role=""presentation""
																		style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;""
																		width=""15%"">
																		<tr>
																			<td class=""divider_inner""
																				style=""font-size: 1px; line-height: 1px; border-top: 2px solid #FFD3E0;"">
																				<span
																					style=""word-break: break-word;""> </span>
																			</td>
																		</tr>
																	</table>
																</div>
															</td>
														</tr>
													</table>
													<table border=""0"" cellpadding=""0"" cellspacing=""0""
														class=""divider_block block-4"" role=""presentation""
														style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;""
														width=""100%"">
														<tr>
															<td class=""pad"">
																<div align=""center"" class=""alignment"">
																	<table border=""0"" cellpadding=""0"" cellspacing=""0""
																		role=""presentation""
																		style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;""
																		width=""5%"">
																		<tr>
																			<td class=""divider_inner""
																				style=""font-size: 1px; line-height: 1px; border-top: 2px solid #FFD3E0;"">
																				<span
																					style=""word-break: break-word;""> </span>
																			</td>
																		</tr>
																	</table>
																</div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""row row-5""
						role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
						<tbody>
							<tr>
								<td>
									<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0""
										class=""row-content stack"" role=""presentation""
										style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 670px; margin: 0 auto;""
										width=""670"">
										<tbody>
											<tr>
												<td class=""column column-1""
													style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: middle; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;""
													width=""66.66666666666667%"">
													<div class=""spacer_block block-1 mobile_hide""
														style=""height:20px;line-height:20px;font-size:1px;""> </div>
													<table border=""0"" cellpadding=""0"" cellspacing=""0""
														class=""paragraph_block block-2"" role=""presentation""
														style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;""
														width=""100%"">
														<tr>
															<td class=""pad""
																style=""padding-bottom:10px;padding-left:40px;padding-right:10px;"">
																<div
																	style=""color:#34495e;font-family:Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif;font-size:20px;line-height:200%;text-align:left;mso-line-height-alt:40px;"">
																	<p style=""margin: 0;"">Nos complace confirmar que tu
																		reserva para {request.Fecha} ha sido
																		exitosa.<br /><br />Estamos emocionados de tener
																		la oportunidad de ofrecerte una experiencia
																		memorable. Si tienes alguna pregunta o requieres
																		asistencia adicional, no dudes en contactarnos.
																		Nuestro equipo está siempre disponible para
																		ayudarte con lo que necesites.</p>
																</div>
															</td>
														</tr>
													</table>
												</td>
												<td class=""column column-2""
													style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: middle; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;""
													width=""33.333333333333336%"">
													<table border=""0"" cellpadding=""0"" cellspacing=""0""
														class=""image_block block-1"" role=""presentation""
														style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;""
														width=""100%"">
														<tr>
															<td class=""pad""
																style=""padding-right:40px;width:100%;padding-left:0px;"">
																<div align=""center"" class=""alignment""
																	style=""line-height:10px"">
																	<div style=""max-width: 183.333px;""><img
																			alt=""I'm an image"" height=""auto""
																			src=""https://firebasestorage.googleapis.com/v0/b/urbanixphotos.appspot.com/o/Tourix%2FatencionCliente.png?alt=media&token=720190ca-1532-46d2-b36d-a12f2efcc2a3""
																			style=""display: block; height: auto; border: 0; width: 100%;""
																			title=""I'm an image"" width=""183.333"" />
																	</div>
																</div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
				</td>
			</tr>
		</tbody>
	</table><!-- End -->
</body>

</html>
";

                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("Tourix by Urbanix", _configuration["Email:Username"]));
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
