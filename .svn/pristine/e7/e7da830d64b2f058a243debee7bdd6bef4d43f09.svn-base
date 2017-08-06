using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScientificTopicStatusConfigAdd : AuthenticatePage
{
    int cKeyId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.LoadRoleToDropdownList(ddlFromRole);
            Common.LoadRoleToDropdownList(ddlToRole);
            Common.LoadScientificTopicStatusToDropdownList(ddlFromStatus);
            Common.LoadScientificTopicStatusToDropdownList(ddlToStatus);
            LoadData();
        }
    }

    protected void LoadData()
    {
        try
        {
            ViewState["ConfigId"] = Request.QueryString["KeyId"].ToString();
        }
        catch (Exception)
        {
            ViewState["ConfigId"] = null;
        }

        if (ViewState["ConfigId"] != null)
        {
            long cKeyId = long.Parse(ViewState["ConfigId"].ToString());
            using (var obj = new DataClassesDataContext())
            {
                var objProcess = obj.ScientificTopicStatusConfigs.Single(x => x.ConfigId == cKeyId);

                ddlFromStatus.SelectedValue = objProcess.FromStatusId.ToString();
                ddlToStatus.SelectedValue = objProcess.ToStatusId.ToString();
                txtActionName.Text = objProcess.ActionName;
                txtActionDescription.Text = objProcess.ActionDescription;
                ddlFromRole.SelectedValue = objProcess.FromRoleId.ToString();
                ddlToRole.SelectedValue = objProcess.ToRoleId.ToString();
                chkIsSaveData.Checked = objProcess.IsSaveData;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string message = string.Empty;
        ScientificTopicStatusConfig objProcess = new ScientificTopicStatusConfig();

        using (var obj = new DataClassesDataContext())
        {
            if (ViewState["ConfigId"] == null)
            {
                objProcess.FromStatusId = byte.Parse(ddlFromStatus.SelectedValue);
                objProcess.ToStatusId = byte.Parse(ddlToStatus.SelectedValue);
                objProcess.ActionName = txtActionName.Text;
                objProcess.ActionDescription = txtActionDescription.Text;
                objProcess.FromRoleId = byte.Parse(ddlFromRole.SelectedValue);
                objProcess.ToRoleId = byte.Parse(ddlToRole.SelectedValue);
                objProcess.ToUserId = 0;
                objProcess.IsSaveData = chkIsSaveData.Checked;

                try
                {
                    obj.ScientificTopicStatusConfigs.InsertOnSubmit(objProcess);
                    obj.SubmitChanges();
                    lblMessage.Text = "Cập nhật thành công.";
                }
                catch (Exception)
                {
                    lblMessage.Text = "Có lỗi khi xử lý";
                }
            }
            else
            {
                try
                {
                    cKeyId = int.Parse(ViewState["ConfigId"].ToString());
                    objProcess = obj.ScientificTopicStatusConfigs.Single(x => x.ConfigId == cKeyId);

                    objProcess.FromStatusId = byte.Parse(ddlFromStatus.SelectedValue);
                    objProcess.ToStatusId = byte.Parse(ddlToStatus.SelectedValue);
                    objProcess.ActionName = txtActionName.Text;
                    objProcess.ActionDescription = txtActionDescription.Text;
                    objProcess.FromRoleId = byte.Parse(ddlFromRole.SelectedValue);
                    objProcess.ToRoleId = byte.Parse(ddlToRole.SelectedValue);
                    objProcess.IsSaveData = chkIsSaveData.Checked;

                    obj.SubmitChanges();
                    lblMessage.Text = "Cập nhật thành công.";
                }
                catch (Exception)
                {
                    lblMessage.Text = "Có lỗi khi xử lý";
                }
            }

        }

        ScriptManager.RegisterStartupScript(this, GetType(), "dialog", "$(function(){window.parent.Popup.ObjDetail.ClosePopup('reload');});", true);
        return;
    }
}