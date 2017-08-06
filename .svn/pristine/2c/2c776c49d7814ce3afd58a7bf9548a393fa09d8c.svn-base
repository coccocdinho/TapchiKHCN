using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.Serialization;

public class FormHelper
{
    public static int GetInt(string key, int defaultValue)
    {
        try { return int.Parse(HttpContext.Current.Request.Form[key]); }
        catch { return defaultValue; }
    }
    public static int GetInt(string key)
    {
        return GetInt(key, 0);
    }
    public static int GetIntRequest(object RequestValue, int defaultValue)
    {
        try { return int.Parse(RequestValue.ToString()); }
        catch { return defaultValue; }
    }
    public static long GetLong(string key, long defaultValue)
    {
        try { return long.Parse(HttpContext.Current.Request.Form[key]); }
        catch { return defaultValue; }
        //
    }
    public static long GetLongRequest(object RequestValue, long defaultValue)
    {
        try { return Int64.Parse(RequestValue.ToString()); }
        catch { return defaultValue; }
    }
    public static double GetDouble(string key, double defaultValue)
    {
        try { return double.Parse(HttpContext.Current.Request.Form[key]); }
        catch { return defaultValue; }
    }
    public static double GetDoubleRequest(object RequestValue, double defaultValue)
    {
        try { return double.Parse(RequestValue.ToString()); }
        catch { return defaultValue; }
    }
    public static long GetLong(string key)
    {
        return GetLong(key, 0);
    }
    public static bool GetBool(string key, bool defaultValue)
    {
        try { return bool.Parse(HttpContext.Current.Request.Form[key]); }
        catch { return defaultValue; }
    }
    public static bool GetBoolRequest(object RequestValue, bool defaultValue)
    {
        try { return bool.Parse(RequestValue.ToString()); }
        catch { return defaultValue; }
    }
    public static bool GetBool(string key)
    {
        return GetBool(key, false);
    }

    public static DateTime GetDateTime(string key)
    {
        try { return DateTime.Parse(HttpContext.Current.Request.Form[key]); }
        catch { return DateTime.Now; }
    }

    public static DateTime GetDateTimeRequest(object RequestValue)
    {
        try { return DateTime.Parse(RequestValue.ToString()); }
        catch { return DateTime.Now; }
    }

    public static string GetString(string key, string defaultValue)
    {
        try { return HttpContext.Current.Request.Form[key].Trim(); }
        catch { return string.Empty; }
    }
    public static string GetStringRequest(object RequestValue, string defaultValue)
    {
        try { return RequestValue.ToString(); }
        catch { return defaultValue; }
    }
    public static string GetString(string key)
    {
        return GetString(key, string.Empty);
    }
    public static string getAppKey
    {

        get { return "crtzg"; }
    }
}
public class URLHelper
{
    public static int GetInt(string par)
    {
        return GetInt(par, 0);
    }
    public static int GetInt(string par, int defvalue)
    {
        try { return int.Parse(HttpContext.Current.Request.QueryString[par]); }
        catch { return defvalue; }
    }
    public static long GetLong(string par, long defvalue)
    {
        try { return long.Parse(HttpContext.Current.Request.QueryString[par]); }
        catch { return defvalue; }
    }
    public static long GetLong(string par)
    {
        return GetLong(par, 0);
    }
    public static bool GetBool(string par, bool defvalue)
    {
        try { return bool.Parse(HttpContext.Current.Request.QueryString[par]); }
        catch { return defvalue; }
    }
    public static bool GetBool(string par)
    {
        return GetBool(par, true);
    }

