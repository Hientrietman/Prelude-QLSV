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
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery("select * from TaiKhoan");
            
            TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO(dt.Rows[0]);
            label1.Text = taiKhoanDTO.MaTK;
        }
    }
}
