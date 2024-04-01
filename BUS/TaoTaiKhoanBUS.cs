using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TaoTaiKhoanBUS
    {
        private TaoTaiKhoanBUS(){ }
        private static TaoTaiKhoanBUS instance;
        public static TaoTaiKhoanBUS Instance
        {
            get { if (instance == null) instance = new TaoTaiKhoanBUS(); return instance; }
            private set { instance = value; }
        }

        public void TaoTaiKhoan(TaiKhoanDTO taikhoan)
        {
      
            TaoTaiKhoanDAO.Instance.TaoTaiKhoan(taikhoan);
        }
    }
}
