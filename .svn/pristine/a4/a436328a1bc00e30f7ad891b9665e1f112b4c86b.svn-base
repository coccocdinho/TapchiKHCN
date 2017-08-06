using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class KetXuatNhanXet : System.Web.UI.Page
{
    private ReportDocument myReportDocument;
    public int ScId
    {
        get
        {
            return int.Parse(Request.QueryString["KeyId"]);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {

        if (myReportDocument != null)
        {
            myReportDocument.Clone();

            myReportDocument.Dispose();

            myReportDocument = null;

            GC.Collect();
        }
    }

    public void LoadData()
    {
        lblNam1.Text = DateTime.Now.Year.ToString();
        using (var data = new DataClassesDataContext())
        {
            ScientificTopic topic = data.ScientificTopics.Single(x => x.ScientificTopicId == ScId);
            txtTenBaiBao.Text = topic.Title;
            lblMaSo.Text = topic.TopicCode;

            User phanbienU = data.Users.Single(x => x.UserId == topic.CurrentUserId);
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        using (myReportDocument = new ReportDocument())
        {
            try
            {
                string ReportName = HttpContext.Current.Server.MapPath(@"~/rptTest.rpt");
                myReportDocument.Load(ReportName);
                //myReportDocument.SetDataSource(ds);
                myReportDocument.SetParameterValue("Ngay", DateTime.Now.Day);
                myReportDocument.SetParameterValue("thang", DateTime.Now.Month);
                myReportDocument.SetParameterValue("Nam", DateTime.Now.Year);
                myReportDocument.SetParameterValue("TenBaiBao", txtTenBaiBao.Text);
                myReportDocument.SetParameterValue("MaSoBaiBao", lblMaSo.Text);
                myReportDocument.SetParameterValue("NhungYKienKhac", txtYKienKhac.Text);
                myReportDocument.SetParameterValue("YNghiaKhoaHocVaThucTien", txtYNghiaThucTien.Text);
                myReportDocument.SetParameterValue("HinhThucVaBoCuc", txtHinhThucBoCuc.Text);
                myReportDocument.SetParameterValue("CachTiepCanVaPhuongThucNghienCuu", txtCachTiepCan.Text);
                myReportDocument.SetParameterValue("NghienCuuMoi", txtKetQuaNghienCuu.Text);
                myReportDocument.SetParameterValue("NhungVanDeCanSuaTruocKhiDang", txtNhungVanDe.Text);

                myReportDocument.SetParameterValue("KetLuan_1", cbkeLuan1.Checked ? "1" : "0");
                myReportDocument.SetParameterValue("KetLuan_2", cbkeLuan2.Checked ? "1" : "0");
                myReportDocument.SetParameterValue("KetLuan_3", cbkeLuan3.Checked ? "1" : "0");
                myReportDocument.SetParameterValue("KetLuan_4", cbkeLuan4.Checked ? "1" : "0");

                //myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                myReportDocument.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, "KetXuatNhanXet" + DateTime.Now.ToString("dd_MM_yyyy"));
            }
            catch (Exception ex)
            {

            }
        }
    }
}