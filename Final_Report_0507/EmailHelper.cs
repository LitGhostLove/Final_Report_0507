using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace Final_Report_0507
{
    public static class EmailHelper
    {
        public static async Task SendMailAsync(string toEmail, string subject, string body)
        {
            var message = new MailMessage();
            message.From = new MailAddress("your_email@gmail.com"); // 換成你的寄件者
            message.To.Add(toEmail);
            message.Subject = subject;
            message.Body = body;

            using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.Credentials = new NetworkCredential("your_email@gmail.com", "your_app_password");
                smtpClient.EnableSsl = true;

                await smtpClient.SendMailAsync(message);  // 🔹 非同步寄信
            }
        }
    }
}
