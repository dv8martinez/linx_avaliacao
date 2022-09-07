using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LINX.Avaliacao.Worker
{
  public static class EmailService
  {
    

    public static async Task<bool> EnviarEmail(decimal saldo){
      try
      {


        MailMessage message = new MailMessage();
        

        message.From = new MailAddress("remetente@linx.com", "LINX | Avaliação");
        message.To.Add(new MailAddress("email.usuario@linx.com"));
        

        

        message.Subject = $"Balaço do dia: {DateTime.Now.ToString("dd/MM/yyyy")}";
        message.IsBodyHtml = true;
        message.Body = $"Seu balanço de hoje está negativo de R${decimal.Round(saldo, 2)}";
        message.IsBodyHtml = true;
        message.Priority = MailPriority.High;

        using (SmtpClient smtp = new SmtpClient("SMTP.SMTP.COM", 449))
        {
          smtp.Credentials = new NetworkCredential("email.autenticador@linx.com", "senhaDoEMail@123");
          smtp.EnableSsl = false;
          smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
          smtp.UseDefaultCredentials = true;

          await smtp.SendMailAsync(message);
        }


       
        return true;
      }
      catch (Exception)
      {
        
        throw;
      }
    }
  }
}
