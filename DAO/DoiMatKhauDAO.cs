using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DoiMatKhauDAO
    {
        private DoiMatKhauDAO() { }
        private static DoiMatKhauDAO instance;
        public static DoiMatKhauDAO Instance
        {
            get { if (instance == null) instance = new DoiMatKhauDAO(); return instance; }
            private set { instance = value; }
        }

        public void DoiMatKhau(string Email, string NewPass)
        {
            string query = String.Format("declare @user varchar(50)" +
                "set @user = (select MaTK from SinhVien where Email = '{0}')" +
            "update TaiKhoan set MatKhau = '{1}' where MaTK = @user", Email, NewPass);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void DoiMatKhauMoi(string Email, string OldPass, string NewPass)
        {
            string query1 = String.Format("declare @user varchar(50)" +
                "set @user = (select MaTK from SinhVien where Email = '{0}')" +
            "update TaiKhoan set MatKhau = '{2}' where MatKhau = '{1}' and MaTK = @user", Email, OldPass, NewPass);
            DataProvider.Instance.ExecuteNonQuery(query1);
        }
    }
}

