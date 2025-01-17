using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;
namespace WebQLDaoTao
{
    public partial class QLMonHoc : System.Web.UI.Page
    {
        MonHocDAO mhDAO = new MonHocDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            gvMonHoc.DataSource = mhDAO.getAll();
            gvMonHoc.DataBind();
        }

        protected void gvMonHoc_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMonHoc.EditIndex = e.NewEditIndex;
            gvMonHoc.DataSource = mhDAO.getAll();
            gvMonHoc.DataBind();
        }

        protected void gvMonHoc_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMonHoc.EditIndex = -1;
            gvMonHoc.DataSource = mhDAO.getAll();
            gvMonHoc.DataBind();
        }

        protected void gvMonHoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvMonHoc_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}