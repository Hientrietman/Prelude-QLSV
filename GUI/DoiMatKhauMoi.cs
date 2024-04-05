using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GUI
{
    public partial class DoiMatKhauMoi : Form
    {
        public DoiMatKhauMoi()
        {
            InitializeComponent();
        }
        public string email;
        public string oldPass;

        //kiểm tra xem người dùng đã nhập đầy đủ thông tin hay chưa
        public bool KiemTraMatKhau()
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            if (txtOldPass.Text == "")
            {
                lblShowInfor1.ForeColor = System.Drawing.Color.Red;
                lblShowInfor1.Text = "Vui lòng nhập mật khẩu cũ!";
                txtOldPass.Focus();
                return false;
            }
            else if (txtNewPass.Text == "")
            {
                lblShowInfor2.ForeColor = System.Drawing.Color.Red;
                lblShowInfor2.Text = "Vui lòng nhập mật khẩu mới!";
                txtNewPass.Focus();
                return false;
            }
            else if (txtNewPass.Text.Length < 8)
            {
                lblShowInfor2.ForeColor = System.Drawing.Color.Red;
                lblShowInfor2.Text = "Mật khẩu phải nhiều hơn 7 kí tự!";
                txtNewPass.Focus();
                return false;
            }
            else if (txtConfPass.Text == "")
            {
                lblShowInfor3.ForeColor = System.Drawing.Color.Red;
                lblShowInfor3.Text = "Vui lòng xác nhận mật khẩu!";
                txtConfPass.Focus();
                return false;
            }
            else if (txtOldPass.Text != oldPass)
            {
                lblShowInfor3.ForeColor = System.Drawing.Color.Red;
                lblShowInfor3.Text = "Mật khẩu cũ không đúng";
                txtOldPass.Focus();
                return false;
            }
            else if (txtNewPass.Text != txtConfPass.Text)
            {
                lblShowInfor3.ForeColor = System.Drawing.Color.Red;
                lblShowInfor3.Text = "Mật khẩu mới và mật khẩu xác nhận không trùng khớp";
                txtConfPass.Focus();
                txtConfPass.SelectAll();
                return false;
            }
            else if (!hasLowerChar.IsMatch(txtNewPass.Text))
            {
                lblShowInfor2.ForeColor = System.Drawing.Color.Red;
                lblShowInfor2.Text = "Mật khẩu mới phải có ít nhất 1 chữ cái thường";
                txtConfPass.Focus();
                txtConfPass.SelectAll();
                return false;
            }
            else if (!hasUpperChar.IsMatch(txtNewPass.Text))
            {
                lblShowInfor2.ForeColor = System.Drawing.Color.Red;
                lblShowInfor2.Text = "Mật khẩu mới phải có ít nhất 1 chữ cái in hoa";
                txtConfPass.Focus();
                txtConfPass.SelectAll();
                return false;
            }
            else if (!hasNumber.IsMatch(txtNewPass.Text))
            {
                lblShowInfor2.ForeColor = System.Drawing.Color.Red;
                lblShowInfor2.Text = "Mật khẩu mới phải có ít nhất 1 chữ số";
                txtConfPass.Focus();
                txtConfPass.SelectAll();
                return false;
            }

            else if (!hasSymbols.IsMatch(txtNewPass.Text))
            {
                lblShowInfor2.ForeColor = System.Drawing.Color.Red;
                lblShowInfor2.Text = "Mật khẩu mới phải có ít nhất 1 chữ kí tự đặc biệt";
                txtConfPass.Focus();
                txtConfPass.SelectAll();
                return false;
            }
            return true;
        }

        private void chkHienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            //Xử lí sự kiện checkbox Hiển thị mật khẩu
            if (chkHienThiMK.Checked)
            {
                txtOldPass.PasswordChar = (char)0;
                txtNewPass.PasswordChar = (char)0;
                txtConfPass.PasswordChar = (char)0;
            }
            else
            {
                txtOldPass.PasswordChar = '*';
                txtNewPass.PasswordChar = '*';
                txtConfPass.PasswordChar = '*';
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (KiemTraMatKhau())
            {
                DoiMatKhauBUS.Instance.DoiMatKhauMoi(email, txtOldPass.Text, txtNewPass.Text);
                // Hiển thị thông báo cho người dùng
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

                TrangChuSinhVien trangChuSinhVien = new TrangChuSinhVien();
                trangChuSinhVien.ShowDialog();
                this.Close();
            }
        }
    }
}
