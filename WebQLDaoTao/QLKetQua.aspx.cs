using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;
namespace WebQLDaoTao
{
    public partial class KetQua : System.Web.UI.Page
    {
        MonHocDAO mhDao = new MonHocDAO();
        KetQuaDAO kqDAO = new KetQuaDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlMonHoc.DataSource = mhDao.getAll();
                ddlMonHoc.DataTextField = "tenmh";
                ddlMonHoc.DataValueField = "mamh";
                ddlMonHoc.DataBind();
                ddlMonHoc.Items.Insert(0, new ListItem("--Chọn môn học-", ""));
            }
        }

        protected void gvKetQua_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mamh = ddlMonHoc.SelectedValue;
            gvKetQua.DataSource = kqDAO.findByMaMH(mamh);
            gvKetQua.DataBind();
        }

        protected void btLuu_Click(object sender, EventArgs e)
        {
            int count = gvKetQua.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                int id = int.Parse(gvKetQua.DataKeys[i].Value.ToString());
                float diem = float.Parse(((TextBox)gvKetQua.Rows[i].FindControl("txtDiem")).Text);
                kqDAO.Update(id, diem);
            }
        }

        protected void ddlMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mamh = ddlMonHoc.SelectedValue;
            gvKetQua.DataSource = kqDAO.findByMaMH(mamh);
            gvKetQua.DataBind();
        }
    }
}