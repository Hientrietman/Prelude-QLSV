using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class QuenMatKhauDAO
    {
        private QuenMatKhauDAO() { }
        private static QuenMatKhauDAO instance;
        public static QuenMatKhauDAO Instance
        {
            get { if (instance == null) instance = new QuenMatKhauDAO(); return instance; }
            private set { instance = value; }
        }

        public bool KiemTraEmail(string Email)
        {
            string query = String.Format("SELECT CASE WHEN EXISTS (SELECT 1 FROM SinhVien WHERE Email = '{0}') " +
                           "OR EXISTS (SELECT 1 FROM QuanLy WHERE Email = '{0}') " +
                           "OR EXISTS (SELECT 1 FROM GiangVien WHERE Email = '{0}') " +
                           "THEN 1 ELSE 0 END",Email);

            int exists = (int)DataProvider.Instance.ExecuteScalar(query);
            return exists == 1;
        }
    }
}
