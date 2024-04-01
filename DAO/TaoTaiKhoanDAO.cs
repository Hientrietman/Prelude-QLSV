using DTO;
using System;

namespace DAO
{
    public class TaoTaiKhoanDAO
    {
        private TaoTaiKhoanDAO() { }
        private static TaoTaiKhoanDAO instance;
        public static TaoTaiKhoanDAO Instance
        {
            get { if (instance == null) instance = new TaoTaiKhoanDAO(); return instance; }
            private set { instance = value; }
        }

        public bool TaoTaiKhoan(TaiKhoanDTO taikhoan)
        {
            string query = "";

            int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query);

            if (rowsAffected > 0)
            {
               return true;
            }
            else
            {
               return false;
            }
        }
    }
}
