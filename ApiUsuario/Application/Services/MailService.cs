using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace ApiUsuario.Application.Services;

public class MailService
{
    private readonly string _senderEmail;
    private readonly string _senderPassword;

    public MailService(string senderEmail, string senderPassword)
    {
        _senderEmail = senderEmail;
        _senderPassword = senderPassword;
    }

    public bool SendeMail(string recipientEmail, string subject, string message)
    {
        try
        {
            var smtpClient = new SmtpClient("smtp-mail.outlook.com");
            smtpClient.Port = 587;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(_senderEmail, _senderPassword);

            var emailMessage = new MailMessage(_senderEmail, recipientEmail)
            {
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
                Priority = MailPriority.Normal

            };
            smtpClient.Send(emailMessage);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}