using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DoiMatKhauBUS
    {
        private DoiMatKhauBUS() { }
        private static DoiMatKhauBUS instance;
        public static DoiMatKhauBUS Instance
        {
            get { if (instance == null) instance = new DoiMatKhauBUS(); return instance; }
            private set { instance = value; }
        }
        public void DoiMatKhau(string Email, string NewPass)
        {
            DoiMatKhauDAO.Instance.DoiMatKhau(Email, NewPass);
        }
        public void DoiMatKhauMoi(string Email, string OldPass, string NewPass)
        {
            DoiMatKhauDAO.Instance.DoiMatKhauMoi(Email, OldPass, NewPass);
        }
    }
}

