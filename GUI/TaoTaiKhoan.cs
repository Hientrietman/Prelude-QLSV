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
           
            string MaTK = txtUserName.Text;
            string matkhau = txtPassWord.Text;
            string tendangnhap = txtUserName.Text;
            int vaitro = Kcb_chonloaitaikhoan.SelectedIndex +1;
           
            TaiKhoanDTO taiKhoan = new TaiKhoanDTO(MaTK,matkhau,tendangnhap,vaitro);


            if (TaoTaiKhoanBUS.Instance.TaoTaiKhoan(taiKhoan))
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
