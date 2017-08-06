using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JournalAddPage : AuthenticatePage
{
    int cKeyId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.LoadUserByRoleToDropdownList(ddlUser, Constants.RoleTruongBanBienTapChuyenSan);
            Common.LoadUserByRoleToDropdownList(ddlThuKy, Constants.RoleVanPhongToaSoan);
            LoadData();
        }
    }

    protected void LoadData()
    {
        try
        {
            ViewState["Id"] = Request.QueryString["KeyId"].ToString();
        }
        catch (Exception)
        {
            ViewState["Id"] = null;
        }

        if (ViewState["Id"] != null)
        {
            long cKeyId = long.Parse(ViewState["Id"].ToString());
            using (var obj = new DataClassesDataContext())
            {
                var objProcess = obj.ChuyenSans.Single(x => x.Id == cKeyId);
                txtName.Text = objProcess.Name;
                chkIsActive.Checked = objProcess.IsActive;
                ddlUser.SelectedValue = objProcess.ManageUserId.ToString();
                ddlThuKy.SelectedValue = objProcess.UserId.ToString();
                txtCode.Text = objProcess.Code;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string message = string.Empty;
        ChuyenSan objProcess = new ChuyenSan();

        using (var obj = new DataClassesDataContext())
        {
            if (ViewState["Id"] == null)
            {
                objProcess.Name = txtName.Text;
                objProcess.IsActive = chkIsActive.Checked;
                objProcess.ManageUserId = int.Parse(ddlUser.SelectedValue);
                objProcess.UserId = long.Parse(ddlThuKy.SelectedValue);
                objProcess.Code = txtCode.Text;
                try
                {
                    obj.ChuyenSans.InsertOnSubmit(objProcess);
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
                    cKeyId = int.Parse(ViewState["Id"].ToString());
                    objProcess = obj.ChuyenSans.Single(x => x.Id == cKeyId);

                    objProcess.Name = txtName.Text;
                    objProcess.IsActive = chkIsActive.Checked;
                    objProcess.ManageUserId = int.Parse(ddlUser.SelectedValue);
                    objProcess.UserId = long.Parse(ddlThuKy.SelectedValue);
                    objProcess.Code = txtCode.Text;

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