using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_dangky : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ResetForm();
            LoadChucDanh();
        }
    }

    public void ResetForm()
    {
        txtEmail.Text = "";
        txtPassword.Text = "";
        txtRePassword.Text = "";
        lblMessage.Text = "";
    }
    //check email format
    bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public string CheckDataForm()
    {
        if (txtEmail.Text.Trim().Length == 0)
        {
            return "<p>Vui lòng nhập đầy đủ thông tin</p>";
        }
        else
        {
            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                return "<p>Email không đúng định dạng</p>";
            }
        }

        if (txtPassword.Text.Trim().Length == 0)
        {
            return "<p>Vui lòng nhập đầy đủ thông tin</p>";
        }
        else
        {

            if (txtPassword.Text.Trim().Length > 50 || txtPassword.Text.Trim().Length < 6)
            {
                return "<p>Mật khẩu phải >6 ký tự và < 50 ký tự</p>";
            }
        }

        if (txtFullName.Text.Trim().Length == 0)
        {
            return "<p>Vui lòng nhập đầy đủ thông tin</p>";
        }
        else
        {
            if (txtFullName.Text.Trim().Length > 50 || txtFullName.Text.Trim().Length < 6)
            {
                return "<p>Họ tên phải >6 ký tự và < 50 ký tự</p>";
            }
        }

        if (txtPassword.Text != txtRePassword.Text)
        {
            return "<p>Mật khẩu không khớp.</p>";
        }

        return "";
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string result = string.Empty;
        //Encryption encrypt = new Encryption();
        result = CheckDataForm();
        if (result.Length > 0)
        {
            lblMessage.Text = result;
            lblMessage.Style.Add("color", "red");
            return;
        }

        using (var data = new DataClassesDataContext())
        {
            try
            {
                var password = txtPassword.Text;
                var rePassword = txtRePassword.Text;
                if (password != rePassword)
                {
                    lblMessage.Text = "<p>Mật khẩu không khớp.</p>";
                    lblMessage.Style.Add("color", "red");
                    return;
                }
                var passwordRandomSalt = Utilities.GenerateRandomBytes(16);
                var passwordHash = Utilities.GetInputPasswordHash(password, passwordRandomSalt);
                User user = new User();
                user.PassWord = "";
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordRandomSalt;
                user.Email = txtEmail.Text;
                user.CreateDate = DateTime.Now;
                user.UserStatusId = 2;
                user.RoleId = byte.Parse(ddlGroupUser.SelectedValue);
                user.FullName = txtFullName.Text;
                user.UserName = txtFullName.Text;
                user.GroupUserId = 1;
                user.Phone = txtPhone.Text;
                user.PrefixId = int.Parse(ddlChucDanh.SelectedValue);
                user.PrefixName = ddlChucDanh.SelectedItem.Text;
                user.Address = txtAddress.Text;

                using (var obj = new DataClassesDataContext())
                {
                    var check = obj.Users.SingleOrDefault(x => x.Email == user.Email);
                    if (check != null)
                    {
                        lblMessage.Text = "<p>Email đã được sử dụng.</p>";
                        lblMessage.Style.Add("color", "red");
                        return;
                    }

                    try
                    {
                        obj.Users.InsertOnSubmit(user);
                        obj.SubmitChanges();
                        lblMessage.Text = "<p>Cập nhật thành công.</p>";
                        lblMessage.Style.Add("color", "red");
                    }
                    catch (Exception)
                    {
                        lblMessage.Text = "<p>Có lỗi khi thêm mới Users</p>";
                        lblMessage.Style.Add("color", "red");
                        return;
                    }

                }

                Session["UserId"] = user.UserId;
                Session["UserEmail"] = user.Email;
                Session["RoleId"] = user.RoleId;
                ScriptManager.RegisterClientScriptBlock(btnAdd, this.GetType(), "", "alert('Đăng ký thành công.');window.opener.location.reload(true);window.close();", true);
                Response.Redirect("../UserProfile.aspx");
            }
            catch (DbUpdateException ex)
            {
                lblMessage.Text = "<p>Có lỗi khi thêm mới tài khoản " + ex.ToString() + "</p>";
                lblMessage.Style.Add("color", "red");
                return;
            }
        }
        lblMessage.Text = "Đăng ký tài khoản thành công.";
        lblMessage.Style.Add("color", "red");
        //encrypt = null;
    }

    protected void LoadChucDanh()
    {
        using (var data = new DataClassesDataContext())
        {
            var list = data.PrifixUers.ToList();
            ddlChucDanh.DataSource = list;
            ddlChucDanh.DataValueField = "Id";
            ddlChucDanh.DataTextField = "Name";
            ddlChucDanh.DataBind();
        }
    }
}