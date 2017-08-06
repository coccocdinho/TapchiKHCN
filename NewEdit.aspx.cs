using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewEdit : AuthenticatePage
{
    int cKeyId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.LoadGroupNew(ddlGroup);
            LoadData();
        }
    }

    protected void LoadData()
    {
        try
        {
            ViewState["NewId"] = Request.QueryString["KeyId"].ToString();
        }
        catch (Exception)
        {
            ViewState["NewId"] = null;
        }

        if (ViewState["NewId"] != null)
        {
            cKeyId = int.Parse(ViewState["NewId"].ToString());
            New news = new New();
            using (var data = new DataClassesDataContext())
            {
                news = data.News.Single(n => n.NewId == cKeyId);
                txtTitle.Text = news.Title;
                txtShortDescription.Text = news.ShortDescription;
                radContent.Content = news.Content;
                cbPublísh.Checked = news.Publish;
                ddlGroup.SelectedValue = news.GroupNewId.ToString();
                img.ImageUrl = "~"+news.Images;
                img.Width = 200;
                img.Height = 160;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        UploadFile upload = new UploadFile();
        string urlImages = string.Empty;
        if (fulImages.HasFile)
        {
            string result = upload.SaveFile(fulImages.PostedFile, fulImages, ref urlImages);
            if (result.Length > 0)
            {
                lblMessage.Text = "Có lỗi " + result;
                return;
            }
        }
        New news = new New();

        string message = string.Empty;
        if (ViewState["NewId"] == null)
        {
            news.Title = txtTitle.Text;
            news.ShortDescription = txtShortDescription.Text;
            string check = radContent.Text;
            news.Content = radContent.Content;
            news.Images = urlImages;
            news.GroupNewId = int.Parse(ddlGroup.SelectedValue);
            news.TotalView = 0;
            if (cbPublísh.Checked)
            {
                news.Publish = true;
            }
            else
            {
                news.Publish = false;
            }
            news.CreateDate = DateTime.Now;
            using (var data = new DataClassesDataContext())
            {
                try
                {
                    data.News.InsertOnSubmit(news);
                    data.SubmitChanges();
                }
                catch (Exception)
                {
                    lblMessage.Text = "Có lỗi khi thêm mới.";
                    lblMessage.Style.Add("color", "red");
                    return;
                }
            }

            lblMessage.Text = "Thêm mới thành công.";
        }
        else
        {
            cKeyId = int.Parse(ViewState["NewId"].ToString());
            using (var data = new DataClassesDataContext())
            {
                try
                {
                    news = data.News.Single(n => n.NewId == cKeyId);
                    news.Title = txtTitle.Text;
                    news.ShortDescription = txtShortDescription.Text;
                    news.Content = radContent.Content;
                    if (!string.IsNullOrEmpty(urlImages))
                    {
                        news.Images = urlImages;
                    }
                    news.GroupNewId = int.Parse(ddlGroup.SelectedValue);
                    data.SubmitChanges();
                }
                catch (Exception)
                {
                    lblMessage.Text = "Có lỗi khi cập nhật.";
                    lblMessage.Style.Add("color", "red");
                    return;
                }
            }
            lblMessage.Text = "Cập nhật thành công.";
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "dialog", "$(function(){window.parent.Popup.UsersDetails.ClosePopup('reload');});", true);
        return;
    }
}