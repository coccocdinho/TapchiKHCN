<%@ WebHandler Language="C#" Class="DeleteScientificTopicStatus" %>

using System;
using System.Web;
using System.Linq;

public class DeleteScientificTopicStatus : IHttpHandler
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
                var objProcess = obj.ScientificTopicStatus.SingleOrDefault(x => x.ScientificTopicStatusId == keyId);
                obj.ScientificTopicStatus.DeleteOnSubmit(objProcess);
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