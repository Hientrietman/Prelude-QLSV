using BUS;
using System;

using System.Windows.Forms;

namespace GUI
{
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
        }
        
        private void btnGuiMa_Click(object sender, EventArgs e)
        {
            if (QuenMatKhauBUS.Instance.KiemTraEmail(txtEmail.Text))
            {
                string email = txtEmail.Text; // Lấy địa chỉ email từ textbox
                string otp = QuenMatKhauBUS.Instance.GenerateOTP(); // Tạo mã OTP
                QuenMatKhauBUS.Instance.SendEmail(email, otp); // Gửi email chứa mã OTP

                // Hiển thị thông báo cho người dùng
                MessageBox.Show("Mã OTP đã được gửi đến địa chỉ email của bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy địa chỉ mail trên, vui lòng kiểm tra hoặc cập nhật lại địa chỉ mail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            
        }
    }
}
