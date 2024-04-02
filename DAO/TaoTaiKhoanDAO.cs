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
            string query = String.Format("INSERT INTO TaiKhoan (MaTK, TenDangNhap, MatKhau, VaiTro, HoTen) VALUES ('{0}','{1}','{2}',{3},'{4}')", taikhoan.TenDangNhap, taikhoan.TenDangNhap, taikhoan.MatKhau, taikhoan.VaiTro, taikhoan.HoTen);

            int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query);

            return rowsAffected > 0;
        }
    }
}
