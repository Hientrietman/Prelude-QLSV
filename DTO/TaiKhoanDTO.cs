using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    using System;
    using System.Data;

    public class TaiKhoanDTO
    {
        public string MaTK { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int VaiTro { get; set; }
        public int? TrangThai { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }

        public TaiKhoanDTO()
        {
        }

        public TaiKhoanDTO(DataRow row)
        {
            MaTK = row["MaTK"].ToString();
            TenDangNhap = row["TenDangNhap"].ToString();
            MatKhau = row["MatKhau"].ToString();
            VaiTro = Convert.ToInt32(row["VaiTro"]);
            TrangThai = row["TrangThai"] != DBNull.Value ? Convert.ToInt32(row["TrangThai"]) : (int?)null;
            Email = row["Email"].ToString();
            SDT = row["SDT"].ToString();
            NgaySinh = Convert.ToDateTime(row["NgaySinh"]);
            DiaChi = row["DiaChi"].ToString();
            HoTen = row["HoTen"].ToString();
            GioiTinh = row["GioiTinh"].ToString();
        }

      
    }

}
