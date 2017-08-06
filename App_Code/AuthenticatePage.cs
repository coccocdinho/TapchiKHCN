using System;
using System.Collections.Generic;
using System.Web;

public class AuthenticatePage : System.Web.UI.Page
{
    /// <summary>
    ///  <para>UserID đăng nhập</para>
    /// </summary>
    public int UserID
    {
        get
        {
            if (Session["UserID"] == null || Session["UserID"] == "0")
                RedirectToPageLogin();
            return int.Parse(Session["UserID"].ToString());
        }
    }

    /// <summary>
    ///  <para>Tên đăng nhập vào hệ thống</para>
    /// </summary>
    public string UserName
    {
        get
        {
            if (Session["UserName"] == null)
                RedirectToPageLogin();

            return Session["UserName"].ToString();
        }
    }
    /// <summary>
    ///  <para>ID đơn vị (mỗi đơn vị khi tham gia BHXH sẽ có 1 mã đơn vị do cơ quan BHXH cấp)</para>
    /// </summary>
    public string IPAddress
    {
        get
        {
            if (Session["IPAddress"] == null)
                RedirectToPageLogin();

            return Session["IPAddress"].ToString();
        }
    }
    /// <summary>
    ///  <para>UserID đăng nhập</para>
    /// </summary>
    public int RoleId
    {
        get
        {
            try
            {
                return int.Parse(Session["RoleId"].ToString());
            }
            catch (Exception)
            {
                return 0;
            }

        }
    }

    public void RedirectToPageLogin()
    {
        Response.Redirect("/login");
    }
}
