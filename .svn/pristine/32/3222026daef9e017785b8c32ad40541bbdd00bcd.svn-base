using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for clsMessage
/// </summary>
public class clsMessage
{
    //status
    public static string Change(string strModBy, string strModDate)
    {
        string strTmp = "";
        if (strModBy == "")
        {
            strTmp = " cập nhật ngày " + strModDate; ;
        }
        else
        {
            strTmp = "[ " + strModBy + " ]" + " cập nhật ngày " + strModDate;
        }
        return strTmp;
    }


    public static string notifyAttachFilesize(int iFilesize)
    {
        string strAttach = "";
        if (iFilesize / 1024 < 0)
        {
            strAttach += "[" + iFilesize.ToString() + " Byte]";
        }
        else if (iFilesize / 1024 < 1024)
        {
            strAttach += "[" + System.Decimal.Round(Convert.ToDecimal(iFilesize) / 1024, 2) + " KB]";
        }
        else
        {
            strAttach += "[" + System.Decimal.Round(Convert.ToDecimal(iFilesize) / (1024 * 1024), 2) + " MB]";
        }
        return strAttach;
    }


    // Field data
    public static string FieldNull(string pFieldName)
    {
        return "'" + pFieldName + "' không cho phép rỗng!";
    }

    public static string FieldNumber(string pFieldName)
    {
        return "'" + pFieldName + "' chỉ chấp nhận kiểu số!";
    }

    public static string FieldNumberPastZero(string pFieldName)
    {
        return "'" + pFieldName + "' chỉ chấp nhận kiểu số lớn hơn không!";
    }

    public static string IDNotExist(string pFieldName, string pValue)
    {
        return pFieldName + "='" + pValue + "' không tồn tại trong cơ sở dữ liệu!";
    }

    public static string IDExist(string pFieldName, string pValue)
    {
        return pFieldName + "='" + pValue + "' đã tồn tại trong cơ sở dữ liệu!";
    }

    public static string FieldLength(string pFieldName)
    {
        return "'" + pFieldName + "' phải lớn hơn 6 và nhỏ hơn 20 ký tự !";
    }

    public static string FieldExit(string pObject, string pFieldName)
    {
        return pObject + " '" + pFieldName + "' đã tồn tại trong cơ sở dữ liệu!";
    }

    //Message of actions
    public static string ErrorWhile(string pWhile)
    {
        return "Lỗi trong khi " + pWhile + "!";
    }

    public static string ObjectNotCreated(string pObjectName)
    {
        return "Đối trượng '" + pObjectName + "' chưa được khởi tạo";
    }

    public static string NoDataForUpdate(string pFieldName, string pValue)
    {
        return "Không tìm thấy dữ liệu có " + pFieldName + "='" + pValue + "' để cập nhật!";
    }

    public static string NoDataForUpdate()
    {
        return "Dữ liệu cần cần cập nhật bị rỗng, chương trình không thể cập nhật bản ghi này";
    }

    public static string NoDataForDelete(string pFieldName, string pValue)
    {
        return "Không tìm thấy dữ liệu có " + pFieldName + "='" + pValue + "' để xóa!";
    }

    public static string NotChooseDataForUpdate()
    {
        return "Dữ liệu chưa được chọn để cập nhật";
    }

    public static string NotChooseDataForDelete()
    {
        return "Dữ liệu chưa được chọn để xóa";
    }


    public static string ErrorWhileConnectDB()
    {
        return "Lỗi trong khi thực hiện kết nối đến cơ sở dữ liệu";
    }

    public static string ErrorWhileInsert(string pObjectName)
    {
        return "Lỗi trong quá trình ghi mới '" + pObjectName + "' vào cơ sở dữ liệu";
    }

    public static string ErrorWhileUpdate(string pObjectName)
    {
        return "Lỗi trong quá trình cập nhật '" + pObjectName + "' vào cơ sở dữ liệu";
    }

    public static string ErrorWhileDelete(string pObjectName)
    {
        return "Lỗi trong quá trình xóa '" + pObjectName + "' khỏi cơ sở dữ liệu";
    }

    public static string ErrorWhileLoadItem(string pObjectName)
    {
        return "Lỗi trong quá trình lấy thông tin '" + pObjectName + "' từ cơ sở dữ liệu";
    }

    public static string ErrorWhileGetList(string pObjectName)
    {
        return "Lỗi trong quá trình lấy danh sách '" + pObjectName + "' từ cơ sở dữ liệu";
    }

    public static string ErrorWhileCheckDataExist(string pObjectName)
    {
        return "Lỗi trong quá trình kiểm tra '" + pObjectName + "' đã tồn tại hay chưa";
    }

    public static string ItemNotDelete(string pObjectName)
    {
        return "Không thể xoá '" + pObjectName + "' vì đã được sử dụng";
    }

    public int CheckMessageSended(DBM obj, long incident_Id, int work_Id)
    {
        int count = 0;
        Hashtable ht = new Hashtable();
        try
        {
            ht.Add("Work_Id", work_Id);
            ht.Add("Incident_Id", incident_Id);
            count = int.Parse(obj.GetField("sp_tbl_Messages_GetByWorkAndIncident", ht));
        }
        catch (Exception)
        {
        }
        finally
        {
            ht = null;
        }
        return count;
    }
    
}