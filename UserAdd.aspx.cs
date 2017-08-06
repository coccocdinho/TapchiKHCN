using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserAdd : AuthenticatePage
{
    int cUserId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.LoadPrifixUserToDropdownList(ddlPrefix);
            Common.LoadRoleToDropdownList(ddlRole);
            Common.LoadUserStatusToDropdownList(ddlUserStatus);
            Common.LoadChuyenSanToDropdownlist(ddlJounal);
            LoadData();
        }
    }

    protected void LoadData()
    {
        try
        {
            ViewState["UserId"] = Request.QueryString["KeyId"].ToString();
        }
        catch (Exception)
        {
            ViewState["UserId"] = null;
        }

        if (ViewState["UserId"] != null)
        {
            pnlIsNew.Visible = false;
            txtUserName.ReadOnly = true;
            cUserId = int.Parse(ViewState["UserId"].ToString());
            using (var data = new DataClassesDataContext())
            {
                User user = data.Users.SingleOrDefault(x => x.UserId == cUserId);
                if (user != null)
                {
                    txtUserName.Text = user.UserName;
                    txtFullname.Text = user.FullName;
                    txtEmail.Text = user.Email;
                    txtPhone.Text = user.Phone;
                    txtAddress.Text = user.Address;
                    ddlRole.SelectedValue = user.RoleId.ToString();
                    ddlPrefix.SelectedValue = user.PrefixId.ToString();
                    ddlUserStatus.SelectedValue = user.UserStatusId.ToString();
                    ddlJounal.SelectedValue = user.JournalId.ToString();
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string message = string.Empty;
        if (ViewState["UserId"] == null)
        {
            var password = txtPassword.Text;
            var rePassword = txtRePassword.Text;
            if (password != rePassword)
            {
                lblMessage.Text = "Mật khẩu bạn nhập lại chưa đúng";
                return;
            }
            var passwordRandomSalt = Utilities.GenerateRandomBytes(16);
            var passwordHash = Utilities.GetInputPasswordHash(password, passwordRandomSalt);
            User user = new User();
            user.UserName = txtUserName.Text;
            user.PassWord = "";
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordRandomSalt;
            user.Email = txtEmail.Text;
            user.CreateDate = DateTime.Now;
            user.UserStatusId = byte.Parse(ddlUserStatus.SelectedValue);
            user.RoleId = byte.Parse(ddlRole.SelectedValue);
            user.FullName = txtFullname.Text;
            user.GroupUserId = 1;
            user.Phone = txtPhone.Text;
            user.PrefixId = int.Parse(ddlPrefix.SelectedValue);
            user.PrefixName = ddlPrefix.SelectedItem.Text;
            user.Address = txtAddress.Text;
            user.JournalId = int.Parse(ddlJounal.SelectedValue);

            using (var obj = new DataClassesDataContext())
            {
                var check = obj.Users.SingleOrDefault(x => x.UserName == user.UserName);
                if (check != null)
                {
                    lblMessage.Text = "UserName đã tồn tại.";
                    return;
                }

                try
                {
                    obj.Users.InsertOnSubmit(user);
                    obj.SubmitChanges();
                    lblMessage.Text = "Cập nhật thành công.";
                }
                catch (Exception)
                {
                    lblMessage.Text = "Có lỗi khi thêm mới Users";
                    return;
                }

            }
        }
        else
        {
            cUserId = int.Parse(ViewState["UserId"].ToString());
            using (var data = new DataClassesDataContext())
            {
                User user = data.Users.SingleOrDefault(x => x.UserId == cUserId);
                if (user != null)
                {
                    user.FullName = txtFullname.Text;
                    user.Email = txtEmail.Text;
                    user.Phone = txtPhone.Text;
                    user.Address = txtAddress.Text;
                    user.RoleId = byte.Parse(ddlRole.SelectedValue);
                    user.PrefixId = int.Parse(ddlPrefix.SelectedValue);
                    user.PrefixName = ddlPrefix.SelectedItem.Text;
                    user.UserStatusId = byte.Parse(ddlUserStatus.SelectedValue);
                    user.JournalId = int.Parse(ddlJounal.SelectedValue);

                    try
                    {
                        data.SubmitChanges();
                        lblMessage.Text = "Cập nhật thành công.";
                    }
                    catch (Exception)
                    {
                        lblMessage.Text = "Có lỗi khi cập nhật.";
                        return;
                    }
                }
            }
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "dialog", "$(function(){window.parent.Popup.UsersDetails.ClosePopup('reload');});", true);
        return;
    }
}