﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterCustomer : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        var authen = new AuthenticatePage();
        using (var obj = new DataClassesDataContext())
        {
            var list = (from f in obj.SysFunctions
                        join fn in obj.RoleMapSysfunctions on f.SysFunctionId equals fn.SysFunctionId
                        where fn.RoleId == authen.RoleId
                        select f
                            ).OrderBy(x=>x.Priority).ToList();
            rptFunction.DataSource = list;
            rptFunction.DataBind();
        }
        LoadInfoLogin();
     }

    protected void LoadInfoLogin()
    {
        string url = "<a href=\"dangky.aspx\">Đăng ký</a> | <a href=\"dangnhap.aspx\">Đăng nhập</a>";
        if (Session["UserId"] != null)
        {
            int userId = int.Parse(Session["UserId"].ToString());
            using (var data = new DataClassesDataContext())
            {
                User u = data.Users.Single(x => x.UserId == userId);
                url = "Chào <b>" + u.PrefixName + " " + u.FullName+"</b>";
            }
            lblUserInfo.Text = url;
        }
    }
}