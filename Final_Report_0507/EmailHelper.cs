using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Final_Report_0507
{
    public static class EmailHelper
    {
        private const string ApiKey = "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"; // ← 把這裡改成你的實際 API 金鑰
        private const string FromEmail = "n10170015@std.must.edu.tw"; // 可以設定你想顯示的寄件信箱
        private const string FromName = "借書系統通知";

        public static async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var client = new SendGridClient(ApiKey);
            var from = new EmailAddress(FromEmail, FromName);
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, body, null);
            var response = await client.SendEmailAsync(msg);

            // 可選：檢查是否成功
            if ((int)response.StatusCode >= 400)
            {
                throw new Exception($"寄信失敗（狀態碼：{response.StatusCode}）");
            }
        }
    }
}
