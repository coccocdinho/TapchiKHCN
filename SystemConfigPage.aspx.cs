using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SystemConfigPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ResetForm();
            LoadData();
        }
    }

    protected void LoadData()
    {
        using (var data = new DataClassesDataContext())
        {
            var config = data.SystemConfigs.FirstOrDefault();
            imgLogo.ImageUrl = "~" +config.Logo;
            imgBanner.ImageUrl = "~" + config.Banner;
            txtSologan.Text = config.Sologan;
            txtEmailSmtp.Text = config.SmtpEmailAccount;
            txtPassSmtp.Text = config.SmtpEmailPassword;
            txtIntroduction.Content = config.Introduction;
            txtCompanyName.Text = config.CompanyName;
            txtWebsite.Text = config.WebsiteName;
            txtCopyRight.Text = config.CopyRight;
            txtAddress.Text = config.Address;
            txtPhone.Text = config.Phone;
            txtEmail.Text = config.Email;
            txtDeverloper.Text = config.Deverloper;
            hdfId.Value = config.Id.ToString();
            txtMauNhanXet.Content = config.MauNhanXet;
            txtMauMailGuiPhanBien.Content = config.MauMailGuiPhanBien;
        }
    }

    protected void ResetForm()
    {
        lblMessage.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            using (var data = new DataClassesDataContext())
            {
                var config = data.SystemConfigs.FirstOrDefault();
                config.Sologan = txtSologan.Text;
                config.SmtpEmailAccount = txtEmailSmtp.Text;
                config.SmtpEmailPassword = txtPassSmtp.Text;
                config.Introduction = txtIntroduction.Content;
                config.CompanyName = txtCompanyName.Text;
                config.WebsiteName = txtWebsite.Text;
                config.CopyRight = txtCopyRight.Text;
                config.Address = txtAddress.Text;
                config.Phone = txtPhone.Text;
                config.Email = txtEmail.Text;
                config.Deverloper = txtDeverloper.Text;
                config.MauNhanXet = txtMauNhanXet.Content;
                config.MauMailGuiPhanBien = txtMauMailGuiPhanBien.Text;

                data.SubmitChanges();
            }
            lblMessage.Text = "Cập nhật thành công.";
        }
        catch (Exception)
        {
            lblMessage.Text = "Có lỗi khi cập nhật";
            lblMessage.Style.Add("color", "red");
        }

    }

    protected void btnUpdateLogo_Click(object sender, EventArgs e)
    {
        UploadFile upload = new UploadFile();
        string urlImages = string.Empty;
        if (fulLogo.HasFile)
        {
            string result = upload.SaveFile(fulLogo.PostedFile, fulLogo, ref urlImages);
            if (result.Length > 0)
            {
                lblMessage.Text = "Có lỗi " + result;
                return;
            }
        }

        using (var data = new DataClassesDataContext())
        {
            var config = data.SystemConfigs.FirstOrDefault();
            config.Logo = urlImages;
            data.SubmitChanges();
            imgLogo.ImageUrl = urlImages;
        }
    }

    protected void btnUpdateBanner_Click(object sender, EventArgs e)
    {
        UploadFile upload = new UploadFile();
        string urlImages = string.Empty;
        if (fulBanner.HasFile)
        {
            string result = upload.SaveFile(fulBanner.PostedFile, fulBanner, ref urlImages);
            if (result.Length > 0)
            {
                lblMessage.Text = "Có lỗi " + result;
                return;
            }
        }

        using (var data = new DataClassesDataContext())
        {
            var config = data.SystemConfigs.FirstOrDefault();
            config.Banner = urlImages;
            data.SubmitChanges();
            imgBanner.ImageUrl = urlImages;
        }
    }

    protected void ExportToWord_Click(object sender, EventArgs e)
    {
        txtMauNhanXet.ExportToRtf();
    }

}