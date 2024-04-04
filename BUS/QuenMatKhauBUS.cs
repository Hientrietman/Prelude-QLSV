using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class QuenMatKhauBUS
    {
        private QuenMatKhauBUS() { }
        private static QuenMatKhauBUS instance;
        public static QuenMatKhauBUS Instance
        {
            get { if (instance == null) instance = new QuenMatKhauBUS(); return instance; }
            private set { instance = value; }
        }

        public string GenerateOTP()
        {
            // Tạo OTP 6 số
            Random random = new Random();
            return random.Next(100000, 999999).ToString(); // Tạo một số ngẫu nhiên 6 chữ số
        }

        public void SendEmail(string toEmail, string otp)
        {
            // Thông tin tài khoản email
            // nhập tên email với cái mật khẩu ứng dụng để làm
            string fromEmail = "";
            string password = "";

            // Tạo và cấu hình đối tượng SmtpClient
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587; // Port của SMTP server
            client.EnableSsl = true; // Sử dụng SSL để bảo mật kết nối
            client.Credentials = new NetworkCredential(fromEmail, password); // Cung cấp thông tin xác thực cho SMTP server

            // Tạo và cấu hình đối tượng MailMessage
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromEmail);
            message.To.Add(toEmail);
            message.Subject = "Mã OTP";
            message.Body = "Mã OTP của bạn là: " + otp;

            // Gửi email
            client.Send(message);
        }

        public bool KiemTraEmail(string Email)
        {
            return QuenMatKhauDAO.Instance.KiemTraEmail(Email);
        }
    }
}
