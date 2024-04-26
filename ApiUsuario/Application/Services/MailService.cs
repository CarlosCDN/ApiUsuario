using System.Net;
using System.Net.Mail;

namespace ApiUsuario.Application.Services;

public static class MailService 
{
    public static bool Send(string email, string newPassword)
    {
        MailMessage emailMessage = new MailMessage();
        try
        {
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 60 * 60;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("", "");
            
            emailMessage.From = new MailAddress("", "");
            emailMessage.Body = "Testando envio";
            emailMessage.Subject = "Troca de senha:";
            emailMessage.IsBodyHtml = true;
            emailMessage.Priority = MailPriority.Normal;
            emailMessage.To.Add(email);

            smtpClient.Send(emailMessage);
            return true;
        }
        catch (Exception ex) 
        {
            return false;
        }
    }
} 
