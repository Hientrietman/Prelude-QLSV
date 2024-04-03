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
            // Kiểm tra các trường thông tin không được bỏ trống
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassWord.Text) || Kcb_chonloaitaikhoan.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra tên đăng nhập không trùng lặp
            if (KiemTraTenDangNhapTrungLap(txtUserName.Text))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại trong hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mật khẩu theo các quy định
            if (!KiemTraMatKhauHopLe(txtPassWord.Text))
            {
                MessageBox.Show("Mật khẩu không đủ mạnh. Mật khẩu phải chứa ít nhất 8 ký tự, bao gồm ít nhất một chữ cái viết hoa, một chữ cái viết thường, một số và một ký tự đặc biệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo tài khoản mới
            TaiKhoanDTO taiKhoan = new TaiKhoanDTO(txtUserName.Text, txtUserName.Text, txtPassWord.Text, Kcb_chonloaitaikhoan.SelectedIndex);

            // Thêm tài khoản mới vào cơ sở dữ liệu
        
            if (!TaoTaiKhoanBUS.Instance.KiemTraThucThe(taiKhoan))
            {
                MessageBox.Show(String.Format("Không có {0} nào có mã {1} tồn tại ! ", Kcb_chonloaitaikhoan.SelectedItem, taiKhoan.MaTK), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (TaoTaiKhoanBUS.Instance.TaoTaiKhoan(taiKhoan))
                {
                    MessageBox.Show("Tạo tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tạo tài khoản không thành công. Vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


        private bool KiemTraTenDangNhapTrungLap(string matk)
        {
            return TaoTaiKhoanBUS.KiemTraTrungLap(matk);
        }

        private bool KiemTraMatKhauHopLe(string matKhau)
        {
            // Kiểm tra độ dài của mật khẩu
            if (matKhau.Length < 8)
                return false;

            // Kiểm tra xem mật khẩu có ít nhất một chữ cái viết hoa
            if (!matKhau.Any(char.IsUpper))
                return false;

            // Kiểm tra xem mật khẩu có ít nhất một chữ cái viết thường
            if (!matKhau.Any(char.IsLower))
                return false;

            // Kiểm tra xem mật khẩu có ít nhất một số
            if (!matKhau.Any(char.IsDigit))
                return false;

            // Kiểm tra xem mật khẩu có ít nhất một ký tự đặc biệt
            if (!matKhau.Any(ch => !char.IsLetterOrDigit(ch)))
                return false;

            // Nếu tất cả các điều kiện đều được thỏa mãn, trả về true
            return true;
        }


    }
}