    public static string GetString(string par)
    {
        return GetString(par, string.Empty);
    }
    public static string GetString(string par, string defvalue)
    {
        try { return HttpContext.Current.Request.QueryString[par].Trim(); }
        catch { return defvalue; }
    }
}
public class UWCHelper
{
    /// <summary>
    /// RenderControl sang dạng text
    /// </summary>
    /// <param name="path">Đường dẫn</param>
    /// <param name="propertyName">mảng thuộc tính</param>
    /// <param name="propertyValue">mảng giá trị</param>
    /// <returns></returns>
    public static string RenderControl(string path, string[] propertyName, object[] propertyValue)
    {
        Page pageHolder = new Page();
        pageHolder.EnableViewState = false;
        HtmlForm form = new HtmlForm();
        form.ID = "form1";
        pageHolder.Controls.Add(form);
        UserControl viewControl =
           (UserControl)pageHolder.LoadControl(path);

        if (propertyValue != null)
        {
            Type viewControlType = viewControl.GetType();
            for (int i = 0, length = propertyName.Length; i < length; i++)
            {
                PropertyInfo property =
                   viewControlType.GetProperty(propertyName[i]);

                if (property != null)
                {
                    property.SetValue(viewControl, propertyValue[i], null);
                }
                else
                {
                    throw new Exception(string.Format(
                       "UserControl: {0} does not have a public {1} property.",
                       path, propertyName[i]));
                }
            }
        }

        form.Controls.Add(viewControl);

        StringWriter output = new StringWriter();
        HttpContext.Current.Server.Execute(pageHolder, output, false);
        string stroutput = output.ToString().Trim();
        // remove form tag
        stroutput = stroutput.Substring(stroutput.IndexOf("</div>", StringComparison.CurrentCultureIgnoreCase) + 6);
        stroutput = stroutput.Substring(0, stroutput.Length - 7);

        return stroutput.Replace("__VIEWSTATEENCRYPTED", "");
    }
    public static string RenderControlWithFormTag(string path, string[] propertyName, object[] propertyValue)
    {
        Page pageHolder = new Page();
        pageHolder.EnableViewState = false;
        HtmlForm form = new HtmlForm();
        form.ID = "form1";
        pageHolder.Controls.Add(form);
        UserControl viewControl =
           (UserControl)pageHolder.LoadControl(path);

        if (propertyValue != null)
        {
            Type viewControlType = viewControl.GetType();
            for (int i = 0, length = propertyName.Length; i < length; i++)
            {
                PropertyInfo property =
                   viewControlType.GetProperty(propertyName[i]);

                if (property != null)
                {
                    property.SetValue(viewControl, propertyValue[i], null);
                }
                else
                {
                    throw new Exception(string.Format(
                       "UserControl: {0} does not have a public {1} property.",
                       path, propertyName[i]));
                }
            }
        }

        form.Controls.Add(viewControl);

        StringWriter output = new StringWriter();
        HttpContext.Current.Server.Execute(pageHolder, output, false);
        string stroutput = output.ToString().Trim();
        // remove form tag
        //stroutput = stroutput.Substring(stroutput.IndexOf("</div>", StringComparison.CurrentCultureIgnoreCase) + 6);
        //stroutput = stroutput.Substring(0, stroutput.Length - 7);
        return stroutput;
    }
}

public class PagingHelper
{
    public static string BuildPaging(string linkFormat, int count, int pageSize, int currentPage)
    {
        int pageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(count) / pageSize));
        if (pageCount <= 1)
            return string.Empty;

        StringBuilder html = new StringBuilder();
        int i;
        if (pageCount > 6)
        {
            if (currentPage <= 4)
                for (i = 0; i < pageCount && i <= currentPage + 2; i++)
                {
                    html.Append(BuildPageLink(i, linkFormat, currentPage));
                }
            else
            {
                html.Append(BuildPageLink(0, linkFormat, currentPage));
                html.Append(BuildPageLink(-1, linkFormat, currentPage));
                for (i = currentPage - 2; i < pageCount && i <= currentPage + 2; i++)
                {
                    html.Append(BuildPageLink(i, linkFormat, currentPage));
                }
            }
            if (currentPage >= pageCount - 5)
            {
                for (i = currentPage + 3; i < pageCount; i++)
                {
                    html.Append(BuildPageLink(i, linkFormat, currentPage));
                }
            }
            else
            {
                html.Append(BuildPageLink(-1, linkFormat, currentPage));
                html.Append(BuildPageLink(pageCount - 1, linkFormat, currentPage));
            }
        }
        else
        {
            for (i = 0; i < pageCount; i++)
            {
                html.Append(BuildPageLink(i, linkFormat, currentPage));
            }
        }

        return html.ToString();
    }
    static string BuildPageLink(int i, string linkFormat, int currentPage)
    {
        if (i == -1)
            return "<em>...</em>";
        else if (i == currentPage)
            return string.Format("<a class=\"current_page\">{0}</a>", i + 1);
        else
            return string.Format(linkFormat, i + 1);

    }
}

public class CacheHelper
{
    public static object Get(string key)
    {
        return HttpContext.Current.Cache[key];
    }

    public static void Set(string key, object value)
    {
        HttpContext.Current.Cache.Insert(key, value, null,
            DateTime.Now.AddMinutes(5),
            TimeSpan.Zero,
            System.Web.Caching.CacheItemPriority.Default, null
            );
    }

