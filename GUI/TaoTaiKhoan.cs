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
            TaiKhoanDTO taiKhoan = new TaiKhoanDTO();
            taiKhoan.MaTK = "AAA";
            taiKhoan.TenDangNhap=Klabel_nhaptentaikhoan.Text;
            taiKhoan.MatKhau =Klabel_nhapmatkhau.Text;
            taiKhoan.VaiTro= Kcb_chonloaitaikhoan.SelectedIndex;

            TaoTaiKhoanBUS.Instance.TaoTaiKhoan(taiKhoan);
        }

        
    }
}
