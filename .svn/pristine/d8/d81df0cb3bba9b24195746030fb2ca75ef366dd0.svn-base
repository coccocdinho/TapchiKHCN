using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_hoidongbientap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    protected void LoadData()
    {
        using (var data = new DataClassesDataContext())
        {
            var newdetails = data.News.FirstOrDefault(x => x.GroupNewId == Constants.GroupNew_hoidongbientap);
            if (newdetails != null)
            {
                lblContentNew.Text = newdetails.Content;
            }

            var list = data.UserExtensions.Where(x => x.UserExtensionTypeId == 1).OrderBy(x=>x.Priority);
            rptList.DataSource = list;
            rptList.DataBind();
        }
    }
}