    public static void Set(string key, object value, int minutes)
    {
        HttpContext.Current.Cache.Insert(key, value, null,
            DateTime.Now.AddMinutes(minutes),
            TimeSpan.Zero,
            System.Web.Caching.CacheItemPriority.Default, null
            );
    }

    public static void Set(string key, object value, int minutes, System.Web.Caching.CacheDependency dependence)
    {
        HttpContext.Current.Cache.Insert(key, value, dependence,
            DateTime.Now.AddMinutes(minutes),
            TimeSpan.Zero,
            System.Web.Caching.CacheItemPriority.Default, null
            );
    }
}
public class Pager
{
    public static DataTable MakeDataPaper(int totalRecord, int currPages, int recordPerPages, int Type)
    {
        DataTable dtRet = new DataTable("DataPaper");
        dtRet.Columns.Add("ID", typeof(string));
        dtRet.Columns.Add("CssClass", typeof(string));
        dtRet.Columns.Add("Text", typeof(string));
        dtRet.Columns.Add("Page", typeof(int));
        dtRet.Columns.Add("Type", typeof(int));
        if (totalRecord > 1)
        {
            int ranges = totalRecord / recordPerPages;
            if (totalRecord % recordPerPages > 0)
                ranges += 1;
            int start = 1;// recordPerPages * (ranges - 1) + 1;
            int end = ranges;// start + recordPerPages;
            //if (end > totalRecord)
            //    end = totalRecord + 1;
            DataRow dr = null;
            if (ranges > 1)
            {
                //Trang dau tien
                dr = dtRet.NewRow();
                dr["ID"] = "first";
                dr["CssClass"] = "pager";
                dr["Text"] = "Trang đầu";
                dr["Page"] = "1";
                dr["Type"] = Type;
                dtRet.Rows.Add(dr);
                //Quay lai
                dr = dtRet.NewRow();
                dr["ID"] = "back";
                dr["CssClass"] = "pager";
                dr["Text"] = "Trước";
                dr["Page"] = (currPages - 1).ToString();
                dr["Type"] = Type;
                dtRet.Rows.Add(dr);
            }
            //
            //if (currPages - 3 > 0) start = currPages - 3;
            //if (currPages + 4 < end) end = currPages + 4;
            for (int i = start; i < end; i++)
            {
                if (i == currPages)
                {
                    dr = dtRet.NewRow();
                    dr["ID"] = i.ToString();
                    dr["CssClass"] = "pager-current";
                    dr["Text"] = i.ToString();
                    dr["Page"] = i.ToString();
                    dr["Type"] = Type;
                    dtRet.Rows.Add(dr);
                }
                else
                {
                    dr = dtRet.NewRow();
                    dr["ID"] = i.ToString();
                    dr["CssClass"] = "pager";
                    dr["Text"] = i.ToString();
                    dr["Page"] = i.ToString();
                    dr["Type"] = Type;
                    dtRet.Rows.Add(dr);
                }
            }
            if (currPages < ranges)
            {
                //Trang tiep theo
                dr = dtRet.NewRow();
                dr["ID"] = "next";
                dr["CssClass"] = "pager";
                dr["Text"] = "Tiếp";
                dr["Page"] = (currPages + 1).ToString();
                dr["Type"] = Type;
                dtRet.Rows.Add(dr);
                //Trang cuoi cung
                dr = dtRet.NewRow();
                dr["ID"] = "last";
                dr["CssClass"] = "pager";
                dr["Text"] = "Trang cuối";
                dr["Page"] = ranges.ToString();
                dr["Type"] = Type;
                dtRet.Rows.Add(dr);
            }
            dtRet.AcceptChanges();
        }
        return dtRet;
    }

