using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaticGroupScientificTopics : AuthenticatePage
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
        Common.LoadYearToDropdownlist(ddlYear);
        Common.LoadMonthToDropdownlist(ddlMonth);
        Common.LoadChuyenSanToDropdownlist(ddlChuyenSan);
    }

    protected void btnStatic_Click(object sender, EventArgs e)
    {
        int year = int.Parse(ddlYear.SelectedValue);
        int month = int.Parse(ddlMonth.SelectedValue);
        int chuyensanId = int.Parse(ddlChuyenSan.SelectedValue);

        using (var data = new DataClassesDataContext())
        {
            var result = (from gt in data.GroupTopics
                          join chuyensan in data.ChuyenSans on gt.ChuyensanId equals chuyensan.Id
                          where gt.PublicDate.Year == year
                             && gt.PublicDate.Month == month
                             && (gt.ChuyensanId == chuyensanId || chuyensanId == 0)
                             && (gt.GroupTopicStatus == true)
                          select new {
                              GroupName = gt.Name,
                              ChuyenSan = chuyensan.Name,
                              Number = Common.CoutScientTopicByGroupTopicId(gt.GroupTopicId),
                              StatusName = "Đã phát hành"  
                          });
            pager.DataSource = result.ToList();
            pager.BindToControl = rpList;
            rpList.DataSource = pager.DataSourcePaged;
            rpList.DataBind();
        }
    }
}