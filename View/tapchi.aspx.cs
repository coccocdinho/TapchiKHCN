﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_tapchi : System.Web.UI.Page
{
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
            int gId = int.Parse(Request.QueryString["gId"].ToString());
            using (var data = new DataClassesDataContext())
            {
                var listTopic = (from st in data.ScientificTopics
                                 join au in data.Users on st.UserIdCreate equals au.UserId
                                 join g in data.GroupTopics on st.GroupTopicId equals g.GroupTopicId
                                 where st.ScientificTopicStatusIdId == Constants.ScientificTopicStatus_daxuatban && g.GroupTopicStatus==true
                                 && st.GroupTopicId == gId
                                 select new
                                 {
                                     st.ScientificTopicId,
                                     author = au.FullName,
                                     st.ToTalView,
                                     st.Title,
                                     st.CreateDate,
                                     st.ShortDesciption,
                                     st.TitleEn
                                 }).ToList().OrderByDescending(x => x.ToTalView).Take(5);
                rptListTopic.DataSource = listTopic;
                rptListTopic.DataBind();

                var group = data.GroupTopics.SingleOrDefault(x => x.GroupTopicId == gId);
                lblGroupName.Text = group.Name;

                string linkDownFile = "";
                if (group.PathFile != null)
                {
                    if(group.PathFile.Length>0)
                    {
                    linkDownFile = "<a href=\"" + "../Images/News/" + group.PathFile + "\"><img title=\"Tải file\" width=\"24px\" height=\"24px\" src=\"images/pdficon.png\"></a>";
                    }

                }
                lblLinkDownFile.Text = linkDownFile;
            }
        }
        catch (Exception)
        {
        } 
    }
}