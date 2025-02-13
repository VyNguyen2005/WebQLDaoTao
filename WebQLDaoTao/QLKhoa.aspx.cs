﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;
namespace WebQLDaoTao
{
    public partial class QLKhoa : System.Web.UI.Page
    {
        KhoaDAO khDAO = new KhoaDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string makh = txtMaKH.Text;
                string tenkh = txtTenKH.Text;
                if (khDAO.findById(makh) != null)
                {
                    Response.Write("<script>alert('Mã khoa đã tồn tại. Chọn mã khác nhé.')</script>");
                    return;
                }
                Khoa khInsert = new Khoa { MaKH = makh, TenKH = tenkh };
                khDAO.Insert(khInsert);
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Thao tác thêm khoa không thành công.')</script>");
            }
            gvKhoa.DataBind();
        }
    }
}