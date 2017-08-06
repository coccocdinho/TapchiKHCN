using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GroupTopicListPage : AuthenticatePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                LoadGroup();
                LoadData(int.Parse(ddlGroup.SelectedValue));
                lblMessage.Text = "";
            }
        }
    }

    protected void LoadData(int groupId)
    {
        int statusId = int.Parse(ddlStatus.SelectedValue);
        using (var data = new DataClassesDataContext())
        {
            if (statusId == 2)
            {
                var list = data.GroupTopics.Where(x => x.ParentId == groupId).ToList();
                //rpList.DataSource = list;
                //rpList.DataBind();
                pager.DataSource = list;
                pager.BindToControl = rpList;
                rpList.DataSource = pager.DataSourcePaged;
                rpList.DataBind();
            }
            else
            {
                bool status = false;
                if (statusId == 1)
                {
                    status = true;
                }
                var list = data.GroupTopics.Where(x => x.ParentId == groupId && x.GroupTopicStatus == status).ToList();
                //rpList.DataSource = list;
                //rpList.DataBind();
                pager.DataSource = list;
                pager.BindToControl = rpList;
                rpList.DataSource = pager.DataSourcePaged;
                rpList.DataBind();
            }
        }
    }

    public void LoadGroup()
    {
        using (var data = new DataClassesDataContext())
        {
            var listGroup = data.GroupTopics.Where(x => x.Level == 1).ToList();
            ddlGroup.DataSource = listGroup;
            ddlGroup.DataValueField = "GroupTopicId";
            ddlGroup.DataTextField = "Name";
            ddlGroup.DataBind();
        }
    }

    public string GetButtonFuntion(object keyId)
    {
        string message = string.Empty;
        string buttonViewEdit = "";
        string buttonListScientTopic = "";
        string buttonDelete = "";
        buttonViewEdit = "<a id='idEdit' href='javascript:void(0)' onclick='OpenUpdate(" + keyId + "," + UserID + ");'>" +
                    "<i class=\"ace-icon fa fa-pencil bigger-120\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Xử lý' style='cursor: pointer;'></i></a>";
        buttonListScientTopic = "<a id='idHistory' href='javascript:void(0)' onclick='OpenListScienTopic(" + keyId + ")'>" +
        "<i class=\"ace-icon fa fa-info-circle\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Danh sách bài báo' style='cursor: pointer;'></i></a>";
        buttonDelete = "<a id='idDelete' href='javascript:void(0)' onclick='OpenDelete(" + keyId + "," + UserID + ");'>" +
        "<i class=\"ace-icon fa fa-trash-o bigger-130\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Xóa' style='cursor: pointer;'></i></a>";
        //<i class="ace-icon fa fa-eye"></i>
        return (string.IsNullOrEmpty(buttonViewEdit) ? "" : (buttonViewEdit) + "&nbsp;&nbsp;") +
                (string.IsNullOrEmpty(buttonListScientTopic) ? "" : (buttonListScientTopic) + "&nbsp;&nbsp;") +
             (string.IsNullOrEmpty(buttonDelete) ? "" : (buttonDelete) + "&nbsp;&nbsp;");
    }
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData(int.Parse(ddlGroup.SelectedValue));
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData(int.Parse(ddlGroup.SelectedValue));
    }
}