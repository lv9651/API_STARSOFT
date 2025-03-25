using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

public class CorreoService
{
    private readonly IConfiguration _configuration;

    public CorreoService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public static string ConvertirImagenA_Base64(string rutaImagen)
    {
        try
        {
            byte[] imagenBytes = File.ReadAllBytes(rutaImagen);
            return Convert.ToBase64String(imagenBytes);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al convertir la imagen a Base64: {ex.Message}");
            return string.Empty;
        }
    }
    public async Task EnviarDetallesCitaAsync(CitaMedica citaMedica)
    {
        string imagePath = @"\\PANDAFILE\Intranet\clinica\Logo_Vinali.png";  // Asegúrate de que la ruta sea correcta
        string mesa = @"\\PANDAFILE\Intranet\clinica\fondo_mesa.png";
        string correo = @"\\PANDAFILE\Intranet\clinica\correo.png";
        string instagram = @"\\PANDAFILE\Intranet\clinica\instagram.png";
        string telefono = @"\\PANDAFILE\Intranet\clinica\telefono.png";
        string web = @"\\PANDAFILE\Intranet\clinica\web.png";
        string youtube = @"\\PANDAFILE\Intranet\clinica\youtube.png";
        string facebook = @"\\PANDAFILE\Intranet\clinica\facebook.png"; // Icono de Facebook

        var email = new MimeMessage();
        email.From.Add(new MailboxAddress("Clinica Vinali", _configuration["SmtpSettings:Username"]));
        email.To.Add(new MailboxAddress("", citaMedica.Email));
        email.Subject = $"Confirmación de Cita - {citaMedica.Nombre}";

        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = $@"
    <html>
    <head>
        <style>
            body {{
                font-family: Arial, sans-serif;
                background-color: #f4f4f4;
                margin: 0;
                padding: 20px;
                text-align: center;
            }}
            .container {{
                max-width: 600px;
                background: #ffffff;
                padding: 20px;
                border-radius: 8px;
                box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
                margin: auto;
            }}
            .header {{
                text-align: center;
                padding-bottom: 20px;
            }}
            .header img {{
                max-width: 120px;
            }}
            .title {{
                color: #00A6D6;
                font-size: 22px;
                font-weight: bold;
            }}
            .details {{
                text-align: left;
                margin-top: 20px;
                background-image: url('cid:logoMesa');  /* Usamos el ContentID para el fondo */
                background-size: cover; /* Ajustar la imagen de fondo al tamaño del div */
                background-position: center; /* Centrar la imagen */
                padding: 20px;
                border-radius: 8px;
            }}
            .details p {{
                font-size: 16px;
                margin: 5px 0;
                color: #084a79;  /* Cambié el color de texto a #084a79 */
            }}
            .important {{
                background: #e7f5ff;
                padding: 15px;
                border-radius: 5px;
                margin-top: 20px;
                text-align: left;
            }}
            .button {{
                margin-top: 20px;
                display: inline-block;
                padding: 10px 20px;
                font-size: 16px;
                background: #00A6D6;
                color: white;
                text-decoration: none;
                border-radius: 5px;
            }}
            .footer {{
                margin-top: 20px;
                font-size: 14px;
                color: #666;
                text-align: center;
            }}
            .footer img {{
                width: 30px;
                margin: 0 10px;
            }}
        </style>
    </head>
    <body>
        <div class='container'>
            <div class='header'>
                <img src='cid:logoImage'  alt='Vinali' />
                <h2 class='title'>¡Tu piel está en buenas manos!</h2>
            </div>
            
            <p>Hola, <strong>{citaMedica.Nombre}</strong>,</p>
            <p>Gracias por confiar en nosotros. Tu cita ha sido agendada con éxito. Aquí tienes todos los detalles:</p>
            
            <div class='details'>
                <p><strong>Paciente:</strong> {citaMedica.Nombre}</p>
                <p><strong>Especialidad:</strong> {citaMedica.Especialidad}</p>
                <p><strong>Médico:</strong> {citaMedica.Medico}</p>
                <p><strong>Horario:</strong> {citaMedica.Dia} a las {citaMedica.Hora}</p>
                <p><strong>Lugar:</strong> {citaMedica.Sucursal}</p>
            </div>

            <div class='important'>
                <p><strong>Importante:</strong></p>
                <ul>
                    <li>Llega 10 minutos antes de tu cita para un mejor servicio.</li>
                    <li>Si necesitas reprogramar, hazlo con al menos 24 horas de anticipación.</li>
                    <li>Para consultas o cambios, contáctanos al 993 805 070</li>
                </ul>
                <p><strong>Tip Vinali:</strong> Antes de tu consulta, evita usar maquillaje o cremas en la zona a evaluar para un mejor diagnóstico.</p>
            </div>

            <a href='https://www.vinali.pe' class='button'>Contáctanos</a>

            <p class='footer'>
                Nos vemos pronto,<br>El equipo de Vinali<br>
                <a href='https://www.facebook.com/vinaliclinica' target='_blank'><img src='cid:facebookImage' alt='' /></a>
                <a href='tel:+993805070'><img src='cid:telefonoImage' alt='Teléfono' /></a>
                <a href='mailto:info@vinali.pe'><img src='cid:correoImage' alt='Correo' /></a>
                <a href='https://www.vinali.pe' target='_blank'><img src='cid:webImage' alt='Web' /></a>
            </p>
        </div>
    </body>
    </html>"
        };

        // Adjuntar las imágenes al correo con ContentIDs correctos
        bodyBuilder.LinkedResources.Add(facebook).ContentId = "facebookImage";
        bodyBuilder.LinkedResources.Add(imagePath).ContentId = "logoImage";
        bodyBuilder.LinkedResources.Add(mesa).ContentId = "logoMesa";
        bodyBuilder.LinkedResources.Add(telefono).ContentId = "telefonoImage";
        bodyBuilder.LinkedResources.Add(correo).ContentId = "correoImage";
        bodyBuilder.LinkedResources.Add(web).ContentId = "webImage";
       

        email.Body = bodyBuilder.ToMessageBody();

        using (var smtpClient = new SmtpClient())
        {
            try
            {
                await smtpClient.ConnectAsync(_configuration["SmtpSettings:Host"], int.Parse(_configuration["SmtpSettings:Port"]), SecureSocketOptions.StartTls);
                await smtpClient.AuthenticateAsync(_configuration["SmtpSettings:Username"], _configuration["SmtpSettings:Password"]);
                await smtpClient.SendAsync(email);
                Console.WriteLine("Correo enviado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            }
            finally
            {
                if (smtpClient.IsConnected)
                {
                    await smtpClient.DisconnectAsync(true);
                }
                smtpClient.Dispose();
            }
        }
    }
}