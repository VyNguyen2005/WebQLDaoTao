using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
namespace WebQLDaoTao.Models
{
    public class MonHocDAO
    {
        public List<MonHoc> getAll()
        {
            List<MonHoc> dsMonHoc = new List<MonHoc>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Monhoc", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MonHoc mh = new MonHoc { MaMH = dr["MaMH"].ToString(), TenMH = dr["TenMH"].ToString(), SoTiet = int.Parse(dr["SoTiet"].ToString()) };
                dsMonHoc.Add(mh);
            }
            return dsMonHoc;

        }
        public int Update(MonHoc mh)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Monhoc set tenmh=@tenmh, sotiet=@sotiet where mamh=@mamh", conn);
            cmd.Parameters.AddWithValue("@tenmh", mh.TenMH);
            cmd.Parameters.AddWithValue("@sotiet", mh.SoTiet);
            cmd.Parameters.AddWithValue("@mamh", mh.MaMH);
            return cmd.ExecuteNonQuery();
        }
    }
}