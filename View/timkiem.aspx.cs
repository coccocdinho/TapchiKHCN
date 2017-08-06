using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_timkiem : System.Web.UI.Page
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
            string keyword = Request.QueryString["keyword"].ToString();
            using (var data = new DataClassesDataContext())
            {
                var listTopic = (from st in data.ScientificTopics
                                 join au in data.Users on st.UserIdCreate equals au.UserId
                                 join g in data.GroupTopics on st.GroupTopicId equals g.GroupTopicId
                                 where st.ScientificTopicStatusIdId == Constants.ScientificTopicStatus_daxuatban && g.GroupTopicStatus == true
                                 && (st.MetaKeyword.Contains(keyword) || st.MetaKeywordEn.Contains(keyword) || st.Title.Contains(keyword) || st.TitleEn.Contains(keyword)
                                 || st.ShortDesciption.Contains(keyword) || st.ShortDesciptionEn.Contains(keyword)
                                 || st.SameAuthorName.Contains(keyword) || au.FullName.Contains(keyword)
                                 )
                                 select new
                                 {
                                     st.ScientificTopicId,
                                     author = au.FullName,
                                     st.ToTalView,
                                     st.Title,
                                     st.CreateDate,
                                     st.ShortDesciption,
                                     st.SameAuthorName,
                                     st.TitleEn
                                 }).ToList().OrderByDescending(x => x.ToTalView);
                pager.DataSource = listTopic.ToList();
                pager.BindToControl = rptListTopic;
                rptListTopic.DataSource = pager.DataSourcePaged;
                rptListTopic.DataBind();
            }
        }
        catch (Exception)
        {
        }
    }
}