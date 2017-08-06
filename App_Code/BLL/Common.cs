using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web.UI.WebControls;
using OfficeOpenXml;

/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
	public Common()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string GetGroupName(ScientificTopic topic)
    {
        if (topic.GroupTopicId == 0) return "";
        else
        {
            using (var data = new DataClassesDataContext())
            {
                var check = data.GroupTopics.SingleOrDefault(x => x.GroupTopicId == topic.GroupTopicId);
                if (check == null) return "";
                else return check.Name;
            }
        }
    }

    public static string GetGroupName(int topicId)
    {
        using (var data = new DataClassesDataContext())
        {
            var check = data.ScientificTopics.SingleOrDefault(x => x.ScientificTopicId == topicId);
            if (check == null) return "";
            else return GetGroupName(check);
        }
    }

    public static int CoutScientTopicByGroupTopicId(int id)
    {
        using (var data = new DataClassesDataContext())
        {
            return data.ScientificTopics.Count(x => x.GroupTopicId == id);
        }
    }

    public static string GetListUserPhanBien(ScientificTopic topic)
    {
        if (topic.ListUserPhanBien.Length == 0)
        {
            return "";
        }
        string sListUserPhanBien = topic.ListUserPhanBien.Remove(0, 1);
        string result = string.Empty;
        var list = sListUserPhanBien.Split(',').ToList();
        var data = new DataClassesDataContext();
        foreach (var item in list)
        {
            int userId = int.Parse(item);
            var user = data.Users.Single(x => x.UserId == userId);
            if (result.Length > 0)
                result = "," + user.UserName;
            else result = result + user.UserName;
        }
        return result;
    }

    public static void LoadYearToDropdownlist(DropDownList ddl)
    {
        int count = 0;
        for (int i = 2015; i <= DateTime.Now.Year; i++)
        {
            ddl.Items.Insert(count, new ListItem(i.ToString(), i.ToString()));
            count++;
        }
    }

    public static void LoadMonthToDropdownlist(DropDownList ddl)
    {
        for (int i = 1; i <= 12; i++)
        {
            ddl.Items.Insert(i-1, new ListItem(i.ToString(), i.ToString()));
        }
    }

    public static void LoadRoleToDropdownList(DropDownList ddl)
    {
        using (var obj = new DataClassesDataContext())
        {
            var list = obj.Roles.ToList();
            ddl.DataSource = list;
            ddl.DataTextField = "RoleName";
            ddl.DataValueField = "RoleId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Chọn Nhóm", "0"));
        }
    }

    public static void LoadUserByRoleToDropdownList(DropDownList ddl,byte roleId)
    {
        using (var obj = new DataClassesDataContext())
        {
            var list = obj.Users.Where(x=>x.RoleId==roleId).ToList();
            ddl.DataSource = list;
            ddl.DataTextField = "UserName";
            ddl.DataValueField = "UserId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Chọn Tài khoản", "0"));
        }
    }

    public static void LoadUserByRoleToDropdownList(DropDownList ddl, byte roleId,int journalId)
    {
        using (var obj = new DataClassesDataContext())
        {
            var list = obj.Users.Where(x => x.RoleId == roleId && x.JournalId == journalId).ToList();
            ddl.Items.Insert(0, new ListItem("Chọn Tài khoản", "0"));
            int i = 1;
            foreach (var item in list)
            {
                ddl.Items.Insert(i, new ListItem(item.UserName+"("+item.FullName+")", item.UserId.ToString()));
                i++;
            }
            //ddl.DataSource = list;
            //ddl.DataTextField = "UserName";
            //ddl.DataValueField = "UserId";
            //ddl.DataBind();
            
        }
    }

    public static void LoadGroupToDropdownlist(DropDownList ddl)
    {
        using (var data = new DataClassesDataContext())
        {
            var list = (from g1 in data.GroupTopics
                        join g2 in data.GroupTopics on g1.ParentId equals g2.GroupTopicId
                        where g1.Level == 2
                        select new
                        {
                            Name = g2.Name + "-" + g1.Name,
                            GroupTopicId = g1.GroupTopicId
                        }
                        ).OrderBy(x => x.Name).ToList();
            ddl.DataSource = list;
            ddl.DataValueField = "GroupTopicId";
            ddl.DataTextField = "Name";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("-- Chọn topic cha --"));// 0 is index of item
        }
    }

    public static void LoadGroupToDropdownlistByChuyenSan(DropDownList ddl,int chuyensanId,ScientificTopic st)
    {
        using (var data = new DataClassesDataContext())
        {
            if (st.GroupTopicId == 0)// Nếu chưa có nhóm thì chỉ load ra 
            {
                var list = (from g1 in data.GroupTopics
                            join g2 in data.GroupTopics on g1.ParentId equals g2.GroupTopicId
                            where g1.Level == 2 && g1.ChuyensanId == chuyensanId && g1.GroupTopicStatus==false
                            select new
                            {
                                Name = g2.Name + "-" + g1.Name,
                                GroupTopicId = g1.GroupTopicId
                            }
                            ).OrderBy(x => x.Name).ToList();
                ddl.DataSource = list;
                ddl.DataValueField = "GroupTopicId";
                ddl.DataTextField = "Name";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("-- Chọn topic cha --"));// 0 is index of item
            }
            else
            {
                var list = (from g1 in data.GroupTopics
                            join g2 in data.GroupTopics on g1.ParentId equals g2.GroupTopicId
                            where g1.Level == 2 && g1.ChuyensanId == chuyensanId
                            select new
                            {
                                Name = g2.Name + "-" + g1.Name,
                                GroupTopicId = g1.GroupTopicId
                            }
                            ).OrderBy(x => x.Name).ToList();
                ddl.DataSource = list;
                ddl.DataValueField = "GroupTopicId";
                ddl.DataTextField = "Name";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("-- Chọn topic cha --"));// 0 is index of item
            }
        }
    }

    public static void LoadGroupNew(DropDownList ddl)
    {
        using (var data = new DataClassesDataContext())
        {
            var listGroup = data.GroupNews.ToList();
            ddl.DataSource = listGroup;
            ddl.DataValueField = "GroupNewId";
            ddl.DataTextField = "Name";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Chọn Nhóm", "0"));
        }
    }

    public static void LoadUserExtensionType(DropDownList ddl)
    {
        using (var data = new DataClassesDataContext())
        {
            var listGroup = data.UserExtensionTypes.ToList();
            ddl.DataSource = listGroup;
            ddl.DataValueField = "UserExtensionTypeId";
            ddl.DataTextField = "UserExtensionTypeName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Chọn Nhóm", "0"));
        }
    }

    public static void LoadUserStatusToDropdownList(DropDownList ddl)
    {
        using (var obj = new DataClassesDataContext())
        {
            var list = obj.UserStatus.ToList();
            ddl.DataSource = list;
            ddl.DataTextField = "Name";
            ddl.DataValueField = "UserStatusId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Chọn trạng thái", "0"));
        }
    }

    public static void LoadScientificTopicStatusToDropdownList(DropDownList ddl)
    {
        using (var obj = new DataClassesDataContext())
        {
            var list = obj.ScientificTopicStatus.ToList();
            ddl.DataSource = list;
            ddl.DataTextField = "Name";
            ddl.DataValueField = "ScientificTopicStatusId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Chọn trạng thái", "0"));
        }
    }

    public static void LoadChuyenSanToDropdownlist(DropDownList ddl)
    {
        using (var data = new DataClassesDataContext())
        {
            var list = data.ChuyenSans.ToList();// Load danh sách phản biện
            ddl.DataSource = list;
            ddl.DataValueField = "Id";
            ddl.DataTextField = "Name";
            ddl.DataBind();
            //ddl.Items.Insert(0, new ListItem("Tất cả", "0"));
        }
    }

    public static void LoadScientTopicStatusToDropdownlist(DropDownList ddl)
    {
        using (var data = new DataClassesDataContext())
        {
            var list = data.ScientificTopicStatus.ToList();// Load danh sách phản biện
            ddl.DataSource = list;
            ddl.DataValueField = "ScientificTopicStatusId";
            ddl.DataTextField = "Name";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Chọn tất cả", "0"));
        }
    }

    public static void LoadPrifixUserToDropdownList(DropDownList ddl)
    {
        using (var obj = new DataClassesDataContext())
        {
            var list = obj.PrifixUers.Where(x=>x.IsActive==true).ToList();
            ddl.DataSource = list;
            ddl.DataTextField = "Name";
            ddl.DataValueField = "Id";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Chọn Chức danh", "0"));
        }
    }

    public static string EndCodePassWord(string passWord)
    {
        return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(passWord));
    }

    public static string DecodePassWord(string passWord)
    {
        return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(passWord));
    }

    public static string GetContentMailToPhanbine(SystemConfig systemConfig, User u,ScientificTopic st)
    {
        string mailMau = systemConfig.MauMailGuiPhanBien;
        mailMau = mailMau.Replace("@Prifix", u.PrefixName);
        mailMau = mailMau.Replace("@Name", u.FullName);
        mailMau = mailMau.Replace("@Code", st.TopicCode.ToString());
        mailMau = mailMau.Replace("@Date", st.AppointmentDate.ToString("dd-MM-yyyy"));
        return mailMau;
    }

    public static DataTable ImportFileExcelToDataTable(Stream fileNameStream)
    {
        using (DataTable dt = new DataTable())
        {
            using (var excel = new ExcelPackage(fileNameStream))
            {
                ExcelWorkbook workBook = excel.Workbook;
                if (workBook != null)
                {
                    if (workBook.Worksheets.Count > 0)
                    {
                        ExcelWorksheet worksheet = workBook.Worksheets.First();
                        ExcelCellAddress startCell = worksheet.Dimension.Start;
                        ExcelCellAddress endCell = worksheet.Dimension.End;
                        for (int col = startCell.Column; col <= endCell.Column; col++)
                        {
                            object col1Header1 = worksheet.Cells[1, col].Value;
                            dt.Columns.Add("" + col1Header1 + "");
                        }
                        // add DataRows to DataTable
                        for (int row = startCell.Row + 1; row <= endCell.Row + 1; row++)
                        {
                            DataRow dr = dt.NewRow();
                            int x = 0;
                            for (int col = startCell.Column; col <= endCell.Column; col++)
                            {
                                dr[x++] = worksheet.Cells[row, col].Value;
                            }
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }
            return dt;
        }
    }

    public static string SendMail(string yourid, string yourpassword, string toMail, string subject, string content)
    {
        string message = string.Empty;
        try
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(yourid, yourpassword);

            MailMessage mm = new MailMessage(yourid, toMail, subject, content);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.IsBodyHtml = true;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }
        catch (SmtpException ex)
        {
            message = ex.Message;
        }

        return message;
    }

    public static long DivisionUserProcess(DataClassesDataContext data,int topicId, int roleId, int chuyensanId, ref string message)
    {
        if (topicId == 0)
        {
            var chuyensan = data.ChuyenSans.SingleOrDefault(x=>x.Id==chuyensanId);
            if (chuyensan!=null)
            {
                return chuyensan.UserId;
            }
            else
            {
                message = "Không tìm thấy Tài khoản để chuyển";
                return 0;
            }
        }

        ScientificTopic topic = data.ScientificTopics.SingleOrDefault(x=>x.ScientificTopicId==topicId);
        
        User user = null;
        // Chuyển cho Tác giả thì tìm Tác giả đã tạo để cập nhật
        if (roleId == Constants.RoleTacgia)
        {
            return topic.UserIdCreate;
        }
        else if (roleId == Constants.RoleTongBienTap)// Nếu là Tổng biên tập thì chỉ có 1 User lấy ra top 1 UserId
        {
            user = data.Users.FirstOrDefault(x => x.RoleId == Constants.RoleTongBienTap);
            if (user != null) return user.UserId;
            else 
            {
                message = "Không tìm thấy Tài khoản Tổng biên tập để chia";
                return 0;
            }
        }
        else if (roleId == Constants.RolePhanBien)// Nếu là Phản biện thì tìm ra UserId được chỉ định duyệt để xử lý
        {
            string listUser = topic.ListUserPhanBien.Replace(",","");
            try
            {
                return long.Parse(listUser);
            }
            catch (System.Exception)
            {
                message = "Không tìm thấy Tài khoản Phản biện để chuyển";
                return 0;
            }
            
        }
        else if (roleId == Constants.RoleVanPhongToaSoan)// Nếu là nhóm Biên tập chuyên san và Văn phòng tòa soạn thì kiểm tra nếu có nhật ký xử lý trước đó thì cập nhật lại User, Nếu không thì lấy ngẫu nhiên
        {
            var chuyensan = data.ChuyenSans.SingleOrDefault(x => x.Id == chuyensanId);
            if (chuyensan != null)
            {
                return chuyensan.UserId;
            }
            else
            {
                message = "Không tìm thấy Tài khoản để chuyển";
                return 0;
            }
        }
        else if (roleId == Constants.RoleTruongBanBienTapChuyenSan)// Chuyên san thì tìm User quản lý chuyên san để chia
        {
            ChuyenSan cs = null;
            if(chuyensanId==0)
                cs = data.ChuyenSans.SingleOrDefault(x => x.Id == topic.ChuyensanId);
            else
                cs = data.ChuyenSans.SingleOrDefault(x => x.Id == chuyensanId);
            if (cs == null)
            {
                message = "Bài báo này chưa chọn Chuyên san";
                return 0;
            }

            return cs.ManageUserId;
        }
        else
        {
            message = "Role này chưa có kịch bản chia";
            return 0;
        }
    }
}