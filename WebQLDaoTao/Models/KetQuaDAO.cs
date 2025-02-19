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
        public List<KetQua> getAll()
        {
            List<KetQua> dsKetQua = new List<KetQua>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from KetQua", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                KetQua mh = new KetQua { Id = int.Parse(dr["Id"].ToString()), MaSV = dr["MaSV"].ToString(), MaMH = dr["MaMH"].ToString(), Diem = float.Parse(dr["Diem"].ToString()), HoTenSV = dr["HoTenSV"].ToString() };
                dsKetQua.Add(mh);
            }
            return dsKetQua;

        }
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
        public int Delete(int id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from KetQua where id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }
        public List<KetQua> findByMaMH(string mamh)
        {
            List<KetQua> dsKetQua = new List<KetQua>();
            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select id, KetQua.masv, mamh, diem, hosv, tensv from KetQua inner join SinhVien on KetQua.masv = SinhVien.masv where mamh = @mamh", conn);
            cmd.Parameters.AddWithValue("@mamh", mamh);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                KetQua kq = new KetQua();
                kq.Id = int.Parse(dr["id"].ToString());
                kq.MaSV = dr["masv"].ToString();
                kq.MaMH = dr["mamh"].ToString();
                if(dr["diem"] != DBNull.Value)
                {
                    kq.Diem = float.Parse(dr["diem"].ToString());
                }
                kq.HoTenSV = dr["hosv"] + " " + dr["tensv"];
                dsKetQua.Add(kq);
            }
            return dsKetQua;
        }
    }
}