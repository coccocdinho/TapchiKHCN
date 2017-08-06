using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GroupTopicAddPage : AuthenticatePage
{
    int ckeyId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.LoadChuyenSanToDropdownlist(ddlChuyensan);
            rbChose2.Checked = true;
            LoadGroupTopic();
            InitData();
            if (RoleId == Constants.RoleTongBienTap)// Biên tập thì hiện ra phần update file cho tạp chí
            {
                pnlBienTap.Visible = false;
            }
            else
            {
                pnlBienTap.Visible = true;
            }
        }
    }

    public void LoadGroupTopic()
    {
        using (var data = new DataClassesDataContext())
        {
            ddlGroupTopic.DataSource = data.GroupTopics.Where(x => x.Level == 1).OrderBy(x => x.Name).ToList();
            ddlGroupTopic.DataValueField = "GroupTopicId";
            ddlGroupTopic.DataTextField = "Name";
            ddlGroupTopic.DataBind();
            //ddlGroupTopic.Items.Insert(0, new ListItem("-- Chọn năm --", "0"));// 0 is index of item
        }
    }

    public void InitData()
    {
        try
        {
            ViewState["GroupTopicId"] = Request.QueryString["KeyId"].ToString();
            ckeyId = int.Parse(ViewState["GroupTopicId"].ToString());
        }
        catch (Exception)
        {
            ViewState["GroupTopicId"] = null;
        }
        if (ckeyId>0)
        {
            using (var data = new DataClassesDataContext())
            {
                var gt = data.GroupTopics.Single(x => x.GroupTopicId == ckeyId);
                txtName.Text = gt.Name;
                cbStatus.Checked = gt.GroupTopicStatus;
                ddlGroupTopic.SelectedValue = gt.ParentId.ToString();
                ddlChuyensan.SelectedValue = gt.ChuyensanId.ToString();
                if (!string.IsNullOrEmpty(gt.PathFile))
                {
                    lblFile.Visible = true;
                    lblFile.Text = gt.PathFile.Replace("/Images/News/", "");
                }
                else
                {
                    lblFile.Text = "Chưa có file";
                }
                txtName.Text = gt.Name;
                rbChose2.Checked = false;
                rbChose.Checked = true;
                rbChose.Enabled = false;
                rbChose2.Enabled = false;
                txtName.Visible = true;
                txtName.ReadOnly = true;
            }
        }
        else
        {
            txtName.Text = "";
            btnSave.Text = "Thêm mới";
        }

        List<ListItem> list1 = new List<ListItem>();
        for (int i = 1; i < 301; i++)
        {
            list1.Add(new ListItem(i.ToString(), i.ToString()));
        }
        ddlTap.DataSource = list1;
        ddlTap.DataBind();

        list1.Clear();
        for (int i = 1; i < 13; i++)
        {
            list1.Add(new ListItem(i.ToString(), i.ToString()));
        }
        ddlSo.DataSource = list1;
        ddlSo.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string check = string.Empty;
        if (ViewState["GroupTopicId"] == null) // Thêm mới
        {
            try
            {
                GroupTopic gTopic = new GroupTopic();
                if (!rbChose.Checked)
                {
                    gTopic.Name = "Tập " + ddlTap.SelectedValue + " Tạp chí số " + ddlSo.SelectedValue + " năm " + ddlGroupTopic.SelectedItem.Text;
                }
                else
                {
                    gTopic.Name = txtName.Text;
                }
                using (var data = new DataClassesDataContext())
                {
                    if (data.GroupTopics.FirstOrDefault(x => x.Name == gTopic.Name) != null)
                    {
                        check = "Tên tạp chí đã tồn tại.";
                        ScriptManager.RegisterClientScriptBlock(btnSave, this.GetType(), "", "alert('Tên tạp chí đã tồn tại.');window.opener.location.reload(true);window.close();", true);
                        return;
                    }
                }

                gTopic.ParentId = int.Parse(ddlGroupTopic.SelectedValue);
                gTopic.ChuyensanId = int.Parse(ddlChuyensan.SelectedValue);
                gTopic.GroupTopicStatus = cbStatus.Checked;
                if (cbStatus.Checked)
                {
                    gTopic.PublicDate = DateTime.Now;
                }
                gTopic.NumberTopic = 0;
                gTopic.CreateDate = DateTime.Now;
                gTopic.PublicDate = DateTime.Now;
                gTopic.Level = 1;
                gTopic.Description = txtDescription.Text;
                if (ddlGroupTopic.SelectedValue != "0")
                {
                    gTopic.Level = 2;
                }
                gTopic.PathFile = lblFile.Text;

                using (var data = new DataClassesDataContext())
                {
                    data.GroupTopics.InsertOnSubmit(gTopic);
                    data.SubmitChanges();
                }

                ScriptManager.RegisterClientScriptBlock(btnSave, this.GetType(), "", "alert('Cập nhật tạp chí thành công.');$(function(){window.parent.Popup.ObjDetail.ClosePopup('reload');});", true);
                return;

            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, this.GetType(), "", "alert('Có lỗi khi thêm mới.');window.opener.location.reload(true);window.close();", true);
                return;
            }

        }
        else // Cập nhật lại tạp chí
        {
            try
            {
                using (var data = new DataClassesDataContext())
                {
                    int groupTopicId = int.Parse(ViewState["GroupTopicId"].ToString());
                    GroupTopic gTopic = data.GroupTopics.Single(x => x.GroupTopicId == groupTopicId);
                    if (!rbChose.Checked)
                    {
                        gTopic.Name = "Tập " + ddlTap.SelectedValue + " Tạp chí số " + ddlSo.SelectedValue + " năm " + ddlGroupTopic.SelectedItem.Text;
                    }
                    else
                    {
                        gTopic.Name = txtName.Text;
                    }

                    gTopic.ParentId = int.Parse(ddlGroupTopic.SelectedValue);
                    gTopic.ChuyensanId = int.Parse(ddlChuyensan.SelectedValue);
                    gTopic.GroupTopicStatus = cbStatus.Checked;
                    gTopic.Description = txtDescription.Text;
                    if (cbStatus.Checked)
                    {
                        gTopic.PublicDate = DateTime.Now;
                    }
                    if (ddlGroupTopic.SelectedValue != "0")
                    {
                        gTopic.Level = 2;
                    }
                    gTopic.PathFile = lblFile.Text;

                    data.SubmitChanges();

                    ScriptManager.RegisterClientScriptBlock(btnSave, this.GetType(), "", "alert('Cập nhật tạp chí thành công.');$(function(){window.parent.Popup.ObjDetail.ClosePopup('reload');});", true);
                    return;
                }

            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, this.GetType(), "", "alert('Có lỗi khi cập nhật.');window.opener.location.reload(true);window.close();", true);
                return;
            }
        }
    }

    protected void btnUpdateLinkFile_Click(object sender, EventArgs e)
    {
        UploadFile upload = new UploadFile();
        string urlImages = string.Empty;
        if (fulFile.HasFile)
        {
            string result = upload.SaveFile(fulFile.PostedFile, fulFile, ref urlImages);
            if (result.Length > 0)
            {
                lblMessage.Text = "Có lỗi " + result;
                return;
            }
            else
            {
                lblFile.Visible = true;
                lblFile.Text = urlImages.Replace("/Images/News/","");
            }
        }
    }
    protected void rbChose_CheckedChanged(object sender, EventArgs e)
    {
        if (rbChose.Checked)
        {
            txtName.Visible = true;
        }
        else
        {
            txtName.Visible = false;
        }
        rbChose2.Checked = false;
    }
    protected void rbChose2_CheckedChanged(object sender, EventArgs e)
    {
        if (rbChose2.Checked)
        {
            txtName.Visible = false;
        }
        else
        {
            txtName.Visible = true;
        }
        rbChose.Checked = false;
    }
}