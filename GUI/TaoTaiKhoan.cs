using BUS;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class TaoTaiKhoan : Form
    {
      
        public TaoTaiKhoan()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Kiểm tra tính hợp lệ của các trường dữ liệu đầu vào
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassWord.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng TaiKhoanDTO từ các trường dữ liệu người dùng nhập vào
            TaiKhoanDTO taiKhoan = new TaiKhoanDTO(txtUserName.Text, txtUserName.Text, txtPassWord.Text, Kcb_chonloaitaikhoan.SelectedIndex);

            // Gọi phương thức tạo tài khoản từ lớp BUS
            bool isSuccess = TaoTaiKhoanBUS.Instance.TaoTaiKhoan(taiKhoan);

            // Hiển thị thông báo tương ứng với kết quả tạo tài khoản
            if (isSuccess)
            {
                MessageBox.Show("Tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tạo tài khoản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
