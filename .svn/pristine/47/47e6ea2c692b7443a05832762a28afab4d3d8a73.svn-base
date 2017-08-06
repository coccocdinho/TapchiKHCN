using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usercontrol_UCTopicProcess : System.Web.UI.UserControl
{
    public long TopicId { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    protected void LoadData()
    {
        using (var data = new DataClassesDataContext())
        {
            var list = (from stp in data.ScientificTopicProcesses
                        join u in data.Users on stp.UserId equals u.UserId
                        where stp.ScientificTopicId == TopicId
                        select new
                        {
                            UserName = u.UserName,
                            ProcessContent = stp.ProcessContent,
                            ProcessDate = stp.ProcessDate
                        }).OrderByDescending(x => x.ProcessDate).ToList();
            if (list.Count() > 0)
            {
                rpList.DataSource = list;
                rpList.DataBind();
            }
        }
    }
}