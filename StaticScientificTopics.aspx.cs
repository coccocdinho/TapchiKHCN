using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaticScientificTopics : AuthenticatePage
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
        //Common.LoadScientificTopicStatusToDropdownList(ddlStatus);
    }

    protected void btnStatic_Click(object sender, EventArgs e)
    {
        int year = int.Parse(ddlYear.SelectedValue);
        int month = int.Parse(ddlMonth.SelectedValue);
        int chuyensanId = int.Parse(ddlChuyenSan.SelectedValue);
        int statusId = int.Parse(ddlStatus.SelectedValue);

        using (var data = new DataClassesDataContext())
        {
            if (statusId == 1)// Danh sách đã gửi(Bài đã gửi là bài có trạng thái không phải là Không duyệt, Đã xuất bản)
            {
                var result = (from s in data.ScientificTopics
                              join au in data.Users on s.UserIdCreate equals au.UserId
                              join chuyensan in data.ChuyenSans on s.ChuyensanId equals chuyensan.Id
                              join st in data.ScientificTopicStatus on s.ScientificTopicStatusIdId equals st.ScientificTopicStatusId
                              where s.CreateDate.Year == year
                                  && s.CreateDate.Month == month
                                  && (s.ChuyensanId == chuyensanId || chuyensanId == 0)
                                  && (st.ScientificTopicStatusId != 9 || st.ScientificTopicStatusId != 3)
                              select new
                              {
                                  Title = s.Title,
                                  Author = au.UserName,
                                  JournaName = chuyensan.Name,
                                  CreateDate = s.CreateDate,
                                  PhanBien = Common.GetListUserPhanBien(s),
                                  StatusName = "Đã gửi",
                                  GroupTopicName = Common.GetGroupName(s)
                              });
                pager.DataSource = result.ToList();
                pager.BindToControl = rpList;
                rpList.DataSource = pager.DataSourcePaged;
                rpList.DataBind();
            }
            else if (statusId == 2) // Chấp nhận đăng ==> đã xuất bản
            {
                var result = (from s in data.ScientificTopics
                              join au in data.Users on s.UserIdCreate equals au.UserId
                              join chuyensan in data.ChuyenSans on s.ChuyensanId equals chuyensan.Id
                              join st in data.ScientificTopicStatus on s.ScientificTopicStatusIdId equals st.ScientificTopicStatusId
                              where s.CreateDate.Year == year
                                  && s.CreateDate.Month == month
                                  && (s.ChuyensanId == chuyensanId || chuyensanId == 0)
                                  && (st.ScientificTopicStatusId == 9)
                              select new
                              {
                                  Title = s.Title,
                                  Author = au.UserName,
                                  JournaName = chuyensan.Name,
                                  CreateDate = s.CreateDate,
                                  PhanBien = Common.GetListUserPhanBien(s),
                                  StatusName = st.Name,
                                  GroupTopicName = Common.GetGroupName(s)
                              });
                pager.DataSource = result.ToList();
                pager.BindToControl = rpList;
                rpList.DataSource = pager.DataSourcePaged;
                rpList.DataBind();
            }
            else if (statusId == 3)// Không duyệt
            {
                var result = (from s in data.ScientificTopics
                              join au in data.Users on s.UserIdCreate equals au.UserId
                              join chuyensan in data.ChuyenSans on s.ChuyensanId equals chuyensan.Id
                              join st in data.ScientificTopicStatus on s.ScientificTopicStatusIdId equals st.ScientificTopicStatusId
                              where s.CreateDate.Year == year
                                  && s.CreateDate.Month == month
                                  && (s.ChuyensanId == chuyensanId || chuyensanId == 0)
                                  && (st.ScientificTopicStatusId == 3)
                              select new
                              {
                                  Title = s.Title,
                                  Author = au.UserName,
                                  JournaName = chuyensan.Name,
                                  CreateDate = s.CreateDate,
                                  PhanBien = Common.GetListUserPhanBien(s),
                                  StatusName = st.Name,
                                  GroupTopicName = Common.GetGroupName(s)
                              });
                pager.DataSource = result.ToList();
                pager.BindToControl = rpList;
                rpList.DataSource = pager.DataSourcePaged;
                rpList.DataBind();
            }
        }
    }
}