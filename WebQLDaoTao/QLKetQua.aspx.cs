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
        KetQuaDAO kqDAO = new KetQuaDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            int count = gvKetQua.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                int id = int.Parse(gvKetQua.DataKeys[i].Value.ToString());
                float diem = float.Parse(((TextBox)gvKetQua.Rows[i].FindControl("txtDiem")).Text);
                kqDAO.Update(id, diem);
            }
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            int count = gvKetQua.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                bool check = ((CheckBox)gvKetQua.Rows[i].FindControl("chkChon")).Checked;
                if (check){
                    int id = int.Parse(gvKetQua.DataKeys[i].Value.ToString());
                    kqDAO.Delete(id);
                }
            }
            gvKetQua.DataBind();

        }

        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            int count = gvKetQua.Rows.Count;
            bool check = ((CheckBox)gvKetQua.HeaderRow.FindControl("chkAll")).Checked;
            for (int i = 0; i < count; i++)
            {
                ((CheckBox)gvKetQua.Rows[i].FindControl("chkChon")).Checked = check;
            }
        }
    }
}