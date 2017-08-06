using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Page_UserList : AuthenticatePage
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
        using (var obj = new DataClassesDataContext())
        {
            var list = (from u in obj.Users
                        join r in obj.Roles on u.RoleId equals r.RoleId
                        join us in obj.UserStatus on u.UserStatusId equals us.UserStatusId
                        select new
                        {
                            UserId = u.UserId,
                            FullName = u.FullName,
                            UserName = u.UserName,
                            RoleName = r.RoleName,
                            Phone = u.Phone,
                            UserStatusName = us.Name
                        }).ToList();
            rpList.DataSource = list;
            rpList.DataBind();
        }
    }

    public string GetButtonFuntion(object userId)
    {
        string message = string.Empty;
        string buttonViewEdit = "";
        string buttonHistory = "";
        string buttonDelete = "";
        buttonViewEdit = "<a id='idEdit' href='javascript:void(0)' onclick='OpenUpdate(" + userId + ");'>" +
                    "<i class=\"ace-icon fa fa-eye\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Cập nhật thông Tài khoản' style='cursor: pointer;'></i></a>";
        buttonHistory = "<a id='idDelete' href='javascript:void(0)' onclick='OpenResetPassWord(" + userId + ")'>" +
        "<i class=\"ace-icon glyphicon glyphicon-refresh\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Reset Mật khẩu' style='cursor: pointer;'></i></a>";
        buttonDelete = "<a id='idDelete' href='javascript:void(0)' onclick='OpenDelete(" + userId + ")'>" +
        "<i class=\"ace-icon fa fa-trash-o bigger-130\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Xóa tài khoản' style='cursor: pointer;'></i></a>";
        //<i class="ace-icon fa fa-eye"></i>
        return (string.IsNullOrEmpty(buttonViewEdit) ? "" : (buttonViewEdit) + "&nbsp;&nbsp;") +
            (string.IsNullOrEmpty(buttonDelete) ? "" : (buttonDelete) + "&nbsp;&nbsp;") +
             (string.IsNullOrEmpty(buttonHistory) ? "" : (buttonHistory) + "&nbsp;&nbsp;");
    }
}