<%@ WebHandler Language="C#" Class="DeleteJournal" %>

using System;
using System.Web;
using System.Linq;
using System.Transactions;

public class DeleteJournal : IHttpHandler
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
                var objProcess = obj.ChuyenSans.SingleOrDefault(x => x.Id == keyId);
                obj.ChuyenSans.DeleteOnSubmit(objProcess);
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