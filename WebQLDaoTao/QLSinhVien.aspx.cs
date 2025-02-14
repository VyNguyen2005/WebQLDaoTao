using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;
namespace WebQLDaoTao
{
    public partial class QLSinhVien : System.Web.UI.Page
    {
        SinhVienDAO svDAO = new SinhVienDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            List<Khoa> khoaNames = svDAO.GetAllKhoaNames();
            ddlMaKhoa.DataSource = khoaNames;
            ddlMaKhoa.DataTextField = "TenKH";
            ddlMaKhoa.DataValueField = "MaKH";
            ddlMaKhoa.DataBind();
        }

        protected void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                
                string masv =  txtMaSV.Text;
                if (svDAO.findById(masv) != null)
                {
                    Response.Write("<script>alert('Mã sinh viên đã tồn tại. Chọn mã khác nhé.')</script>");
                    return;
                }
                string hosv = txtHoSv.Text;
                string tensv = txtTenSV.Text;
                Boolean gioitinh = rdNam.Checked ? true : false;
                DateTime ngaysinh = DateTime.Parse(txtNgaysinh.Text);
                string noisinh = txtNoiSinh.Text;
                string diachi = txtDiaChi.Text;
                string makh = ddlMaKhoa.SelectedValue;
                SinhVien svInsert = new SinhVien { MaSV = masv, HoSV = hosv, TenSV = tensv, GioiTinh = gioitinh, NgaySinh = ngaysinh, NoiSinh = noisinh, DiaChi = diachi, MaKH = makh };
                svDAO.Insert(svInsert);
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Thao tác thêm sinh viên không thành công.')</script>");
            }
            gv_SinhVien.DataBind();
        }
    }
}