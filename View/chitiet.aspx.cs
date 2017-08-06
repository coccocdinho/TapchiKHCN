using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_chitiet : System.Web.UI.Page
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
        int newId = 0;
        try
        {
            newId = int.Parse(Request.QueryString["newId"].ToString());
            using (var data = new DataClassesDataContext())
            {
                var newdetails = data.News.FirstOrDefault(x => x.NewId == newId);
                if (newdetails != null)
                {
                    lblTitle.Text = newdetails.Title;
                    lblShortDescription.Text = newdetails.ShortDescription;
                    lblCreateDate.Text = newdetails.CreateDate.ToString("dd/MM/yyyy");
                    lblContentNew.Text = newdetails.Content;
                    lblTotalView.Text = newdetails.TotalView.ToString();

                    newdetails.TotalView += 1;
                    data.SubmitChanges();
                }
            }
        }
        catch (Exception)
        {

        }     
    }
}