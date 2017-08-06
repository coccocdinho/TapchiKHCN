using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_chitietbaibao : System.Web.UI.Page
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
        int scId = 0;
        try
        {
            scId = int.Parse(Request.QueryString["id"].ToString());
            using (var data = new DataClassesDataContext())
            {
                var scientTopic = data.ScientificTopics.FirstOrDefault(x => x.ScientificTopicId == scId);
                if (scientTopic != null)
                {
                    lblTitle.Text = scientTopic.Title;
                    lblTitleEn.Text = scientTopic.TitleEn;
                    lblShortDescription.Text = scientTopic.ShortDesciption;
                    lblShortDescriptionEn.Text = scientTopic.ShortDesciptionEn;
                    lblPosition.Text = Common.GetGroupName(scientTopic);
                    lblToltalView.Text = scientTopic.ToTalView.ToString();
                    lblKeyword.Text = scientTopic.MetaKeyword;
                    lblKeywordEn.Text = scientTopic.MetaKeywordEn;
                    var author = data.Users.SingleOrDefault(x => x.UserId == scientTopic.UserIdCreate);
                    if (scientTopic.SameAuthorName.Length > 0)
                    {
                        lblAuthor.Text = author.FullName + ", " + scientTopic.SameAuthorName;
                    }
                    else
                    {
                        lblAuthor.Text = author.FullName;
                    }

                    scientTopic.ToTalView += 1;
                    data.SubmitChanges();
                }
            }
        }
        catch (Exception)
        {

        }
    }
}