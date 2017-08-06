﻿using System;
using System.Linq;
using System.Web.UI;

public partial class ScientificTopicStatusAdd : AuthenticatePage
{
    int cKeyId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    protected void LoadData()
    {
        try
        {
            ViewState["ScientificTopicStatusId"] = Request.QueryString["KeyId"].ToString();
        }
        catch (Exception)
        {
            ViewState["ScientificTopicStatusId"] = null;
        }

        if (ViewState["ScientificTopicStatusId"] != null)
        {
            long cKeyId = long.Parse(ViewState["ScientificTopicStatusId"].ToString());
            using (var obj = new DataClassesDataContext())
            {
                var objProcess = obj.ScientificTopicStatus.Single(x => x.ScientificTopicStatusId == cKeyId);
                txtName.Text = objProcess.Name;
                txtNameForAuthor.Text = objProcess.NameForAuthor;
                txtDescription.Text = objProcess.Description;
                cbIsReadOnly.Checked = objProcess.IsReadOnly;
                cbIsUpdateGroup.Checked = objProcess.IsUpdateGroup;
                cbIsUpdateJournal.Checked = objProcess.IsUpdateJournal;
                cbIsUpdateReviewer.Checked = objProcess.IsUpdateReviewer;
                chkIsViewpnlChonChuyenSan.Checked = objProcess.IsViewpnlChonChuyenSan;
                chkIsViewpnlGroupTopic.Checked = objProcess.IsViewpnlGroupTopic;
                chkIsViewpnlTopicCode.Checked = objProcess.IsViewpnlTopicCode;
                chkIsViewpnlPositon.Checked = objProcess.IsViewpnlPositon;
                chkIsViewpnlNumber.Checked = objProcess.IsViewpnlNumber;
                chkIsViewpnlChonPhanBien.Checked = objProcess.IsViewpnlChonPhanBien;
                chkIsViewpnlAppointmentDate.Checked = objProcess.IsViewpnlAppointmentDate;
                chkIsUpdateAppointmentDate.Checked = objProcess.IsUpdateAppointmentDate;
                chkIsUpdateCommentFile.Checked = objProcess.IsUpdateCommentFile;
                chkIsViewCommentFile.Checked = objProcess.IsViewCommentFile;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string message = string.Empty;
        ScientificTopicStatus objProcess = new ScientificTopicStatus();

        using (var obj = new DataClassesDataContext())
        {
            if (ViewState["ScientificTopicStatusId"] == null)
            {
                objProcess.Name = txtName.Text;
                objProcess.NameForAuthor = txtNameForAuthor.Text;
                objProcess.Description = txtDescription.Text;
                objProcess.CCSstyle = "";
                objProcess.IsReadOnly = cbIsReadOnly.Checked;
                objProcess.IsUpdateGroup = cbIsUpdateGroup.Checked;
                objProcess.IsUpdateJournal = cbIsUpdateJournal.Checked;
                objProcess.IsUpdateReviewer = cbIsUpdateReviewer.Checked;
                objProcess.IsViewpnlChonChuyenSan = chkIsViewpnlChonChuyenSan.Checked;
                objProcess.IsViewpnlGroupTopic = chkIsViewpnlGroupTopic.Checked;
                objProcess.IsViewpnlTopicCode = chkIsViewpnlTopicCode.Checked;
                objProcess.IsViewpnlPositon = chkIsViewpnlPositon.Checked;
                objProcess.IsViewpnlNumber = chkIsViewpnlNumber.Checked;
                objProcess.IsViewpnlChonPhanBien = chkIsViewpnlChonPhanBien.Checked;
                objProcess.IsViewpnlAppointmentDate = chkIsViewpnlAppointmentDate.Checked;
                objProcess.IsUpdateAppointmentDate = chkIsUpdateAppointmentDate.Checked;
                objProcess.IsViewCommentFile = chkIsViewCommentFile.Checked;
                objProcess.IsUpdateCommentFile = chkIsUpdateCommentFile.Checked;

                try
                {
                    obj.ScientificTopicStatus.InsertOnSubmit(objProcess);
                    obj.SubmitChanges();
                    lblMessage.Text = "Xử lý thành công.";
                }
                catch (Exception)
                {
                    lblMessage.Text = "Có lỗi khi xử lý";
                }
            }
            else
            {
                try
                {
                    cKeyId = int.Parse(ViewState["ScientificTopicStatusId"].ToString());
                    objProcess = obj.ScientificTopicStatus.Single(x => x.ScientificTopicStatusId == cKeyId);

                    objProcess.Name = txtName.Text;
                    objProcess.NameForAuthor = txtNameForAuthor.Text;
                    objProcess.Description = txtDescription.Text;
                    objProcess.IsReadOnly = cbIsReadOnly.Checked;
                    objProcess.IsUpdateGroup = cbIsUpdateGroup.Checked;
                    objProcess.IsUpdateJournal = cbIsUpdateJournal.Checked;
                    objProcess.IsUpdateReviewer = cbIsUpdateReviewer.Checked;
                    objProcess.IsViewpnlChonChuyenSan = chkIsViewpnlChonChuyenSan.Checked;
                    objProcess.IsViewpnlGroupTopic = chkIsViewpnlGroupTopic.Checked;
                    objProcess.IsViewpnlTopicCode = chkIsViewpnlTopicCode.Checked;
                    objProcess.IsViewpnlPositon = chkIsViewpnlPositon.Checked;
                    objProcess.IsViewpnlNumber = chkIsViewpnlNumber.Checked;
                    objProcess.IsViewpnlChonPhanBien = chkIsViewpnlChonPhanBien.Checked;
                    objProcess.IsViewpnlAppointmentDate = chkIsViewpnlAppointmentDate.Checked;
                    objProcess.IsUpdateAppointmentDate = chkIsUpdateAppointmentDate.Checked;
                    objProcess.IsViewCommentFile = chkIsViewCommentFile.Checked;
                    objProcess.IsUpdateCommentFile = chkIsUpdateCommentFile.Checked;

                    obj.SubmitChanges();
                    lblMessage.Text = "Cập nhật thành công.";
                }
                catch (Exception)
                {
                    lblMessage.Text = "Có lỗi khi xử lý";
                }
            }

        }

        ScriptManager.RegisterStartupScript(this, GetType(), "dialog", "$(function(){window.parent.Popup.UsersDetails.ClosePopup('reload');});", true);
        return;
    }
}