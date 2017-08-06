using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListScientTopicByGroup : AuthenticatePage
{
    int keyId = 0;
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
            ViewState["GroupId"] = Request.QueryString["KeyId"].ToString();
        }
        catch (Exception)
        {
            ViewState["GroupId"] = null;
        }

        if (ViewState["GroupId"] != null)
        {
            keyId = int.Parse(ViewState["GroupId"].ToString());
            using (var data = new DataClassesDataContext())
            {
                var list = (from st in data.ScientificTopics
                            join s in data.ScientificTopicStatus on st.ScientificTopicStatusIdId equals s.ScientificTopicStatusId
                            join au in data.Users on st.UserIdCreate equals au.UserId
                            where st.GroupTopicId == keyId
                            select new
                            {
                                ScientificTopicId = st.ScientificTopicId,
                                ScientificTopicStatusIdId = st.ScientificTopicStatusIdId,
                                Title = st.Title,
                                ShortDescription = st.ShortDesciption,
                                CreateDate = st.CreateDate,
                                FullName = au.FullName,
                                StatusName = s.Name
                            }).ToList();

                pager.DataSource = list;
                pager.BindToControl = rpList;
                rpList.DataSource = pager.DataSourcePaged;
                rpList.DataBind();
            }
        }
    }

    public string GetButtonFuntion(object keyId)
    {
        string message = string.Empty;
        string buttonViewEdit = "";
        string buttonListScientTopic = "";
        string buttonDelete = "";
        //buttonViewEdit = "<a id='idEdit' href='javascript:void(0)' onclick='OpenUpdate(" + keyId + "," + UserID + ");'>" +
        //            "<i class=\"ace-icon fa fa-pencil bigger-120\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Xử lý' style='cursor: pointer;'></i></a>";
        //buttonListScientTopic = "<a id='idHistory' href='javascript:void(0)' onclick='OpenListScienTopic(" + keyId + ")'>" +
        //"<i class=\"ace-icon fa fa-info-circle\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Danh sách bài báo' style='cursor: pointer;'></i></a>";
        buttonDelete = "<a id='idDelete' href='javascript:void(0)' onclick='OpenDelete(" + keyId + "," + UserID + ");'>" +
        "<i class=\"ace-icon fa fa-trash-o bigger-130\" alt='' data-toggle=\"popover\" data-trigger=\"hover\" data-placement=\"left\" data-trigger=\"hover\" data-content='Chưa phát hành' style='cursor: pointer;'></i></a>";
        //<i class="ace-icon fa fa-eye"></i>
        return (string.IsNullOrEmpty(buttonViewEdit) ? "" : (buttonViewEdit) + "&nbsp;&nbsp;") +
                (string.IsNullOrEmpty(buttonListScientTopic) ? "" : (buttonListScientTopic) + "&nbsp;&nbsp;") +
             (string.IsNullOrEmpty(buttonDelete) ? "" : (buttonDelete) + "&nbsp;&nbsp;");
    }
}