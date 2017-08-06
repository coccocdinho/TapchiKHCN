using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : AuthenticatePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtPassword.Text != txtRePassword.Text)
        {
            lblMessage.Text = "Mật khẩu nhập lại không đúng";
            return;
        }
        BLL.Users bllUser = new BLL.Users();
        User u = new User();
        string userName = UserName;
        string passwordOld = txtOldPassword.Text;
        try
        {
            string message = bllUser.CheckLogIn(userName, passwordOld, ref u);
            if (string.IsNullOrEmpty(message))
            {
                var passwordRandomSalt = Utilities.GenerateRandomBytes(16);
                var passwordHash = Utilities.GetInputPasswordHash(txtPassword.Text, passwordRandomSalt);
                using (var obj = new DataClassesDataContext())
                {
                    var user = obj.Users.Single(x => x.UserId == UserID);
                    user.PasswordSalt = passwordRandomSalt;
                    user.PasswordHash = passwordHash;

                    obj.SubmitChanges();
                    lblMessage.Text = "Cập nhật mật khẩu thành công.";
                }
            }
            else
            {
                lblMessage.Text = message;
            }
        }
        catch (Exception)
        {
            lblMessage.Text = "Có lỗi xảy ra";
        }
    }
}