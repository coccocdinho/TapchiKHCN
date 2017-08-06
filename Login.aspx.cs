﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        BLL.Users bllUser = new BLL.Users();
        User u = new User();
        string email = txtEmail.Value;
        string password = txtPassword.Value;
        string message = bllUser.CheckLogIn(email, password,ref u);
        if (string.IsNullOrEmpty(message))
        {
            Session["UserID"] = u.UserId.ToString();
            Session["UserName"] = u.UserName;
            Session["RoleId"] = u.RoleId.ToString();
            Session["IPAddress"] = Request.UserHostAddress;
            Response.Redirect("UserProfile.aspx");
        }
        else
        {
            lblMessage.Text = message;
        }
    }
}