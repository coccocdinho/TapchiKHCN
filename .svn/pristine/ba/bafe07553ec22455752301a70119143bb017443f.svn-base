<%@ WebHandler Language="C#" Class="DeleteNews" %>

using System;
using System.Web;
using System.Linq;
using System.Transactions;

public class DeleteNews : IHttpHandler
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
            long keyId = FormHelper.GetLong("KeyId");
            using (var obj = new DataClassesDataContext())
            {
                var objProcess = obj.News.SingleOrDefault(x => x.NewId == keyId);
                obj.News.DeleteOnSubmit(objProcess);
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