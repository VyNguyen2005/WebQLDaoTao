using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebQLDaoTao.Models
{
    public class KetQuaDAO
    {
        public int Update(int id, float diem)
        {
            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("update ketqua set diem=@diem where id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@diem", diem);
            return cmd.ExecuteNonQuery();
        }
        public List<KetQua> findByMaMH(string mamh)
        {
            List<KetQua> dsKetQua = new List<KetQua>();
            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID, KetQua.MASV, MAMH, DIEM, HOSV, TENSV FROM KetQua INNER JOIN SinhVien ON KetQua.MASV = SinhVien.MASV where mamh = @mamh", conn);
            cmd.Parameters.AddWithValue("@mamh", mamh);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                KetQua kq = new KetQua();
                kq.Id = int.Parse(dr["Id"].ToString());
                kq.MaSV = dr["Masv"].ToString();
                kq.MaMH = dr["mamh"].ToString();
                kq.Diem = string.IsNullOrEmpty(dr["diem"].ToString()) ? 0 : float.Parse(dr["diem"].ToString());
                kq.HoTenSV = dr["hosv"] + " " + dr["tensv"];
                dsKetQua.Add(kq);
            }
            return dsKetQua;
        }
    }
}