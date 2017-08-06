﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserExDetail : AuthenticatePage
{
    int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.LoadChuyenSanToDropdownlist(ddlJournal);
            Common.LoadUserExtensionType(ddlGroup);
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
            id = int.Parse(ViewState["Id"].ToString());
            using (var data = new DataClassesDataContext())
            {
                UserExtension user = data.UserExtensions.SingleOrDefault(x => x.Id == id);
                if (user != null)
                {
                    txtFullname.Text = user.FullName;
                    txtPrifixName.Text = user.PrifixName;
                    txtCompanyName.Text = user.CompanyName;
                    txtPositionName.Text = user.PositionName;
                    txtMajoringInScience.Text = user.MajoringInScience;
                    txtPositionInScient.Text = user.PositionInScient;
                    txtPhone.Text = user.Phone;
                    txtEmail.Text = user.Email;
                    ddlGroup.SelectedValue = user.UserExtensionTypeId.ToString();
                    ddlJournal.SelectedValue = user.JournalId.ToString();
                    txtPriority.Text = user.Priority.ToString();
                    if (user.ImgFile != null)
                    {
                        string url = user.ImgFile.Remove(0,1);
                        imgPath.ImageUrl = url;
                        imgPath.Visible = true;
                    }
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string message = string.Empty;
        UploadFile upload = new UploadFile();
        string urlFile = string.Empty;
        if (ViewState["Id"] == null)
        {
            UserExtension user = new UserExtension();
            user.FullName = txtFullname.Text;
            user.PrifixName = txtPrifixName.Text;
            user.CompanyName = txtCompanyName.Text;
            user.PositionName = txtPositionName.Text;
            user.MajoringInScience = txtMajoringInScience.Text;
            user.PositionInScient = txtPositionInScient.Text;
            user.Phone = txtPhone.Text;
            user.Email = txtEmail.Text;
            user.UserExtensionTypeId = byte.Parse(ddlGroup.SelectedValue);
            user.JournalId = int.Parse(ddlJournal.SelectedValue);
            user.Priority = Convert.ToByte(txtPriority.Text);

            if (fulImagePath.HasFile)
            {
                message = upload.SaveFile(fulImagePath.PostedFile, fulImagePath, ref urlFile, "/File/");
                if (message.Contains("Có lỗi"))
                {
                    lblMessage.Text = "Có lỗi " + message;
                    return;
                }
                user.ImgFile = urlFile;
            }

            using (var obj = new DataClassesDataContext())
            {
                try
                {
                    obj.UserExtensions.InsertOnSubmit(user);
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
            id = int.Parse(ViewState["Id"].ToString());
            using (var data = new DataClassesDataContext())
            {
                UserExtension user = data.UserExtensions.SingleOrDefault(x => x.Id == id);
                if (user != null)
                {
                    user.FullName = txtFullname.Text;
                    user.PrifixName = txtPrifixName.Text;
                    user.CompanyName = txtCompanyName.Text;
                    user.PositionName = txtPositionName.Text;
                    user.MajoringInScience = txtMajoringInScience.Text;
                    user.PositionInScient = txtPositionInScient.Text;
                    user.Phone = txtPhone.Text;
                    user.Email = txtEmail.Text;
                    user.UserExtensionTypeId = byte.Parse(ddlGroup.SelectedValue);
                    user.JournalId = int.Parse(ddlJournal.SelectedValue);
                    user.Priority = Convert.ToByte(txtPriority.Text);
                    if (fulImagePath.HasFile)
                    {
                        message = upload.SaveFile(fulImagePath.PostedFile, fulImagePath, ref urlFile, "/File/");
                        if (message.Contains("Có lỗi"))
                        {
                            lblMessage.Text = "Có lỗi " + message;
                            return;
                        }
                        user.ImgFile = urlFile;
                    }
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