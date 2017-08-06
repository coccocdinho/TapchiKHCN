using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChuyenSanListPage : AuthenticatePage
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
            var list = (from u in obj.ChuyenSans
                        join r in obj.Users on u.ManageUserId equals r.UserId
                        select new
                        {
                            Id = u.Id,
                            Name = u.Name,
                            UserName = r.UserName,
                            IsActive = u.IsActive,
                            Code = u.Code
                        }).ToList();
            rpList.DataSource = list;
            rpList.DataBind();
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
        "<i class=\"ace-icon fa fa-trash-o bigger-130\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Reset Mật khẩu' style='cursor: pointer;'></i></a>";
        //<i class="ace-icon fa fa-eye"></i>
        return (string.IsNullOrEmpty(buttonViewEdit) ? "" : (buttonViewEdit) + "&nbsp;&nbsp;") +
             (string.IsNullOrEmpty(buttonHistory) ? "" : (buttonHistory) + "&nbsp;&nbsp;");
    }
}