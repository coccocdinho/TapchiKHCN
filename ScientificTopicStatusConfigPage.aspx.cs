using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScientificTopicStatusConfigPage : AuthenticatePage
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
            var list = (from st in data.ScientificTopicStatusConfigs
                        join fs in data.ScientificTopicStatus on st.FromStatusId equals fs.ScientificTopicStatusId
                        join ts in data.ScientificTopicStatus on st.ToStatusId equals ts.ScientificTopicStatusId
                        join fr in data.Roles on st.FromRoleId equals fr.RoleId
                        join tr in data.Roles on st.ToRoleId equals tr.RoleId
                        select new
                        {
                            ConfigId = st.ConfigId,
                            FromStatus = fs.Name,
                            ToStatus = ts.Name,
                            FromRole = fr.RoleName,
                            ToRole = tr.RoleName,
                            ActionName = st.ActionName,
                            ActionDescription = st.ActionDescription,
                            IsSaveData = st.IsSaveData
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
                    "<i class=\"ace-icon glyphicon glyphicon-pencil\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Cập nhật thông tin' style='cursor: pointer;'></i></a>";
        buttonHistory = "<a id='idDelete' href='javascript:void(0)' onclick='OpenPopupDeleteOrUpdate(" + keyId + ")'>" +
        "<i class=\"ace-icon glyphicon glyphicon-refresh\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Xem lịch sử' style='cursor: pointer;'></i></a>";
        //<i class="ace-icon fa fa-eye"></i>
        return (string.IsNullOrEmpty(buttonViewEdit) ? "" : (buttonViewEdit) + "&nbsp;&nbsp;") +
             (string.IsNullOrEmpty(buttonHistory) ? "" : (buttonHistory) + "&nbsp;&nbsp;");
    }
}