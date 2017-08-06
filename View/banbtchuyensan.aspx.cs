using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_banbtchuyensan : System.Web.UI.Page
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
            var list1 = data.UserExtensions.Where(x => x.JournalId == 1 && x.UserExtensionTypeId==2).OrderBy(x => x.Priority);
            rpt1.DataSource = list1.ToList();
            rpt1.DataBind();

            var list2 = data.UserExtensions.Where(x => x.JournalId == 2 && x.UserExtensionTypeId == 2).OrderBy(x => x.Priority);
            rpt2.DataSource = list2.ToList();
            rpt2.DataBind();

            var list3 = data.UserExtensions.Where(x => x.JournalId == 3 && x.UserExtensionTypeId == 2).OrderBy(x => x.Priority);
            rpt3.DataSource = list3.ToList();
            rpt3.DataBind();
        }
    }
}