    public static DataTable MakeDataPaper1(int totalPages, int currPages, int recordPerPages)
    {
        DataTable dtRet = new DataTable("DataPaper");
        dtRet.Columns.Add("ID", typeof(string));
        dtRet.Columns.Add("CssClass", typeof(string));
        dtRet.Columns.Add("Text", typeof(string));
        dtRet.Columns.Add("Page", typeof(int));
        dtRet.Columns.Add("Type", typeof(int));
        if (totalPages > 1)
        {
            int ranges = currPages / recordPerPages;
            if (currPages % recordPerPages > 0)
                ranges += 1;
            int start = recordPerPages * (ranges - 1) + 1;
            int end = start + recordPerPages;
            if (end > totalPages)
                end = totalPages + 1;
            DataRow dr = null;

            for (int i = start - 1; i < end - 1; i++)
            {
                if (i == currPages)
                {
                    dr = dtRet.NewRow();
                    dr["ID"] = i.ToString();
                    dr["CssClass"] = "pager-current";
                    dr["Text"] = (i + 1).ToString();
                    dr["Page"] = (i).ToString();
                    dr["Type"] = 0;
                    dtRet.Rows.Add(dr);
                }
                else
                {
                    dr = dtRet.NewRow();
                    dr["ID"] = i.ToString();
                    dr["CssClass"] = "pager";
                    dr["Text"] = (i + 1).ToString();
                    dr["Page"] = (i).ToString();
                    dr["Type"] = 0;
                    dtRet.Rows.Add(dr);
                }
            }

            dtRet.AcceptChanges();
        }
        return dtRet;
    }

    public static DataTable MakeDataPaperOriginal(int totalPages, int currPages, int recordPerPages)
    {
        DataTable dtRet = new DataTable("DataPaper");
        dtRet.Columns.Add("ID", typeof(string));
        dtRet.Columns.Add("CssClass", typeof(string));
        dtRet.Columns.Add("Text", typeof(string));
        dtRet.Columns.Add("Page", typeof(int));
        dtRet.Columns.Add("Type", typeof(int));
        if (totalPages > 1)
        {
            int ranges = currPages / recordPerPages;
            if (currPages % recordPerPages > 0)
                ranges += 1;
            int start = recordPerPages * (ranges - 1) + 1;
            int end = start + recordPerPages;
            if (end > totalPages)
                end = totalPages + 1;
            DataRow dr = null;

            //
            for (int i = start; i < end; i++)
            {
                if (i == currPages)
                {
                    dr = dtRet.NewRow();
                    dr["ID"] = i.ToString();
                    dr["CssClass"] = "pager-current";
                    dr["Text"] = i.ToString();
                    dr["Page"] = i.ToString();
                    dr["Type"] = 0;
                    dtRet.Rows.Add(dr);
                }
                else
                {
                    dr = dtRet.NewRow();
                    dr["ID"] = i.ToString();
                    dr["CssClass"] = "pager";
                    dr["Text"] = i.ToString();
                    dr["Page"] = i.ToString();
                    dr["Type"] = 0;
                    dtRet.Rows.Add(dr);
                }
            }

            dtRet.AcceptChanges();
        }
        return dtRet;
    }
}

public class SDSerializeXML
{
    public static string SerializeToXml<T>(T obj)
    {
        XmlDocument doc = new XmlDocument();
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        System.IO.MemoryStream stream = new System.IO.MemoryStream();
        try
        {
            serializer.Serialize(stream, obj);
            stream.Position = 0;
            doc.Load(stream);
            return doc.InnerXml;
        }
        catch (Exception ex)
        { }
        finally
        {
            stream.Close();
            stream.Dispose();
        }
        return doc.InnerXml;
    }
    public static string SerializeToListXml<T>(List<T> obj)
    {
        XmlDocument doc = new XmlDocument();
        XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
        System.IO.MemoryStream stream = new System.IO.MemoryStream();
        try
        {
            serializer.Serialize(stream, obj);
            stream.Position = 0;
            doc.Load(stream);
            return doc.InnerXml;
        }
        catch (Exception ex)
        { }
        finally
        {
            stream.Close();
            stream.Dispose();
        }
        return doc.InnerXml;
    }
    public static T DeserializeFromXml<T>(string xml)
    {
        T result;
        XmlSerializer ser = new XmlSerializer(typeof(T));
        using (TextReader tr = new StringReader(xml))
        {
            result = (T)ser.Deserialize(tr);
        }
        return result;
    }
    public static T DeserializeFromXml<T>(string xml, TextReader tr)
    {
        T result;
        XmlSerializer ser = new XmlSerializer(typeof(T));
        result = (T)ser.Deserialize(tr);
        return result;
    }
    public static List<T> DeserializeFromListXml<T>(string xml)
    {
        List<T> result;
        XmlSerializer ser = new XmlSerializer(typeof(List<T>));
        using (TextReader tr = new StringReader(xml))
        {
            result = (List<T>)ser.Deserialize(tr);
        }
        return result;
    }
    public static List<T> DeserializeFromListXml<T>(string xml, TextReader tr)
    {
        List<T> result;
        XmlSerializer ser = new XmlSerializer(typeof(List<T>));
        result = (List<T>)ser.Deserialize(tr);
        return result;
    }
}