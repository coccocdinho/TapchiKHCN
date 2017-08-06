using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserProfile : AuthenticatePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.LoadPrifixUserToDropdownList(ddlPrifix);
            LoadData();
        }
    }

    protected void LoadData()
    {
        using (var obj = new DataClassesDataContext())
        {
            var objUser = obj.Users.Single(x => x.UserId == UserID);
            txtFullName.Text = objUser.FullName;
            txtPhone.Text = objUser.Phone;
            txtEmail.Text = objUser.Email;
            txtAddress.Text = objUser.Address;
            ddlPrifix.SelectedValue = objUser.PrefixId.ToString();
            
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (var obj = new DataClassesDataContext())
        {
            try
            {
                var objUser = obj.Users.Single(x => x.UserId == UserID);
                objUser.FullName = txtFullName.Text;
                objUser.Phone = txtPhone.Text;
                objUser.Email = txtEmail.Text;
                objUser.Address = txtAddress.Text;
                objUser.PrefixId = int.Parse(ddlPrifix.SelectedValue);
                objUser.PrefixName = ddlPrifix.SelectedItem.Text;

                obj.SubmitChanges();
                lblMessage.Text = "Cập nhật thành công.";
            }
            catch (Exception e1)
            {
                lblMessage.Text = "Có lỗi xảy ra." + e1.ToString();
            }
            
        }
    }
}