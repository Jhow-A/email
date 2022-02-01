using System;
using System.Net;
using System.Net.Mail;

namespace EnvioEmail
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var client = new SmtpClient())
                using (var mail = new MailMessage())
                {
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("Email", "Senha");

                    mail.Sender = new MailAddress("EmailQueEnvia", "Enviador");
                    mail.From = new MailAddress("remetente@email.com", "'De: NomeAqui'");
                    mail.To.Add(new MailAddress("destinatario@email.com", "'Para: NomeAqui'"));
                    mail.Subject = "TESTE";
                    mail.Body = "Testando envio de e-mails no <b> C# <b/>";
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;

                    client.Send(mail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
            }
        }
    }
}
