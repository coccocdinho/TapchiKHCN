using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResetPassword : AuthenticatePage
{
    int cUserId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
            Response.Redirect("LogOut.aspx");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtPassword.Text != txtRePassword.Text)
        {
            lblMessage.Text = "Mật khẩu nhập lại không đúng";
            return;
        }

        if (ViewState["UserId"] != null)
        {
            cUserId = int.Parse(ViewState["UserId"].ToString());

            try
            {
                var passwordRandomSalt = Utilities.GenerateRandomBytes(16);
                var passwordHash = Utilities.GetInputPasswordHash(txtPassword.Text, passwordRandomSalt);
                using (var obj = new DataClassesDataContext())
                {
                    var user = obj.Users.SingleOrDefault(x => x.UserId == cUserId);
                    if (user != null)
                    {
                        user.PasswordSalt = passwordRandomSalt;
                        user.PasswordHash = passwordHash;

                        obj.SubmitChanges();
                        lblMessage.Text = "Cập nhật mật khẩu thành công.";
                    }
                }
            }
            catch (Exception)
            {
                lblMessage.Text = "Có lỗi xảy ra";
                return;
            }
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "dialog", "$(function(){window.parent.Popup.UsersDetails.ClosePopup('reload');});", true);
    }
}