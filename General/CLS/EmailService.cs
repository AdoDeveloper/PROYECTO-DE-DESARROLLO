using DataLayer.MODELOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    public class EmailService
    {
        public static void EnviarFacturaPorCorreo(FacturaModel factura, string destinatario)
        {
            try
            {
                // Configurar el cliente SMTP
                SmtpClient client = new SmtpClient("smtp.office365.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("sisventas@outlook.es", "DS2024SISTEMA$"),
                    EnableSsl = true
                };

                // Crear el mensaje de correo
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("sisventas@outlook.es"),
                    Subject = "Factura de Compra",
                    Body = CrearCuerpoCorreo(factura),
                    IsBodyHtml = true
                };
                mailMessage.To.Add(destinatario);

                // Adjuntar la factura (si es un archivo, debes generarlo y adjuntarlo)
                // string filePath = GenerarPDF(factura); // Método para generar un PDF de la factura
                // mailMessage.Attachments.Add(new Attachment(filePath));

                // Enviar el correo
                client.Send(mailMessage);

                Console.WriteLine("Correo enviado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }
        }

        private static string CrearCuerpoCorreo(FacturaModel factura)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<h1>Factura de Compra</h1>");
            sb.AppendFormat("<p>No. Factura: {0}</p>", factura.No_factura);
            sb.AppendFormat("<p>Fecha: {0}</p>", factura.Fecha);
            sb.AppendFormat("<p>Total: {0:C}</p>", factura.Total);
            sb.AppendFormat("<p>Cliente: {0}</p>", factura.Cliente.Cliente); // Asegúrate de tener un campo Nombre en ClienteModel
            sb.Append("<h2>Detalles:</h2>");
            sb.Append("<ul>");
            foreach (var detalle in factura.Detalles)
            {
                sb.AppendFormat("<li>Producto: {0}, Cantidad: {1}, Precio Unitario: {2:C}, Subtotal: {3:C}</li>",
                    detalle.Id_producto, detalle.Cantidad, detalle.Precio_unitario, detalle.Subtotal);
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        // Método para generar un PDF (opcional)
        // private static string GenerarPDF(FacturaModel factura)
        // {
        //     // Lógica para generar un archivo PDF y devolver la ruta del archivo
        // }
    }
}
