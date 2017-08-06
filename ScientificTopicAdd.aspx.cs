using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

public partial class ScientificTopicAdd : AuthenticatePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.LoadChuyenSanToDropdownlist(ddlChuyenSan);
            using (var data = new DataClassesDataContext())
            {
                var user = data.Users.SingleOrDefault(x => x.UserId == UserID);
                txtAuthorName.Text = user.FullName;
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string message = string.Empty;
        message = ValidForm();
        if (!string.IsNullOrEmpty(message))
        {
            ScriptManager.RegisterClientScriptBlock(btnSave, this.GetType(), "", "alert('"+message+"');", true);
            return;
        }

        using (var tran = new TransactionScope())
        {
            using (var data = new DataClassesDataContext())
            {
                try
                {
                    ScientificTopic topic = new ScientificTopic();
                    topic.Title = txtTitle.Text;
                    topic.TitleEn = txtTitleEn.Text;
                    topic.Images = "";
                    topic.ShortDesciption = txtShortDescription.Text;
                    topic.ShortDesciptionEn = txtShortDescriptionEn.Text;
                    topic.Content = "";
                    topic.UserIdCreate = UserID;
                    topic.CreateDate = DateTime.Now;
                    topic.UserIdUpdate = 0;
                    topic.UpdateDate = DateTime.Now;
                    topic.ScientificTopicStatusIdId = 1;// Chờ duyệt
                    topic.GroupTopicId = 0;
                    topic.ToTalView = 0;
                    topic.Priority = 100;
                    topic.ChuyensanId = Convert.ToInt32(ddlChuyenSan.SelectedValue);
                    topic.CurrentUserId = Common.DivisionUserProcess(data, 0, Constants.RoleVanPhongToaSoan, Convert.ToInt32(ddlChuyenSan.SelectedValue), ref message);
                    topic.FilePath = hplUrlFile.NavigateUrl;
                    topic.NumberPage = 0;
                    topic.Posittion = "";
                    topic.ListUserPhanBien = "";
                    topic.TopicCode = "";
                    topic.AppointmentDate = DateTime.Now;
                    topic.MetaKeyword = txtMetaKeyword.Text;
                    topic.MetaKeywordEn = txtMetaKeywordEn.Text;
                    topic.CommentFilePath = "";
                    topic.SameAuthorName = txtSameAuthorName.Text;
                    topic.SameAuthorAddress = txtSameAuthorAddress.Text;

                    data.ScientificTopics.InsertOnSubmit(topic);
                    data.SubmitChanges();

                    ScientificTopicProcess process = new ScientificTopicProcess();
                    process.ScientificTopicId = topic.ScientificTopicId;
                    process.UserId = UserID;
                    process.ProcessContent = txtProcessContent.Text;
                    process.ProcessDate = DateTime.Now;
                    data.ScientificTopicProcesses.InsertOnSubmit(process);
                    data.SubmitChanges();

                    tran.Complete();

                    lblMessage.Text = "Bạn đã gửi bài thành công.";
                    txtTitle.Text = "";
                    txtShortDescription.Text = "";
                    ScriptManager.RegisterClientScriptBlock(btnSave, this.GetType(), "", "alert('Gửi bài thành công.');window.opener.location.reload(true);window.close();", true);
                }
                catch (Exception)
                {
                    ScriptManager.RegisterClientScriptBlock(btnSave, this.GetType(), "", "alert('Có lỗi khi gửi bài.');window.opener.location.reload(true);window.close();", true);
                    lblMessage.Text = "Có lỗi khi gửi bài. Bạn vui lòng thử lại sau.";
                    lblMessage.Style.Add("color", "red");
                    return;
                }
            }
        }
    }

    protected string ValidForm()
    {
        string msg = string.Empty;

        if (txtTitle.Text.Trim().Length == 0) return "Bạn phải nhập Tên bài báo";
        if (txtTitleEn.Text.Trim().Length == 0) return "Bạn phải nhập Tên bài báo bằng tiếng Anh";
        if (txtShortDescription.Text.Trim().Length == 0) return "Bạn phải nhập Mô tả ngắn";
        if (txtShortDescriptionEn.Text.Trim().Length == 0) return "Bạn phải nhập Mô tả ngắn bằng tiếng Anh";
        if (ddlChuyenSan.SelectedValue == "0") return "Bạn phải chọn phân loại";
        if (hplUrlFile.NavigateUrl.Length==0) return "Bạn phải nhập File đính kèm";
        if (txtMetaKeyword.Text.Trim().Length == 0) return "Bạn phải nhập từ khóa tiếng Việt";
        if (txtMetaKeywordEn.Text.Trim().Length == 0) return "Bạn phải nhập từ khóa tiếng Anh";        

        return msg;
    }

    protected void btnUpFile_Click(object sender, EventArgs e)
    {
        UploadFile upload = new UploadFile();
        string urlFile = string.Empty;
        string result = string.Empty;
        if (fulFile.HasFile)
        {
            result = upload.SaveFile(fulFile.PostedFile, fulFile, ref urlFile, "/File/");
            if (result.Contains("Có lỗi"))
            {
                lblMessage.Text = "Có lỗi " + result;
                return;
            }
        }
        hplUrlFile.NavigateUrl = urlFile;
        hplUrlFile.Text = result;
    }
}