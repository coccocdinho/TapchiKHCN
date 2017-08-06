using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for UploadFile
/// </summary>
public class UploadFile
{
	public UploadFile()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string SaveFile(HttpPostedFile file, FileUpload FileUpload1, ref string pathFile)
    {
        try
        {
            // Specify the path to save the uploaded file to.
            //String path = Server.MapPath("~/UploadedImages/");
            string savePath = HttpContext.Current.Server.MapPath("~/Images/News/");
            // Get the name of the file to upload.
            string fileName = FileUpload1.FileName;
            // Create a temporary file name to use for checking duplicates.
            fileName = DateTime.Now.Year.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + fileName;
            // Append the name of the file to upload to the path.
            savePath += fileName;
            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            pathFile = "/Images/News/" + fileName;
            FileUpload1.SaveAs(savePath);

        }
        catch (Exception ex)
        {
            return "Có lỗi khi up file." + ex.Message;
        }
        return "";
    }

    public string SaveFile(HttpPostedFile file, FileUpload FileUpload1, ref string pathFile, string pathFolder)
    {
        string rFileName = string.Empty;
        try
        {
            // Specify the path to save the uploaded file to.
            //String path = Server.MapPath("~/UploadedImages/");
            string savePath = HttpContext.Current.Server.MapPath("~" + pathFolder);
            // Get the name of the file to upload.
            string fileName = FileUpload1.FileName;
            // Create a temporary file name to use for checking duplicates.
            fileName = DateTime.Now.Year.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + fileName;
            rFileName = fileName;
            // Append the name of the file to upload to the path.
            savePath += fileName;
            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            pathFile = pathFolder + fileName;
            FileUpload1.SaveAs(savePath);

        }
        catch (Exception ex)
        {
            return "Có lỗi khi up file." + ex.Message;
        }
        return rFileName;
    }
}