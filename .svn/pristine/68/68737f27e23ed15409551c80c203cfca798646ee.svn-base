using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UtilitiesConvert
/// </summary>
public class UtilitiesConvert
{
    public static DateTime ConvertDateShowToDateTime(string str, ref string message)
    {
        try
        {
            string[] arr = str.Split(' ');
            string[] arrDate = arr[0].Split('/');
            return new DateTime(Convert.ToInt32(arrDate[2]), Convert.ToInt32(arrDate[1]), Convert.ToInt32(arrDate[0]));
        }
        catch (Exception ex)
        {
            message = ex.Message;
            return DateTime.Now;
        }
    }
    public static string ConvertDateShowToDateTime(string str, out DateTime dt)
    {
        string ret = "";
        dt = DateTime.MinValue;
        try
        {
            string[] arr = str.Split(' ');
            string[] arrDate = arr[0].Split('/');
            dt = new DateTime(Convert.ToInt32(arrDate[2]), Convert.ToInt32(arrDate[1]), Convert.ToInt32(arrDate[0]));
        }
        catch (Exception ex)
        {
            ret = ex.Message;
        }
        return ret;
    }

    public static DateTime ConvertDateTimeShowToDateTime(string str, ref string message)
    {
        try
        {
            string[] arr = str.Split(' ');
            string[] arrDate = arr[0].Split('/');
            string[] arrTime = arr[1].Split(':');
            return new DateTime(Convert.ToInt32(arrDate[2]), Convert.ToInt32(arrDate[1]), Convert.ToInt32(arrDate[0]),
                                Convert.ToInt32(arrTime[0]), Convert.ToInt32(arrTime[1]), Convert.ToInt32(arrTime[2]));
        }
        catch (Exception ex)
        {
            message = ex.Message;
            return DateTime.Now;
        }
    }
}