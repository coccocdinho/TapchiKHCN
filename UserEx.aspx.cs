using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserEx : AuthenticatePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.LoadUserExtensionType(ddlGroup);
            LoadData(int.Parse(ddlGroup.SelectedValue));
        }
    }

    public void LoadData(int groupId)
    {
        using (var data = new DataClassesDataContext())
        {
            if (groupId == 0)
            {
                var list = data.UserExtensions.ToList();
                //rpList.DataSource = list;
                //rpList.DataBind();
                pager.DataSource = list;
                pager.BindToControl = rpList;
                rpList.DataSource = pager.DataSourcePaged;
                rpList.DataBind();
            }
            else
            {
                var list = data.UserExtensions.Where(x => x.UserExtensionTypeId == groupId).ToList();
                //rpList.DataSource = list;
                //rpList.DataBind();
                pager.DataSource = list;
                pager.BindToControl = rpList;
                rpList.DataSource = pager.DataSourcePaged;
                rpList.DataBind();
            }
        }
    }

    public string GetButtonFuntion(object keyId)
    {
        string message = string.Empty;
        string buttonViewEdit = "";
        string buttonHistory = "";
        buttonViewEdit = "<a id='idEdit' href='javascript:void(0)' onclick='OpenUpdate(" + keyId + ");'>" +
                    "<i class=\"ace-icon fa fa-pencil bigger-120\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Cập nhật thông Tài khoản' style='cursor: pointer;'></i></a>";
        buttonHistory = "<a id='idDelete' href='javascript:void(0)' onclick='OpenDelete(" + keyId + ")'>" +
        "<i class=\"ace-icon fa fa-trash-o bigger-130\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Xóa' style='cursor: pointer;'></i></a>";
        //<i class="ace-icon fa fa-eye"></i>
        return (string.IsNullOrEmpty(buttonViewEdit) ? "" : (buttonViewEdit) + "&nbsp;&nbsp;") +
             (string.IsNullOrEmpty(buttonHistory) ? "" : (buttonHistory) + "&nbsp;&nbsp;");
    }
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData(int.Parse(ddlGroup.SelectedValue));
    }
}