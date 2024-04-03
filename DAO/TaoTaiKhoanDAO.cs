using DTO;
using System;

namespace DAO
{
    public class TaoTaiKhoanDAO
    {
        private TaoTaiKhoanDAO() { }
        private static TaoTaiKhoanDAO instance;
        string thucthe = "";
        string Ma = "";
        public static TaoTaiKhoanDAO Instance
        {
            get { if (instance == null) instance = new TaoTaiKhoanDAO(); return instance; }
            private set { instance = value; }
        }

        public bool TaoTaiKhoan(TaiKhoanDTO taikhoan)
        {


            string query = String.Format("INSERT INTO TaiKhoan (MaTK, TenDangNhap, MatKhau, VaiTro) VALUES ('{0}', '{1}', '{2}', {3})",
                                       taikhoan.MaTK, taikhoan.TenDangNhap, taikhoan.MatKhau, taikhoan.VaiTro);
            string query2 = String.Format("update {0} SET MaTK ='{1}' where {2} = '{3}'", thucthe, taikhoan.TenDangNhap, Ma,taikhoan.TenDangNhap);
            int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query);
            int rowAffedted2 = DataProvider.Instance.ExecuteNonQuery(query2);
            return rowsAffected + rowAffedted2 > 1;

       


            //ThemTaiKhoanVoiVaiTro(taikhoan);


        }

        public static bool KiemTraTrungLap(string matk)
        {
            // Viết truy vấn SQL để kiểm tra mã tài khoản trong cơ sở dữ liệu
            string query = String.Format("SELECT COUNT(*) FROM TaiKhoan WHERE MaTK = '{0}'", matk);

            // Thực hiện truy vấn và trả về số lượng tài khoản có cùng mã với mã được truyền vào
            int count = (int)DataProvider.Instance.ExecuteScalar(query);

            // Nếu số lượng tài khoản có mã tương tự lớn hơn 0, tức là mã tài khoản đã tồn tại trong hệ thống
            // Trả về true để báo là trùng lặp, ngược lại trả về false
            return count > 0;
        }
        private bool ThemTaiKhoanVoiVaiTro(TaiKhoanDTO taiKhoan)
        {
            return true;
        }

        public bool KiemTraThucThe(TaiKhoanDTO taikhoan)
        {
           
            if (taikhoan.VaiTro == 0)
            {
                thucthe = "SinhVien";
                Ma = "MaSV";
            }
            else if (taikhoan.VaiTro == 1)
            {
                thucthe = "GiangVien";
                Ma = "MaGV";
            }
            else
            {
                thucthe = "QuanLy";
                Ma = "MaNQL";
            }

            string query = String.Format("select COUNT(*) from {0} where {1} = '{2}'", thucthe,Ma, taikhoan.MaTK);
            int count = (int)DataProvider.Instance.ExecuteScalar(query);
            return count > 0;
        }
        
    }

}
