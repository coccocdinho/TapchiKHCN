<%@ WebHandler Language="C#" Class="DeleteUserExDetail" %>

using System;
using System.Web;
using System.Linq;

public class DeleteUserExDetail : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.Write(Process(context));
    }

    public string Process(HttpContext context)
    {
        try
        {
            int keyId = FormHelper.GetInt("KeyId");
            using (var obj = new DataClassesDataContext())
            {
                var objProcess = obj.UserExtensions.SingleOrDefault(x => x.Id == keyId);
                obj.UserExtensions.DeleteOnSubmit(objProcess);
                obj.SubmitChanges();
                return "";
            }
        }
        catch (Exception)
        {
            return "Có lỗi khi xử lý dữ liệu.";
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}