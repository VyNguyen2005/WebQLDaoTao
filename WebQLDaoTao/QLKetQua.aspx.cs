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
            foreach (GridViewRow row in gvKetQua.Rows)
            {
                CheckBox chkChon = (CheckBox)row.FindControl("chkChon");
                if (chkChon != null && chkChon.Checked)
                {
                    int id = Convert.ToInt32(gvKetQua.DataKeys[row.RowIndex].Value);
                    kqDAO.Delete(id);
                    gvKetQua.DataBind();
                }
            }
    }
}