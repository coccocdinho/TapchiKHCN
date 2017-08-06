﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScientificTopicsListForAuthorPage : AuthenticatePage
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
            var list = (from st in data.ScientificTopics
                        join s in data.ScientificTopicStatus on st.ScientificTopicStatusIdId equals s.ScientificTopicStatusId
                        join au in data.Users on st.UserIdCreate equals au.UserId
                        where st.UserIdCreate == UserID
                        && (txtTitle.Text.Trim().Length == 0 || st.Title.Contains(txtTitle.Text) || st.TitleEn.Contains(txtTitle.Text)
                        || st.ShortDesciption.Contains(txtTitle.Text) || st.ShortDesciptionEn.Contains(txtTitle.Text))
                        select new
                        {
                            ScientificTopicId = st.ScientificTopicId,
                            ScientificTopicStatusIdId = st.ScientificTopicStatusIdId,
                            Title = st.Title,
                            ShortDescription = st.ShortDesciption,
                            CreateDate = st.CreateDate,
                            FullName = au.FullName,
                            StatusName = s.NameForAuthor,
                            TopicCode = st.TopicCode
                        }).OrderByDescending(x=>x.CreateDate).ToList();

            pager.DataSource = list;
            pager.BindToControl = rpList;
            rpList.DataSource = pager.DataSourcePaged;
            rpList.DataBind();
        }
    }

    public string GetButtonFuntion(object keyId)
    {
        //DataClassesDataContext data = new DataClassesDataContext();
        //ScientificTopic sct = data.ScientificTopics.SingleOrDefault(x => x.ScientificTopicId == long.Parse(keyId.ToString()));
        string message = string.Empty;
        string buttonViewEdit = "";
        string buttonHistory = "";
        string buttonDelete = "";
        string btnExport = "";
        //buttonViewEdit = "<a id='idEdit' href='javascript:void(0)' onclick='OpenUpdate(" + keyId + "," + UserID + ");'>" +
        //            "<i class=\"ace-icon fa fa-pencil bigger-120\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Xử lý' style='cursor: pointer;'></i></a>";
        //buttonHistory = "<a id='idHistory' href='javascript:void(0)' onclick='OpenHistory(" + keyId + ")'>" +
        //"<i class=\"ace-icon glyphicon glyphicon-refresh\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Xem lịch sử' style='cursor: pointer;'></i></a>";
        //buttonDelete = "<a id='idDelete' href='javascript:void(0)' onclick='OpenDelete(" + keyId + "," + UserID + ");'>" +
        //"<i class=\"ace-icon fa fa-trash-o bigger-130\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Xóa' style='cursor: pointer;'></i></a>";
        //if (RoleId == Constants.RolePhanBien)
        //{
        //    btnExport = "<a id='idDelete' href='javascript:void(0)' onclick='OpenExport(" + keyId + "," + UserID + ");'>" +
        //        "<i class=\"ace-icon glyphicon glyphicon-zoom-out\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Kết xuất nhận xét' style='cursor: pointer;'></i></a>";
        //}
        //<i class="ace-icon fa fa-eye"></i>
        return (string.IsNullOrEmpty(buttonViewEdit) ? "" : (buttonViewEdit) + "&nbsp;&nbsp;") +
               (string.IsNullOrEmpty(buttonHistory) ? "" : (buttonHistory) + "&nbsp;&nbsp;") +
               (string.IsNullOrEmpty(btnExport) ? "" : (btnExport) + "&nbsp;&nbsp;") +
             (string.IsNullOrEmpty(buttonDelete) ? "" : (buttonDelete) + "&nbsp;&nbsp;");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadData();
    }
}